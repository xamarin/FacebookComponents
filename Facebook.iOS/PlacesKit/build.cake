#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

SDK_VERSION = "4.33.0";
XAMARIN_FIX_VERSION = "0";
FULL_VERSION = $"{SDK_VERSION}.{XAMARIN_FIX_VERSION}";

IOS_PLATFORM = "7.0";
IOS_TARGETS = new [] { "FBSDKPlacesKit" };
IOS_PODS = new List<string> {
	"source 'https://github.com/CocoaPods/Specs.git'",
	$"platform :ios, '{IOS_PLATFORM}'",
	"install! 'cocoapods', :integrate_targets => false",
	$"target '{IOS_TARGETS [0]}' do",
	$"\tpod '{IOS_TARGETS [0]}', '{SDK_VERSION}'",
	"end",
};

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.PlacesKit.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.PlacesKit/bin/Release/Facebook.PlacesKit.dll",
					ToDirectory = "./output/"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/PlacesKitSample/PlacesKitSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.PlacesKit.nuspec", Version = FULL_VERSION, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MY_DEPENDENCIES = new [] { "CoreKit" };

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
