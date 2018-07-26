#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

SDK_VERSION = "4.32.0";
XAMARIN_FIX_VERSION = "0";
SDK_FULL_VERSION = $"{SDK_VERSION}.{XAMARIN_FIX_VERSION}";

SDK_URL = $"https://origincache.facebook.com/developers/resources/?id=FacebookSDKs-iOS-{SDK_VERSION}.zip";
SDK_FILE = $"FacebookSDKs.zip";
SDK_PATH = $"./externals/FacebookSDKs";
SDK_FRAMEWORK = "AccountKit.framework";

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.AccountKit.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.AccountKit/bin/Release/Facebook.AccountKit.dll",
					ToDirectory = "./output/"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
			SolutionPath = "./samples/FBAccountKitSample/FBAccountKitSample.sln",
			Configuration = "Release",
			Platform = "iPhone",
			BuildsOn = BuildPlatforms.Mac }
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AccountKit.iOS.nuspec", Version = SDK_FULL_VERSION, BuildsOn = BuildPlatforms.Mac },
	},

	Components = new [] {
		new Component { ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac },
	},
};

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
