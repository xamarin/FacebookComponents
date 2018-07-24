#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

SDK_VERSION = "4.28.1";
XAMARIN_FIX_VERSION = "0";
SDK_FULL_VERSION = $"{SDK_VERSION}.{XAMARIN_FIX_VERSION}";

SDK_URL = $"https://origincache.facebook.com/developers/resources/?id=FBAudienceNetwork-{SDK_VERSION}.zip";
SDK_FILE = "FBAudienceNetwork.zip";
SDK_PATH = "./externals/FBAudienceNetwork";
SDK_FRAMEWORK = "FBAudienceNetwork.framework";

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.AudienceNetwork.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.AudienceNetwork/bin/Release/Facebook.AudienceNetwork.dll",
					ToDirectory = "./output/"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
			SolutionPath = "./samples/FBAudienceNetworkSample/FBAudienceNetworkSample.sln",
			Configuration = "Release",
			Platform = "iPhone",
			BuildsOn = BuildPlatforms.Mac }
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AudienceNetwork.iOS.nuspec", Version = SDK_FULL_VERSION, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
