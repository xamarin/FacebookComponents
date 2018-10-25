
#load "../common.cake"

var FB_VERSION = "4.37.0";

var TARGET = Argument ("t", Argument ("target", "Default"));

var ARTIFACTS = new List<ArtifactInfo> {
	new ArtifactInfo("facebook-android-sdk", "4.38.0"),
	new ArtifactInfo("facebook-core", "4.38.0"),
	new ArtifactInfo("facebook-common", "4.38.0"),
	new ArtifactInfo("facebook-login", "4.38.0"),
	new ArtifactInfo("facebook-share", "4.38.0"),
	new ArtifactInfo("facebook-places", "4.38.0"),
	new ArtifactInfo("facebook-applinks", "4.38.0"),
	new ArtifactInfo("facebook-messenger", "4.38.0"),
	new ArtifactInfo("facebook-livestreaming", "4.36.0"),
	new ArtifactInfo("facebook-loginkit", "4.36.0"),
	new ArtifactInfo("facebook-marketing", "4.38.0"),
	// This needs to stay preview until google play services comes out of preview
	new ArtifactInfo("account-kit-sdk", "4.37.0", "4.37.0-preview"),
	new ArtifactInfo("audience-network-sdk", "5.0.1"),
	new ArtifactInfo("notifications", "1.0.2")
};

class ArtifactInfo
{
	public ArtifactInfo(string id, string version, string nugetVersion = null)
	{
		ArtifactId = id;
		Version = version;
		NugetVersion = nugetVersion ?? version;
	}

	public string ArtifactId { get;set; }
	public string Version { get;set; }
	public string NugetVersion { get;set; }
}

Task ("externals")
	.WithCriteria (!FileExists ("./externals/facebook-android-sdk.aar"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals/");

	foreach (var artifact in ARTIFACTS) {
		var url = $"http://search.maven.org/remotecontent?filepath=com/facebook/android/{artifact.ArtifactId}/{artifact.Version}/{artifact.ArtifactId}-{artifact.Version}.aar";
		var docUrl = $"http://search.maven.org/remotecontent?filepath=com/facebook/android/{artifact.ArtifactId}/{artifact.Version}/{artifact.ArtifactId}-{artifact.Version}-javadoc.jar";

		DownloadFile(url, $"./externals/{artifact.ArtifactId}.aar");

		try {
			var localDocsFile = $"./externals/{artifact.ArtifactId}-javadoc.jar";
			DownloadFile(docUrl, localDocsFile);

			EnsureDirectoryExists ($"./externals/{artifact.ArtifactId}-docs/");
			Unzip (localDocsFile, $"./externals/{artifact.ArtifactId}-docs/");
		} catch {}
	}
});

Task ("libs")
	.IsDependentOn("externals")
	.IsDependentOn("ci-setup")
	.Does(() =>
{
	MSBuild("./Xamarin.Facebook.sln", c => 
 		c.SetConfiguration("Release")
 		.WithTarget("Restore"));

	MSBuild("./Xamarin.Facebook.sln", c => 
		c.SetConfiguration("Release")
 		.WithTarget("Build")
		.WithProperty("DesignTimeBuild", "false"));
});

Task ("samples")
	.IsDependentOn("libs")
	.Does(() =>
{
	var samples = new string[] { 
		"./samples/HelloFacebookSample.sln",
		"./samples/MessengerSendSample.sln",
	};

	foreach (var sampleSln in samples) {
		MSBuild(sampleSln, c => 
	 		c.SetConfiguration("Release")
 			.WithTarget("Restore"));

		MSBuild(sampleSln, c => 
			c.SetConfiguration("Release")
			.WithTarget("Build")
			.WithProperty("DesignTimeBuild", "false"));
	}
});

Task ("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	EnsureDirectoryExists("./output");

	foreach (var art in ARTIFACTS) {
		var csproj = "./source/" + art.ArtifactId + "/" + art.ArtifactId + ".csproj";

		MSBuild(csproj, c => 
			c.SetConfiguration("Release")
			.WithProperty("PackageVersion", art.Version)
			.WithProperty("PackageOutputPath", "../../output/")
			.WithProperty("DesignTimeBuild", "false")
 			.WithTarget("Pack"));	
	}
});


Task ("ci-setup")
	.WithCriteria (!BuildSystem.IsLocalBuild)
	.Does (() => 
{
	var buildCommit = "DEV";
	var buildNumber = "DEBUG";
	var buildTimestamp = DateTime.UtcNow.ToString ();

	if (BuildSystem.IsRunningOnJenkins) {
		buildNumber = BuildSystem.Jenkins.Environment.Build.BuildTag;
		buildCommit = EnvironmentVariable("GIT_COMMIT") ?? buildCommit;
	} else if (BuildSystem.IsRunningOnVSTS) {
		buildNumber = BuildSystem.TFBuild.Environment.Build.Number;
		buildCommit = BuildSystem.TFBuild.Environment.Repository.SourceVersion;
	}

	var glob = "./**/AssemblyInfo.cs";

	ReplaceTextInFiles(glob, "{BUILD_COMMIT}", buildCommit);
	ReplaceTextInFiles(glob, "{BUILD_NUMBER}", buildNumber);
	ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", buildTimestamp);
});

Task ("clean")
	.Does (() => 
{
	MSBuild("./Xamarin.Facebook.sln", c => 
		c.SetConfiguration("Release")
 		.WithTarget("Clean"));

	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

RunTarget (TARGET);
