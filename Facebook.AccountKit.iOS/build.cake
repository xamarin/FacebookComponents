
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

var SDK_VERSION = "4.31.0";
var SDK_URL = "https://origincache.facebook.com/developers/resources/?id=facebook-ios-sdk-current.zip";
var SDK_FILE = string.Format ("FacebookSDKs-iOS-{0}.zip", SDK_VERSION);
var SDK_PATH = string.Format ("./externals/FacebookSDKs-iOS-{0}", SDK_VERSION);
var SDK_FRAMEWORK = "AccountKit.framework";

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./source/Facebook.AccountKit/Facebook.AccountKit.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.AccountKit/bin/Release/Facebook.AccountKit.dll",
					ToDirectory = "./output/unified/"
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
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AccountKit.iOS.nuspec", BuildsOn = BuildPlatforms.Mac},
	}
};

Task ("externals")
	.IsDependentOn ("externals-base")
	.WithCriteria (!FileExists ($"./externals/{SDK_FRAMEWORK}"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals");

	DownloadFile (SDK_URL, $"./externals/{SDK_FILE}", new Cake.Xamarin.Build.DownloadFileSettings
	{
		UserAgent = "curl/7.43.0"
	});

	Unzip ($"./externals/{SDK_FILE}", SDK_PATH);

	CopyDirectory ($"{SDK_PATH}/{SDK_FRAMEWORK}", $"./externals/{SDK_FRAMEWORK}");

	DeleteDirectory (SDK_PATH, true);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
