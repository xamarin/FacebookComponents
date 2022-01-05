#addin nuget:?package=Cake.XCode&version=4.2.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.1.2
#addin nuget:?package=Cake.Xamarin&version=3.0.2
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

#load "poco.cake"

// Podfile basic structure
var PODFILE_BEGIN = new [] {
	"platform :ios, '{0}'",
	"install! 'cocoapods', :integrate_targets => false",
	"use_frameworks!",
};
var PODFILE_TARGET = new [] {
	"target 'XamarinGoogle' do",
};
var PODFILE_END = new [] {
	"end",
};

void AddArtifactDependencies (List<Artifact> list, Artifact [] dependencies)
{
	if (dependencies == null)
		return;
	
	list.AddRange (dependencies);

	foreach (var dependency in dependencies)
		AddArtifactDependencies (list, dependency.Dependencies);
}

void UpdateVersionInCsproj (Artifact artifact) 
{
	var csprojPath = $"./source/{artifact.CsprojName}/{artifact.CsprojName}.csproj";
	XmlPoke(csprojPath, "/Project/PropertyGroup/FileVersion", artifact.NugetVersion);
	XmlPoke(csprojPath, "/Project/PropertyGroup/PackageVersion", artifact.NugetVersion);
}

void CreateAndInstallPodfile (Artifact artifact)
{
	if (artifact.PodSpecs?.Length == 0)
		return;
	
	var podfile = new List<string> ();
	var podfileBegin = new List<string> (PODFILE_BEGIN);
	
	podfileBegin [0] = string.Format (podfileBegin [0], artifact.MinimunSupportedVersion);
	podfile.AddRange (podfileBegin);

	if (artifact.ExtraPodfileLines != null)
		podfile.AddRange (artifact.ExtraPodfileLines);

	podfile.AddRange (PODFILE_TARGET);

	foreach (var podSpec in artifact.PodSpecs) {
		if (podSpec.FrameworkSource != FrameworkSource.Pods)
			continue;

		podfile.AddRange (podSpec.BuildPodLines ());
	}

	if (podfile.Count == PODFILE_BEGIN.Length + PODFILE_TARGET.Length + (artifact.ExtraPodfileLines?.Length ?? 0))
		return;

	podfile.AddRange (PODFILE_END);

	var podfilePath = $"./externals/{artifact.Id}";
	EnsureDirectoryExists (podfilePath);

	FileWriteLines ($"{podfilePath}/Podfile", podfile.ToArray ());
	CocoaPodInstall (podfilePath);
}

void CopyXcFrameworksToExternals (Artifact artifact)
{
	if (artifact.PodSpecs?.Length == 0)
		return;

	var workingDirectory = (DirectoryPath)$"./externals/{artifact.Id}";

	foreach (var podSpec in artifact.PodSpecs)
	{
		if (podSpec.FrameworkSource != FrameworkSource.Pods)
			continue;

		var framework = $"{podSpec.FrameworkName}.xcframework";
		var paths = GetDirectories($"{workingDirectory}/Pods/**/{framework}");
		
		foreach (var path in paths)
			CopyDirectory (path, $"./externals/{framework}");
	}
}

void BuildSdkOnPodfile (Artifact artifact)
{
	if (artifact.PodSpecs?.Length == 0)
		return;
	
	var baseArch = Platform.iOSArmV7;
	var platforms = new [] { baseArch, Platform.iOSArm64, Platform.iOSSimulator64, Platform.iOSSimulator };
	var podsProject = "./Pods/Pods.xcodeproj";
	var workingDirectory = (DirectoryPath)$"./externals/{artifact.Id}";

	foreach (var podSpec in artifact.PodSpecs)
	{
		if (podSpec.FrameworkSource != FrameworkSource.Pods)
			continue;

		var framework = $"{podSpec.FrameworkName}.framework";
		var paths = GetDirectories($"{workingDirectory}/Pods/**/{framework}");
		
		if (paths?.Count <= 0) {
			if (!podSpec.CanBeBuild)
				continue;

			BuildXcodeFatFramework (podsProject, podSpec.TargetName, platforms, libraryTitle: podSpec.FrameworkName, workingDirectory: workingDirectory);
			CopyDirectory ($"{workingDirectory}/{framework}", $"./externals/{framework}");
		} else {
			foreach (var path in paths)
				CopyDirectory (path, $"./externals/{framework}");
		}
	}
}

void BuildXcodeFatLibrary (FilePath xcodeProject, string target, Platform [] platforms, string libraryTitle = null, string librarySuffix = null, DirectoryPath workingDirectory = null)
{
	if (!IsRunningOnUnix())
	{
		Warning("{0} is not available on the current platform.", "xcodebuild");
		return;
	}

	libraryTitle = libraryTitle ?? target;
	workingDirectory = workingDirectory ?? Directory("./externals/");
	var libraryFile = (FilePath)(librarySuffix != null ? $"{libraryTitle}.{librarySuffix}" : $"{libraryTitle}");
	var archsFiles = new List<FilePath> ();

	var buildArch = new Action<string, string, FilePath>((sdk, arch, dest) => {
		if (FileExists(dest))
			return;

		XCodeBuild(new XCodeBuildSettings
		{
			Project = workingDirectory.CombineWithFilePath(xcodeProject).ToString(),
			Target = target,
			Sdk = sdk,
			Arch = arch,
			Configuration = "Release",
			Verbose = true
		});

		var outputPath = workingDirectory.Combine("build").Combine($"Release-{sdk}").Combine (target).CombineWithFilePath($"lib{libraryTitle}.a");
		CopyFile(outputPath, dest);
	});

	foreach (var platform in platforms) {
		var archFile = $"{libraryTitle}-{platform.Arch}";
		archsFiles.Add (archFile);
		buildArch (platform.Sdk, platform.Arch, workingDirectory.CombineWithFilePath (archFile));
	}
	
	RunLipoCreate (workingDirectory, libraryTitle, archsFiles.ToArray ());
}

void BuildXcodeFatFramework (FilePath xcodeProject, string target, Platform [] platforms, string libraryTitle = null, string librarySuffix = null, DirectoryPath workingDirectory = null)
{
	if (!IsRunningOnUnix ()) {
		Warning("{0} is not available on the current platform.", "xcodebuild");
		return;
	}

	libraryTitle = libraryTitle ?? target;
	workingDirectory = workingDirectory ?? Directory("./externals/");
	var libraryFile = (FilePath)(librarySuffix != null ? $"{libraryTitle}.{librarySuffix}" : $"{libraryTitle}");
	var fatFramework = (DirectoryPath)$"{libraryTitle}.framework";
	var fatFrameworkPath = workingDirectory.Combine (fatFramework);
	var archsPaths = new List<FilePath> ();

	var buildArch = new Action<string, string, DirectoryPath> ((sdk, arch, dest) => {
		if (DirectoryExists (dest))
			return;

		XCodeBuild (new XCodeBuildSettings {
			Project = workingDirectory.CombineWithFilePath (xcodeProject).ToString (),
			Target = target,
			Sdk = sdk,
			Arch = arch,
			Configuration = "Release",
			Verbose = true
		});

		var outputPath = workingDirectory.Combine ("build").Combine ($"Release-{sdk}").Combine (target).Combine (fatFramework);
		CopyDirectory (outputPath, dest);
	});

	foreach (var platform in platforms) {
		var archPath = (DirectoryPath)$"{libraryTitle}-{platform.Arch}.framework";
		archsPaths.Add (archPath.CombineWithFilePath (libraryTitle));
		buildArch (platform.Sdk, platform.Arch, workingDirectory.Combine (archPath));

		if (!DirectoryExists (fatFrameworkPath))
			CopyDirectory (workingDirectory.Combine (archPath), fatFrameworkPath);
	}
	
	RunLipoCreate (workingDirectory, fatFramework.CombineWithFilePath (libraryFile), archsPaths.ToArray ());

	if (libraryTitle != target && FileExists (fatFrameworkPath.CombineWithFilePath (target)))
		DeleteFile (fatFrameworkPath.CombineWithFilePath (target));
}

bool TargetExistsInXcodeProject (FilePath xcodeProject, string target, DirectoryPath workingDirectory = null)
{
	workingDirectory = workingDirectory ?? Directory("./externals/");

	var processSettings = new ProcessSettings { 
		Arguments = $"-project {workingDirectory.CombineWithFilePath (xcodeProject)} -list",
		RedirectStandardOutput = true
	};

	using(var process = StartAndReturnProcess("xcodebuild", processSettings))
	{
		process.WaitForExit();

		foreach (var line in process.GetStandardOutput ())
			if (line.Contains (target))
				return true;

		return false;
	}
}
