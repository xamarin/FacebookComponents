
#load "../common.cake"

var FB_NUGET_VERSION = "4.14.1";
var AN_NUGET_VERSION = "4.14.1";

var FB_VERSION = "4.14.1";
var FB_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/facebook-android-sdk/{0}/facebook-android-sdk-{0}.aar", FB_VERSION);
var FB_DOCS_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/facebook-android-sdk/{0}/facebook-android-sdk-{0}-javadoc.jar", FB_VERSION);

var AN_VERSION = "4.14.1";
var AN_URL = string.Format ("http://search.maven.org/remotecontent?filepath=com/facebook/android/audience-network-sdk/{0}/audience-network-sdk-{0}.aar", AN_VERSION);

var TARGET = Argument ("t", Argument ("target", "Default"));

var buildSpec = new BuildSpec () {
	Libs = new [] {	
		new DefaultSolutionBuilder {
			SolutionPath = "./Xamarin.Facebook.sln",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Xamarin.Facebook/bin/Release/Xamarin.Facebook.dll",
				},
				new OutputFileCopy {
					FromFile = "./source/Xamarin.Facebook.AudienceNetwork/bin/Release/Xamarin.Facebook.AudienceNetwork.dll",
				}
			}
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./samples/HelloFacebookSample.sln" },
		new DefaultSolutionBuilder { SolutionPath = "./samples/MessengerSendSample.sln" },
		new DefaultSolutionBuilder { SolutionPath = "./samples/AudienceNetworkSample.sln" },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.Android.nuspec", Version = FB_NUGET_VERSION },
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AudienceNetwork.Android.nuspec", Version = AN_NUGET_VERSION },
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component"},
	},
};

Task ("externals")
	.WithCriteria (!FileExists ("./externals/facebook.aar"))
	.Does (() => 
{
	if (!DirectoryExists ("./externals/"))
		CreateDirectory ("./externals");

	// Download the FB aar
	DownloadFile (FB_URL, "./externals/facebook.aar");

	// Download, and unzip the docs .jar
	DownloadFile (FB_DOCS_URL, "./externals/facebook-docs.jar");
	if (!DirectoryExists ("./externals/fb-docs"))
		CreateDirectory ("./externals/fb-docs");
	Unzip ("./externals/facebook-docs.jar", "./externals/fb-docs");

	// Download the FB aar
	DownloadFile (AN_URL, "./externals/audiencenetwork.aar");
});


Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
