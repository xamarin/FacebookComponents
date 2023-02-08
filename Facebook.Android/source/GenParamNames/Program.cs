using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using HtmlAgilityPack;

namespace GenParamNames
{
    class Program
    {
        static int Main(string [] args)
        {
            // Create a root command with some options
            var rootCommand = new RootCommand
            {
                new Option<DirectoryInfo>(
                    new [] { "-i", "--in", "--in-dir", "--input-directory"},
                    "Input directory to recursively scan for html class files")
                {
                    IsRequired = true,
                },
                new Option<FileInfo>(
                    new [] { "-o", "--out", "--output-file"},
                    "Output Xamarin Android binding transform file")
                {
                    IsRequired = true,
                }
            };

            rootCommand.Description = "Scans --input-directory for javadoc html files and generates a Xamarin Android binding transform file to proved better parameter names to methods and ctors.";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<DirectoryInfo, FileInfo>((inputDirectory, outputFile) =>
            {
                if (!inputDirectory.Attributes.HasFlag(FileAttributes.Directory))
                {
                    Console.Error.WriteLine("input-directory must be an existing directory");
                    return 1;
                }

                if (!inputDirectory.Exists)
                {
                    Console.Error.WriteLine("input-directory must be an existing directory");
                    return 1;
                }

                ScanDirectoryAndWrite(inputDirectory, outputFile);

                return 0;

            });

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }

        static void ScanDirectoryAndWrite (DirectoryInfo inputDirectory, FileInfo outputFile)
        {
            var classList = new List<Class>();

            var sourcefolder = inputDirectory.Parent.FullName;
            foreach (string fileToLoad in Directory.GetFiles(inputDirectory.FullName, "*.html", SearchOption.AllDirectories))
            {
                try
                {

                
                var newClass = ParseClass(fileToLoad, sourcefolder);

                if (newClass != null)
                    classList.Add(newClass);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Class for file: {fileToLoad} failed with error: {ex}");
                }
            }

            //using (var sw = new StringWriter())
            //{
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

                using (var xw = XmlWriter.Create(outputFile.FullName, settings))
                {
                    xw.WriteStartDocument();
                    xw.WriteStartElement("metadata");

                    foreach (var tClass in classList)
                    {
                        void WriteMethodToStream(Method method, string methodOrConstructor)
                        {
                            var paramSelectStr = string.Empty;

                            for (int i = 0; i < method.Arguments.Count; i++)
                            {
                                if (method.Arguments[i].IsGenericArgument)
                                    paramSelectStr += $" and parameter[{i + 1}][starts-with(@type,'{FixArgumentParameterType(method.Arguments[i].Type.Replace(":A", "[]"))}')]";
                                else
                                    paramSelectStr += $" and parameter[{i + 1}][@type='{FixArgumentParameterType(method.Arguments[i].Type.Replace(":A", "[]"))}']";
                            }

                            var classStr = tClass.IsInterface ? "interface" : "class";
                            var pathStr = $"/api/package[@name='{tClass.PackageName}']/{classStr}[@name='{tClass.Name}']/{methodOrConstructor}[@name='{method.Name}' and count(parameter)={method.Arguments.Count}{paramSelectStr}]";

                            for (int i = 0; i < method.Arguments.Count; i++)
                            {
                                xw.WriteStartElement("attr");
                                xw.WriteStartAttribute("path");
                                xw.WriteString($"{pathStr}/parameter[{i + 1}]");
                                xw.WriteEndAttribute();

                                xw.WriteStartAttribute("name");
                                xw.WriteString("managedName");
                                xw.WriteEndAttribute();

                                xw.WriteString(FixParameterName(method.Arguments[i].Name));
                                xw.WriteEndElement();
                            }
                        }

                        foreach (var method in tClass.Methods.Where(m => m.Arguments.Count > 0))
                        {
                            WriteMethodToStream(method, "method");
                        }

                        foreach (var method in tClass.Constructors.Where(m => m.Arguments.Count > 0))
                        {
                            WriteMethodToStream(method, "constructor");
                        }
                    }

                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                }
            //}
        }

        static Class ParseClass(string fileToLoad, string sourcefolder)
        {
            var newClass = new Class();

            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(fileToLoad);
            System.IO.FileInfo file = new FileInfo(fileToLoad);
            var pckg = file.DirectoryName.Substring(sourcefolder.Length).TrimStart('\\').Replace("\\",".");
            var packageDiv = htmlDoc.DocumentNode.SelectSingleNode("/html/body/main/div[@class='header']/div");
            if (packageDiv == null)
                return null; ;

            newClass.PackageName = !packageDiv.InnerText.StartsWith("Package") ? packageDiv.InnerText.Trim() : pckg;

            var classNameNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/main/div[@class='header']/h2");
            if (classNameNode == null)
                return null;

            var classNameString = classNameNode.InnerText.Trim();
            newClass.Name = RemoveGenericFromClassName(classNameString.Substring(classNameString.IndexOf(' ') + 1));

            if (!classNameString.StartsWith("Class"))
                newClass.IsInterface = true;

            ScanMethods("method", newClass.Methods, "id");
            ScanMethods("constructor", newClass.Constructors);

            void ScanMethods(string detailSelector, List<Method> methods, string attributeIdentifier = "name")
            {
                var methodDetailNode = htmlDoc.DocumentNode.SelectSingleNode($"/html/body/main/div[@class='contentContainer']/div[@class='details']/ul/li/section/ul/li/a[@id='{detailSelector}.detail']");
                if (methodDetailNode != null)
                {
                    var methodNodeList = methodDetailNode.ParentNode.SelectNodes($"./a[not(@id='{detailSelector}.detail')]");

                    foreach (var methodLinkItem in methodNodeList)
                    {
                        methods.Add(processMethodLinkItem(methodLinkItem, attributeIdentifier, newClass.PackageName));
                    }
                }
            }
            return newClass;
        }

        static Method processMethodLinkItem (HtmlNode methodLinkItem, string attributeIdentifier, string packageName)
        {
            var newMethod = new Method();
            var fullName = methodLinkItem.Attributes[attributeIdentifier].Value;
            
            //get method definition and arguments
            string regexPattern = @"(?<name>[\w\s-]+)(?:\((?<args>.*)\))?";
            Regex r1 = new Regex(regexPattern, RegexOptions.IgnoreCase);
            Match match = r1.Match(fullName);
            if (match.Success)
            {

                if (match.Groups["name"].Success)
                {
                    newMethod.Name = match.Groups["name"].Value;
                }
                if (match.Groups["args"].Success && !string.IsNullOrEmpty(match.Groups["args"].Value))
                {
                    if (match.Groups["args"].Value.Contains("("))
                    {   //we have a typedAlias or other complex type
                        string regexPattern2 = @"(?<name>[\w\s-]+),?(?:\((?<args>.*)\))?";
                        Regex r2 = new Regex(regexPattern2, RegexOptions.IgnoreCase);
                        MatchCollection matches = r2.Matches(match.Groups["args"].Value);
                        if (matches.Count > 0)
                        {
                            foreach(Match matchParam in matches)
                            {
                                if (!matchParam.Groups["args"].Success)
                                {
                                    newMethod.Arguments.Add(new MethodArgument { Type = matchParam.Groups["name"].Value, TypeOriginal = matchParam.Groups["name"].Value });
                                }
                                else
                                {   //try to figure out what type we have
                                    newMethod.Arguments.Add(new MethodArgument { Type = matchParam.Groups["name"].Value, TypeOriginal = matchParam.Groups["name"].Value });
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var tok in match.Groups["args"].Value.Split(','))
                        {
                            if (!string.IsNullOrWhiteSpace(tok))
                            {
                                newMethod.Arguments.Add(new MethodArgument { Type = tok, TypeOriginal = tok });
                            }
                        }
                    }
                }
            }

            if (newMethod.Arguments.Count > 0)
            {
                var tulNode = methodLinkItem.NextSibling.NextSibling;
                if (tulNode.Name != "ul")
                    tulNode = tulNode.NextSibling;
                var methodPreNode = tulNode.SelectSingleNode("./li/pre");
                
                var allInnerText = HttpUtility.HtmlDecode(methodPreNode.InnerText);
                allInnerText = allInnerText.Replace("@Nullable()",String.Empty).Trim();
                var paramPart = allInnerText.Substring(allInnerText.LastIndexOf('(') + 1);
                paramPart = paramPart.Substring(0, paramPart.LastIndexOf(")"));
                var origParamPart = paramPart;
                if (paramPart.Contains("<"))
                {
                    newMethod.HasGenericArguments = true;
                    paramPart = RemoveGenericsFromParamList(paramPart);
                }

                var paramListFromText = paramPart.Split(',');

                for (int i = 0; i < newMethod.Arguments.Count; i++)
                {
                    newMethod.Arguments[i].Name = paramListFromText[i].Trim().Split(null).Last().Trim();
                    if(paramListFromText[i].Contains("<"))
                    {
                        newMethod.Arguments[i].IsGenericArgument = true;
                        newMethod.Arguments[i].Type = paramListFromText[i].Trim().Split(null).First().Trim();
                    }
                    if(newMethod.Arguments[i].Type == "TypeAliased")
                    {   //fallback
                        newMethod.Arguments[i].Type = paramListFromText[i].Trim().Split(null).First().Trim();
                    }
                }
                if(newMethod.HasGenericArguments)
                {
                    foreach(var arg in newMethod.Arguments)
                    {
                        arg.Type = GetGenericsFromParamList(origParamPart, arg.TypeOriginal);
                        if(arg.Type.Contains("<"))
                        {
                            arg.IsGenericArgument = true;
                        }
                    }
                }
                for (int i = 0; i < newMethod.Arguments.Count; i++)
                {
                    newMethod.Arguments[i].Name = paramListFromText[i].Trim().Split(null).Last().Trim();
                    if (paramListFromText[i].Contains("<"))
                    {
                        newMethod.Arguments[i].IsGenericArgument = true;
                        newMethod.Arguments[i].Type = paramListFromText[i].Trim().Split(null).First().Trim();
                    }
                    if (newMethod.Arguments[i].Type == "TypeAliased")
                    {   //fallback
                        newMethod.Arguments[i].Type = paramListFromText[i].Trim().Split(null).First().Trim();
                    }
                }


                //new Documentation doesn't have package attributes anymore
                string hrefPattern = @"<(?<Tag_Name>\w*)\b[^>]*?\b(?<URL_Type>(?(1)href|src))*=\s*(?:""(?<URL>(?:\\""|[^""])*)"")*[^>]*>(?<CONTENT>[^<]*)<\/\1>";
                Regex hrefRegex = new Regex(hrefPattern, RegexOptions.IgnoreCase);
                MatchCollection matches = hrefRegex.Matches(methodPreNode.InnerHtml);
                List<MethodArgument> legalList = GetMethodArguments(matches);
                if (legalList.Count() > 0)
                {
                    foreach (var argument in newMethod.Arguments)
                    {
                        var details = legalList.Where(x => x.TypeOriginal == argument.TypeOriginal).FirstOrDefault();
                        if (details != null)
                        {
                            if(argument.Type.Contains("<"))
                            {   //complex type
                                var innerType = argument.Type.Substring(argument.Type.IndexOf("<")+1, argument.Type.IndexOf(">")- argument.Type.IndexOf("<")-1);
                                var innerTypeDetails = legalList.Where(x => x.TypeOriginal == innerType).FirstOrDefault();
                                var outerTypeDetails = legalList.Where(x => x.TypeOriginal == argument.TypeOriginal).FirstOrDefault();
                                if (argument.TypeOriginal == "Array")
                                {
                                    argument.Type = innerTypeDetails != null ? innerTypeDetails.Type + "[]" : argument.Type;
                                }
                                else
                                {
                                    argument.Type = innerTypeDetails != null ? argument.Type.Replace(innerType, innerTypeDetails.Type) : argument.Type;
                                    argument.Type = argument.Type.Replace(argument.TypeOriginal, outerTypeDetails.Type);
                                }
                            }
                            else if(details.Url != details.Type)
                            {   //
                                argument.Type = details.Type;
                            }
                            else
                            {   //local class
                                int hierarchyUp = 0;
                                string type = details.Type;
                                //cleanup
                                type = type.Replace(".html", string.Empty);
                                while (type.Contains(".."))
                                {
                                    type = type.Replace("../", string.Empty);
                                    hierarchyUp++;
                                }
                                while (hierarchyUp > 0)
                                {
                                    packageName = packageName.Substring(0, packageName.LastIndexOf("."));
                                    hierarchyUp--;
                                }
                                argument.Type = packageName + "." + type;
                                
                                
                            }
                            //if (details.Url.StartsWith(argument.Type))
                            //{   //local class
                            //    argument.Type = packageName + "." + argument.Type;
                            //}
                            //else if (details.Url.StartsWith("https://developer.android.com/reference/kotlin/"))
                            //{   //android class
                            //    var pckg = details.Type;
                            //    argument.Type = pckg;
                            //}
                            //else
                            //{ //analyse url for package name

                            //}
                        }
                    }
                }
            }

            return newMethod;
        }

        private static List<MethodArgument> GetMethodArguments(MatchCollection matches)
        {
            List<MethodArgument> arguments = new List<MethodArgument>();
            foreach (Match match in matches)
            {
                MethodArgument newArgument = new MethodArgument();
                if (match.Groups["URL"].Success)
                {
                    newArgument.Url = match.Groups["URL"].Value;
                }
                if (match.Groups["CONTENT"].Success)
                {
                    newArgument.TypeOriginal = match.Groups["CONTENT"].Value;
                }
                if (match.Groups["URL"].Value.StartsWith("https://developer.android.com/reference/kotlin/"))
                {   //android class
                    newArgument.Type = match.Groups["URL"].Value.Replace("https://developer.android.com/reference/kotlin/", string.Empty).Replace(".html", string.Empty).Replace("/", ".");
                }
                else if (match.Groups["URL"].Value.StartsWith("http"))
                {   //analyse url for package name
                    newArgument.Type = match.Groups["CONTENT"].Value;
                }
                else
                {   //local class
                    newArgument.Type = match.Groups["URL"].Value;
                }
                if (!arguments.Contains(newArgument)) arguments.Add(newArgument);
            }
            return arguments;
        }

        static string RemoveGenericsFromParamList(string inputStr)
        {
            if (!inputStr.Contains('<'))
                return inputStr;

            var sb = new StringBuilder(inputStr.Length);

            var skipCount = 0;

            foreach (char c in inputStr)
            {
                if (c == '<')
                    skipCount++;

                else if(c == '>')
                    skipCount--;

                else if (skipCount == 0)
                    sb.Append(c);
            }

            return sb.ToString();
        }
        static string GetGenericsFromParamList(string inputStr, string param)
        {
            if (!inputStr.Contains('<'))
                return inputStr;

            var sb = new StringBuilder(inputStr.Length);
            sb.Append(param);
            var skipCount = 0;
            var start = inputStr.IndexOf(param+"<", StringComparison.Ordinal);
            if (start == -1) return param;
            inputStr = inputStr.Substring(start);
            foreach (char c in inputStr)
            {
                if (c == '<')
                {
                    skipCount++;
                    sb.Append(c);
                }
                else if (c == '>')
                {
                    skipCount--;
                    sb.Append(c);
                    break;
                }
                else if (skipCount > 0)
                    sb.Append(c);
            }

            return sb.ToString();
        }

        static string FixParameterName(string name)
        {
            switch(name)
            {
                case "out":
                    return "@out";

                case "params":
                    return "@params";

                case "object":
                    return "@object";

                case "string":
                    return "@string";

                case "in":
                    return "@in";

                case "ref":
                    return "@ref";

                default:
                    break;
            }
            return name;
        }

        static string FixArgumentParameterType(string type)
        {
            switch (type)
            {
                case "java.lang.Integer":
                    return "int";

                case "java.lang.Boolean":
                    return "boolean";

                default:
                    break;
            }
            return type;
        }

        static string RemoveGenericFromClassName(string className)
        {
            var index = className.IndexOf('&');

            if (index != -1)
            {
                className = className.Substring(0, index);
            }

            return className;
        }
    }
}
