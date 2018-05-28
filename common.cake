#tool nuget:?package=XamarinComponent&version=1.1.0.65

#addin nuget:?package=Cake.XCode&version=4.0.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.0.1
#addin nuget:?package=Cake.Xamarin&version=3.0.0
#addin nuget:?package=Cake.FileHelpers&version=3.0.0

enum Archs : uint
{
	Simulator = 1 << 0,
	Simulator64 = 1 << 1,
	ArmV7 = 1 << 2,
	ArmV7s = 1 << 3,
	Arm64 = 1 << 4
}

void BuildXCodeFatLibrary(FilePath xcodeProject, string target, string libraryTitle = null, FilePath fatLibrary = null, DirectoryPath workingDirectory = null, string targetFolderName = null)
{
	BuildXCodeFatLibrary(xcodeProject, target, Archs.Simulator | Archs.Simulator64 | Archs.ArmV7 | Archs.ArmV7s | Archs.Arm64, libraryTitle, fatLibrary, workingDirectory, targetFolderName);
}

void BuildXCodeFatLibrary(FilePath xcodeProject, string target, Archs archs, string libraryTitle = null, FilePath fatLibrary = null, DirectoryPath workingDirectory = null, string targetFolderName = null)
{
	if (!IsRunningOnUnix())
	{
		Warning("{0} is not available on the current platform.", "xcodebuild");
		return;
	}

	libraryTitle = libraryTitle ?? target;
	fatLibrary = fatLibrary ?? string.Format("lib{0}.a", libraryTitle);
	workingDirectory = workingDirectory ?? Directory("./externals/");

	var output = string.Format("lib{0}.a", libraryTitle);
	var i386 = string.Format("lib{0}-i386.a", libraryTitle);
	var x86_64 = string.Format("lib{0}-x86_64.a", libraryTitle);
	var armv7 = string.Format("lib{0}-armv7.a", libraryTitle);
	var armv7s = string.Format("lib{0}-armv7s.a", libraryTitle);
	var arm64 = string.Format("lib{0}-arm64.a", libraryTitle);

	var buildArch = new Action<string, string, FilePath>((sdk, arch, dest) => {
		if (!FileExists(dest))
		{
			XCodeBuild(new XCodeBuildSettings
			{
				Project = workingDirectory.CombineWithFilePath(xcodeProject).ToString(),
				Target = target,
				Sdk = sdk,
				Arch = arch,
				Configuration = "Release",
			});
			var tmpOutputPath = workingDirectory.Combine("build").Combine("Release-" + sdk);
			if (!string.IsNullOrEmpty (targetFolderName))
				tmpOutputPath = tmpOutputPath.Combine (targetFolderName);
			var outputPath = tmpOutputPath.CombineWithFilePath(output);

			CopyFile(outputPath, dest);
		}
	});

        var archsPathsBuilt = new List<FilePath> ();

        if ((archs & Archs.Simulator) == Archs.Simulator) {
		archsPathsBuilt.Add (i386);
                buildArch("iphonesimulator", "i386", workingDirectory.CombineWithFilePath(i386));
        }
	if ((archs & Archs.Simulator64) == Archs.Simulator64) {
                archsPathsBuilt.Add (x86_64);
		buildArch("iphonesimulator", "x86_64", workingDirectory.CombineWithFilePath(x86_64));
        }
	
        if ((archs & Archs.ArmV7) == Archs.ArmV7) {
                archsPathsBuilt.Add (armv7);
		buildArch("iphoneos", "armv7", workingDirectory.CombineWithFilePath(armv7));
        }
	if ((archs & Archs.ArmV7s) == Archs.ArmV7s) {
                archsPathsBuilt.Add (armv7s);
		buildArch("iphoneos", "armv7s", workingDirectory.CombineWithFilePath(armv7s));
        }
	if ((archs & Archs.Arm64) == Archs.Arm64) {
                archsPathsBuilt.Add (arm64);
		buildArch("iphoneos", "arm64", workingDirectory.CombineWithFilePath(arm64));
        }
	
	RunLipoCreate(workingDirectory, fatLibrary, archsPathsBuilt.ToArray ());
}