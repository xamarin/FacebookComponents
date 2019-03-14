#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

SDK_URL = $"https://origincache.facebook.com/developers/resources/?id=FacebookSDKs-iOS-{SDK_VERSION}.zip";
SDK_FRAMEWORKS = new [] { "FBSDKShareKit" };

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.ShareKit.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.ShareKit/bin/Release/Facebook.ShareKit.dll",
					ToDirectory = "./output/"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder { SolutionPath = "./samples/ShareKitSample/ShareKitSample.sln", Configuration = "Release", BuildsOn = BuildPlatforms.Mac }, 
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.ShareKit.iOS.nuspec", Version = SDK_FULL_VERSION, RequireLicenseAcceptance = true, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MY_DEPENDENCIES = new [] { "CoreKit" };

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
