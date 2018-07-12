#tool nuget:?package=XamarinComponent&version=1.1.0.65

#addin nuget:?package=Cake.XCode&version=4.0.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.0.1
#addin nuget:?package=Cake.Xamarin&version=3.0.0
#addin nuget:?package=Cake.FileHelpers&version=3.0.0

string [] MyDependencies = null;

Task ("externals")
	.IsDependentOn ("externals-base")
	.WithCriteria (!FileExists ("./externals/FBSDKLoginKit.a"))
	.Does (() => 
{
	InvokeOtherFacebookModules (MyDependencies, "externals");

	EnsureDirectoryExists ("./externals");

	if (CocoaPodVersion () < new System.Version (1, 0))
		IOS_PODS.RemoveAt (2);

	FileWriteLines ("./externals/Podfile", IOS_PODS.ToArray ());

	CocoaPodInstall ("./externals", new CocoaPodInstallSettings { });
	
	if (DirectoryExists ("./externals/Pods/FBSDKCoreKit"))
		CopyDirectory ("./externals/Pods/FBSDKCoreKit/FacebookSDKStrings.bundle", "./externals/FacebookSDKStrings.bundle");

	foreach (var target in IOS_TARGETS)
		BuildXCodeFatLibrary ("./Pods/Pods.xcodeproj", target, Archs.Simulator | Archs.Simulator64 | Archs.ArmV7 | Archs.Arm64, target, $"{target}.a", null, target);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	InvokeOtherFacebookModules (MyDependencies, "clean");

	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", new DeleteDirectorySettings {
			Recursive = true,
			Force = true
		});
});

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
