#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

SDK_URL = $"https://origincache.facebook.com/developers/resources/?id=FacebookSDKs-iOS-{SDK_VERSION}.zip";
SDK_FILE = $"FacebookSDKs.zip";
SDK_PATH = $"./externals/FacebookSDKs";
SDK_FRAMEWORKS = new [] { "FBNotifications" };

SDK_VERSION = "1.0.1";
XAMARIN_FIX_VERSION = "1";
SDK_FULL_VERSION = $"{SDK_VERSION}.{XAMARIN_FIX_VERSION}";

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.Notifications.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.Notifications/bin/Release/Facebook.Notifications.dll"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/NotificationsSample/NotificationsSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.Notifications.iOS.nuspec", Version = SDK_FULL_VERSION, RequireLicenseAcceptance = true, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
