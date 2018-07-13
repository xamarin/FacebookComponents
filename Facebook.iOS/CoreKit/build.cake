#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

var IOS_PLATFORM = "7.0";
var FACEBOOK_IOS_SDK_VERSION = "4.33.0";
var FACEBOOK_IOS_XAMARIN_FIX_VERSION = "0";
var FACEBOOK_IOS_FULL_VERSION = $"{FACEBOOK_IOS_SDK_VERSION}.{FACEBOOK_IOS_XAMARIN_FIX_VERSION}";
var BOLTS_VERSION = "1.8.4";

string [] IOS_TARGETS = { "FBSDKCoreKit", "Bolts" };

var IOS_PODS = new List<string> {
	"source 'https://github.com/CocoaPods/Specs.git'",
	$"platform :ios, '{IOS_PLATFORM}'",
	"install! 'cocoapods', :integrate_targets => false",
	$"target '{IOS_TARGETS [0]}' do",
	$"\tpod '{IOS_TARGETS [0]}', '{FACEBOOK_IOS_SDK_VERSION}'",
	$"\tpod '{IOS_TARGETS [1]}', '{BOLTS_VERSION}'",
	"end",
};

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.CoreKit.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.CoreKit/bin/Release/Facebook.CoreKit.dll"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/CoreKitSample/CoreKitSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.CoreKit.nuspec", Version = FACEBOOK_IOS_FULL_VERSION, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
