using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
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


            foreach (string fileToLoad in Directory.GetFiles(inputDirectory.FullName, "*.html", SearchOption.AllDirectories))
            {
                var newClass = ParseClass(fileToLoad);

                if (newClass != null)
                    classList.Add(newClass);
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
                                paramSelectStr += $" and parameter[{i + 1}][@type='{method.Arguments[i].Type}']";
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

        static Class ParseClass(string fileToLoad)
        {
            var newClass = new Class();

            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(fileToLoad);

            var packageDiv = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[@class='header']/div");
            if (packageDiv == null)
                return null; ;

            newClass.PackageName = packageDiv.InnerText.Trim();

            var classNameNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[@class='header']/h2");
            if (classNameNode == null)
                return null;

            var classNameString = classNameNode.InnerText.Trim();
            newClass.Name = classNameString.Substring(classNameString.IndexOf(' ') + 1);
            

            if (!classNameString.StartsWith("Class"))
                newClass.IsInterface = true;

            ScanMethods("method", newClass.Methods);
            ScanMethods("constructor", newClass.Constructors);

            void ScanMethods(string detailSelector, List<Method> methods)
            {
                var methodDetailNode = htmlDoc.DocumentNode.SelectSingleNode($"/html/body/div[@class='contentContainer']/div[@class='details']/ul/li/ul/li/a[@name='{detailSelector}.detail']");
                if (methodDetailNode != null)
                {
                    var methodNodeList = methodDetailNode.ParentNode.SelectNodes($"./a[not(@name='{detailSelector}.detail')]");

                    foreach (var methodLinkItem in methodNodeList)
                    {
                        methods.Add(processMethodLinkItem(methodLinkItem));
                    }
                }
            }
            return newClass;
        }

        static Method processMethodLinkItem (HtmlNode methodLinkItem)
        {
            var newMethod = new Method();
            var fullName = methodLinkItem.Attributes["name"].Value;
            
            bool isNameItem = true;
            foreach (var tok in fullName.Split('-'))
            {
                if (isNameItem)
                {
                    newMethod.Name = tok;
                }
                else if (!string.IsNullOrWhiteSpace(tok))
                {
                    newMethod.Arguments.Add(new MethodArgument { Type = tok });
                }
                isNameItem = false;
            }

            if (newMethod.Arguments.Count > 0)
            {
                var tulNode = methodLinkItem.NextSibling.NextSibling;
                if (tulNode.Name != "ul")
                    tulNode = tulNode.NextSibling;
                var methodPreNode = tulNode.SelectSingleNode("./li/pre");
                var allInnerText = HttpUtility.HtmlDecode(methodPreNode.InnerText);
                var paramPart = allInnerText.Substring(allInnerText.LastIndexOf('(') + 1);
                paramPart = paramPart.Substring(0, paramPart.LastIndexOf(")"));
                var paramListFromText = paramPart.Split(',');

                for (int i = 0; i < newMethod.Arguments.Count; i++)
                {
                    newMethod.Arguments[i].Name = paramListFromText[i].Trim().Split(null).Last().Trim();
                }
            }

            return newMethod;
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

                default:
                    break;
            }
            return name;
        }
    }
}
