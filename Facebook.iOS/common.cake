#addin nuget:?package=Cake.XCode&version=4.2.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.1.2
#addin nuget:?package=Cake.Xamarin&version=3.0.2
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

#load "poco.cake"

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
	var targetFramework = (DirectoryPath)$"{target}.framework";
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
		});

		var outputPath = workingDirectory.Combine ("build").Combine ($"Release-{sdk}").Combine (target).Combine (targetFramework);
		CopyDirectory (outputPath, dest);
	});

	foreach (var platform in platforms) {
		var archPath = (DirectoryPath)$"{libraryTitle}-{platform.Arch}.framework";
		archsPaths.Add (archPath.CombineWithFilePath (target));
		buildArch (platform.Sdk, platform.Arch, workingDirectory.Combine (archPath));

		if (!DirectoryExists (fatFrameworkPath))
			CopyDirectory (workingDirectory.Combine (archPath), fatFrameworkPath);
	}
	
	RunLipoCreate (workingDirectory, fatFramework.CombineWithFilePath (libraryFile), archsPaths.ToArray ());

	if (libraryTitle != target)
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
