
#load "../common.cake"

var SDK_DATE = "20160412";
var SDK_VERSION = "4.12.0";
var SDK_URL = string.Format ("https://origincache.facebook.com/developers/resources/?id=FacebookSDKs-iOS-{0}.zip", SDK_VERSION);
var SDK_FILE = "FacebookSDKs-iOS.zip";
var SDK_PATH = "./externals/FacebookSDKs";

var TARGET = Argument ("t", Argument ("target", "Default"));

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
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
		new IOSSolutionBuilder { SolutionPath = "./samples/FacebookiOSSample/FacebookiOSSample.sln", BuildsOn = BuildPlatforms.Mac },
		new IOSSolutionBuilder { SolutionPath = "./samples/HelloFacebook/HelloFacebook.sln", BuildsOn = BuildPlatforms.Mac },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.nuspec", BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

Task ("externals")
	.WithCriteria (!FileExists ("./externals/FBSDKCoreKit.a"))
	.Does (() => 
{
	if (!DirectoryExists ("./externals/"))
		CreateDirectory ("./externals");

	DownloadFile (SDK_URL, "./externals/" + SDK_FILE, new DownloadFileSettings
	{
		UserAgent = "curl/7.43.0"
	});

	Unzip ("./externals/" + SDK_FILE, SDK_PATH);

	CopyFile (SDK_PATH + "/Bolts.framework/Bolts", "./externals/Bolts.a");
	CopyFile (SDK_PATH + "/FBSDKCoreKit.framework/FBSDKCoreKit", "./externals/FBSDKCoreKit.a");
	CopyFile (SDK_PATH + "/FBSDKLoginKit.framework/FBSDKLoginKit", "./externals/FBSDKLoginKit.a");
	CopyFile (SDK_PATH + "/FBSDKMessengerShareKit.framework/FBSDKMessengerShareKit", "./externals/FBSDKMessengerShareKit.a");
	CopyFile (SDK_PATH + "/FBSDKShareKit.framework/FBSDKShareKit", "./externals/FBSDKShareKit.a");

	CopyDirectory (SDK_PATH + "/FacebookSDKStrings.bundle", "./externals/FacebookSDKStrings.bundle");

	DeleteDirectory (SDK_PATH, true);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
