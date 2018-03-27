
#load "../common.cake"

var FB_NUGET_VERSION = "4.26.0";
var AN_NUGET_VERSION = "4.26.0";
var AK_NUGET_VERSION = "4.28.0-alpha";

var FB_VERSION = "4.26.0";
var FB_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/facebook-android-sdk/{0}/facebook-android-sdk-{0}.aar", FB_VERSION);
var FB_DOCS_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/facebook-android-sdk/{0}/facebook-android-sdk-{0}-javadoc.jar", FB_VERSION);

var AN_VERSION = "4.26.0";
var AN_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/audience-network-sdk/{0}/audience-network-sdk-{0}.aar", AN_VERSION);

var AK_VERSION = "4.28.0";
var AK_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/account-kit-sdk/{0}/account-kit-sdk-{0}.aar", AN_VERSION);

//AK dependency
var PN_VERSION = "8.5.2";
var PN_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/googlecode/libphonenumber/libphonenumber/{0}/libphonenumber-{0}.jar", PN_VERSION);

var TARGET = Argument ("t", Argument ("target", "Default"));

var buildSpec = new BuildSpec () {
	Libs = new [] {	
		new DefaultSolutionBuilder {
			AlwaysUseMSBuild = true,
			SolutionPath = "./Xamarin.Facebook.sln",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy { FromFile = "./source/Xamarin.Facebook/bin/Release/Xamarin.Facebook.dll" },
				new OutputFileCopy { FromFile = "./source/Xamarin.Facebook.AudienceNetwork/bin/Release/Xamarin.Facebook.AudienceNetwork.dll" },
				new OutputFileCopy { FromFile = "./source/Xamarin.Facebook.AccountKit/bin/Release/Xamarin.Facebook.AccountKit.dll" }				
			}
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./samples/HelloFacebookSample.sln", AlwaysUseMSBuild = true },
		new DefaultSolutionBuilder { SolutionPath = "./samples/MessengerSendSample.sln", AlwaysUseMSBuild = true },
		new DefaultSolutionBuilder { SolutionPath = "./samples/AudienceNetworkSample.sln", AlwaysUseMSBuild = true },
		new DefaultSolutionBuilder { SolutionPath = "./samples/AccountKitSample.sln", AlwaysUseMSBuild = true }		
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.Android.nuspec", Version = FB_NUGET_VERSION },
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AudienceNetwork.Android.nuspec", Version = AN_NUGET_VERSION },
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AccountKit.Android.nuspec", Version = AN_NUGET_VERSION },		
	},

	Components = new [] {
		new Component { ManifestDirectory = "./component" },
	},
};

Task ("externals")
	.WithCriteria (!FileExists ("./externals/facebook.aar"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals/");

	// Download the FB aar
	DownloadFile (FB_URL, "./externals/facebook.aar");

	// Download, and unzip the docs .jar
	DownloadFile (FB_DOCS_URL, "./externals/facebook-docs.jar");
	EnsureDirectoryExists ("./externals/fb-docs");
	Unzip ("./externals/facebook-docs.jar", "./externals/fb-docs");

	// Download the FB AN aar
	DownloadFile (AN_URL, "./externals/audiencenetwork.aar");

	// Download the FB AK aar
	DownloadFile (AK_URL, "./externals/accountkit.aar");

	// Download the Google PN jar
	DownloadFile (PN_URL, "./externals/libphonenumber.jar");
});


Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
