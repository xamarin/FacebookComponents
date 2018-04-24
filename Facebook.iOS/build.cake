
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

var iosPlatform = "7.0";
var facebookiOSSdkVersion = "4.32.0";
var facebookiOSXamarinFixVersion = "0";
var facebookiOSFullVersion = $"{facebookiOSSdkVersion}.{facebookiOSXamarinFixVersion}";
var facebookMessengerShareKitVersion = "1.3.2";
var boltsVersion = "1.8.4";

var IOS_PODS = new List<string> {
	"source 'https://github.com/CocoaPods/Specs.git'",
	$"platform :ios, '{iosPlatform}'",
	"install! 'cocoapods', :integrate_targets => false",
	"target 'FacebookiOS' do",
	$"\tpod 'FBSDKCoreKit', '{facebookiOSSdkVersion}'",
	$"\tpod 'FBSDKLoginKit', '{facebookiOSSdkVersion}'",
	$"\tpod 'FBSDKShareKit', '{facebookiOSSdkVersion}'",
	$"\tpod 'FBSDKPlacesKit', '{facebookiOSSdkVersion}'",
	$"\tpod 'FBSDKMessengerShareKit', '{facebookMessengerShareKitVersion}'",
	$"\tpod 'Bolts', '{boltsVersion}'",
	"end",
};

string [] IOS_TARGETS = { "Bolts", "FBSDKCoreKit", "FBSDKShareKit", "FBSDKLoginKit", "FBSDKPlacesKit", "FBSDKMessengerShareKit" };

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook/Facebook.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook/bin/unified/Release/Facebook.dll",
					ToDirectory = "./output/unified/"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
			SolutionPath = "./samples/FacebookiOSSample/FacebookiOSSample.sln",
			Configuration = "Release",
			Platform = "iPhone",
			BuildsOn = BuildPlatforms.Mac },

		new IOSSolutionBuilder {
			SolutionPath = "./samples/HelloFacebook/HelloFacebook.sln",
			Configuration = "Release",
			Platform = "iPhone",
			BuildsOn = BuildPlatforms.Mac },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.nuspec", Version = facebookiOSFullVersion, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

Task ("externals")
	.IsDependentOn ("externals-base")
	.WithCriteria (!FileExists ("./externals/FBSDKCoreKit.a"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals");

	if (CocoaPodVersion () < new System.Version (1, 0))
		IOS_PODS.RemoveAt (2);

	FileWriteLines ("./externals/Podfile", IOS_PODS.ToArray ());

	CocoaPodInstall ("./externals", new CocoaPodInstallSettings { });
	
	CopyDirectory ("./externals/Pods/FBSDKCoreKit/FacebookSDKStrings.bundle", "./externals/FacebookSDKStrings.bundle");

	foreach (var target in IOS_TARGETS)
		BuildXCodeFatLibrary ("./Pods/Pods.xcodeproj", target, Archs.Simulator | Archs.Simulator64 | Archs.ArmV7 | Archs.Arm64, target, $"{target}.a", null, target);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
