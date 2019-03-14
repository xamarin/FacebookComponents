#tool nuget:?package=XamarinComponent&version=1.1.0.65

#addin nuget:?package=Cake.XCode&version=4.0.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.0.1
#addin nuget:?package=Cake.Xamarin&version=3.0.0
#addin nuget:?package=Cake.FileHelpers&version=3.0.0

string [] MY_DEPENDENCIES = null;

string SDK_VERSION = "4.40.0";
string XAMARIN_FIX_VERSION = "0";
string SDK_FULL_VERSION = $"{SDK_VERSION}.{XAMARIN_FIX_VERSION}";

string EXTERNALS_FOLDER_PATH = "./../externals/";
string SDK_FILENAME = "FacebookSDKs";
string SDK_PATH = $"{EXTERNALS_FOLDER_PATH}{SDK_FILENAME}/";
string SDK_ZIPNAME = $"{SDK_FILENAME}.zip";

// Variables for get Facebook binaries from Cocoapods
string IOS_PLATFORM = null;
string [] IOS_TARGETS = null;
List<string> IOS_PODS = null;

// Variables for get Facebook binaries from Official Facebook's URL
string SDK_URL = null;
string [] SDK_FRAMEWORKS = { };
string [] SDK_BUNDLES = { };

Task ("externals")
	.IsDependentOn ("externals-base")
	.Does (() => 
{
	InvokeOtherFacebookModules (MY_DEPENDENCIES, "externals");

	if (IOS_PODS == null && SDK_URL == null)
		return;

	EnsureDirectoryExists (EXTERNALS_FOLDER_PATH);

	if (IOS_PODS != null) {
		if (FileExists ($"{EXTERNALS_FOLDER_PATH}Podfile"))
			return;
		
		if (CocoaPodVersion () < new System.Version (1, 0))
			IOS_PODS.RemoveAt (2);

		FileWriteLines ($"{EXTERNALS_FOLDER_PATH}Podfile", IOS_PODS.ToArray ());

		CocoaPodInstall (EXTERNALS_FOLDER_PATH, new CocoaPodInstallSettings { });
		
		if (DirectoryExists ($"{EXTERNALS_FOLDER_PATH}Pods/FBSDKCoreKit"))
			CopyDirectory ($"{EXTERNALS_FOLDER_PATH}FBSDKCoreKit/FacebookSDKStrings.bundle", $"{EXTERNALS_FOLDER_PATH}FacebookSDKStrings.bundle");

		foreach (var target in IOS_TARGETS)
			BuildXCodeFatLibrary ($"{EXTERNALS_FOLDER_PATH}Pods/Pods.xcodeproj", target, Archs.Simulator | Archs.Simulator64 | Archs.ArmV7 | Archs.Arm64, target, $"{target}.a", null, target);
	} else if (SDK_URL != null) {
		if (FileExists($"{EXTERNALS_FOLDER_PATH}{SDK_FRAMEWORKS [0]}.framework"))
			return;
		
		if (!FileExists($"{EXTERNALS_FOLDER_PATH}{SDK_ZIPNAME}")) {
			DownloadFile (SDK_URL, $"{EXTERNALS_FOLDER_PATH}{SDK_ZIPNAME}", new Cake.Xamarin.Build.DownloadFileSettings { UserAgent = "curl/7.43.0" });
			Unzip ($"{EXTERNALS_FOLDER_PATH}{SDK_ZIPNAME}", SDK_PATH);
		}

		foreach (var framework in SDK_FRAMEWORKS)
			CopyDirectory ($"{SDK_PATH}/{framework}.framework", $"{EXTERNALS_FOLDER_PATH}{framework}.framework");
		
		foreach (var bundle in SDK_BUNDLES)
			CopyDirectory ($"{SDK_PATH}/{bundle}.bundle", $"{EXTERNALS_FOLDER_PATH}{bundle}.bundle");
	}
});

Task ("libs")
	.IsDependentOn("externals")
	.IsDependentOn("ci-setup")
	.Does(() =>
{
	foreach (var lib in buildSpec.Libs) {
		lib.BuildSolution ();
		lib.CopyOutput ();
        }
});

Task ("ci-setup")
	.WithCriteria (!BuildSystem.IsLocalBuild)
	.Does (() => 
{
	var glob = "./**/AssemblyInfo.cs";
	ReplaceTextInFiles(glob, "{SDK_FULL_VERSION}", SDK_FULL_VERSION);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	InvokeOtherFacebookModules (MY_DEPENDENCIES, "clean");

	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", new DeleteDirectorySettings {
			Recursive = true,
			Force = true
		});

	if (DirectoryExists ("../../tmp-nugets"))
		DeleteDirectory ("../../tmp-nugets", new DeleteDirectorySettings {
			Recursive = true,
			Force = true
		});
});

Task ("tmp-nuget").
	IsDependentOn ("libs")
	.Does (() => 
{
	InvokeOtherFacebookModules (MY_DEPENDENCIES, "tmp-nuget");

	if (buildSpec.NuGets == null || buildSpec.NuGets.Length == 0)
		return;

	var newList = new List<NuGetInfo> ();

	foreach (var nuget in buildSpec.NuGets) {
		newList.Add (new NuGetInfo {
			BuildsOn = nuget.BuildsOn,
			NuSpec = nuget.NuSpec,
			RequireLicenseAcceptance = nuget.RequireLicenseAcceptance,
			Version = nuget.Version,
			OutputDirectory = "../../tmp-nugets",
		});
	}

	PackNuGets (newList.ToArray ());
});

Task ("component")
	.IsDependentOn ("nuget")
	.IsDependentOn ("tmp-nuget")
	.IsDependentOn ("component-base");

void InvokeOtherFacebookModules (string [] otherPaths, string target)
{
	if (otherPaths == null)
		return;

	var cakeSettings = new CakeSettings { 
			ToolPath = GetCakeToolPath (),
			Arguments = new Dictionary<string, string> { { "target", target } },
		};

	// Run the script from the subfolder
	foreach (var module in otherPaths)
		CakeExecuteScript ($"../{module}/build.cake", cakeSettings);
}

FilePath GetCakeToolPath ()
{
	var possibleExe = GetFiles ("../../**/tools/Cake/Cake.exe").FirstOrDefault ();

	if (possibleExe != null)
		return possibleExe;
		
	var p = System.Diagnostics.Process.GetCurrentProcess ();  
	return new FilePath (p.Modules[0].FileName);
}
