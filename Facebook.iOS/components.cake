var FACEBOOK_SDK_VERSION = "5.12.0";

var ACCOUNT_KIT_VERSION      = "5.4.0";
var AUDIENCE_NETWORK_VERSION = "5.6.0";
var CORE_KIT_VERSION         = FACEBOOK_SDK_VERSION;
var FACEBOOK_SDKS_VERSION    = FACEBOOK_SDK_VERSION;
var LOGIN_KIT_VERSION        = FACEBOOK_SDK_VERSION;
var MARKETING_KIT_VERSION    = "5.11.1";
var PLACES_KIT_VERSION       = FACEBOOK_SDK_VERSION;
var SHARE_KIT_VERSION        = FACEBOOK_SDK_VERSION;

// Artifacts available to be built.
Artifact ACCOUNT_KIT_ARTIFACT      = new Artifact ("AccountKit",      ACCOUNT_KIT_VERSION,          "8.0");
Artifact AUDIENCE_NETWORK_ARTIFACT = new Artifact ("AudienceNetwork", AUDIENCE_NETWORK_VERSION,     "9.0");
Artifact CORE_KIT_ARTIFACT         = new Artifact ("CoreKit",         CORE_KIT_VERSION,             "8.0");
Artifact FACEBOOK_SDKS_ARTIFACT    = new Artifact ("FacebookSdks",    $"{FACEBOOK_SDKS_VERSION}.1", "8.0");
Artifact LOGIN_KIT_ARTIFACT        = new Artifact ("LoginKit",        LOGIN_KIT_VERSION,            "8.0");
Artifact MARKETING_KIT_ARTIFACT    = new Artifact ("MarketingKit",    MARKETING_KIT_VERSION,        "8.0");
Artifact PLACES_KIT_ARTIFACT       = new Artifact ("PlacesKit",       $"{PLACES_KIT_VERSION}.1",    "8.0");
Artifact SHARE_KIT_ARTIFACT        = new Artifact ("ShareKit",        $"{SHARE_KIT_VERSION}.1",     "8.0");

var ARTIFACTS = new Dictionary<string, Artifact> {
	{ "AccountKit", ACCOUNT_KIT_ARTIFACT },
	{ "AudienceNetwork", AUDIENCE_NETWORK_ARTIFACT },
	{ "CoreKit", CORE_KIT_ARTIFACT },
	{ "FacebookSdks", FACEBOOK_SDKS_ARTIFACT },
	{ "LoginKit", LOGIN_KIT_ARTIFACT },
	{ "MarketingKit", MARKETING_KIT_ARTIFACT },
	{ "PlacesKit", PLACES_KIT_ARTIFACT },
	{ "ShareKit", SHARE_KIT_ARTIFACT },
};

void SetArtifactsDependencies ()
{
	ACCOUNT_KIT_ARTIFACT.Dependencies      = null;
	AUDIENCE_NETWORK_ARTIFACT.Dependencies = null;
	CORE_KIT_ARTIFACT.Dependencies         = null;
	FACEBOOK_SDKS_ARTIFACT.Dependencies    = new [] { CORE_KIT_ARTIFACT, LOGIN_KIT_ARTIFACT, MARKETING_KIT_ARTIFACT, PLACES_KIT_ARTIFACT, SHARE_KIT_ARTIFACT };
	LOGIN_KIT_ARTIFACT.Dependencies        = new [] { CORE_KIT_ARTIFACT };
	MARKETING_KIT_ARTIFACT.Dependencies    = new [] { CORE_KIT_ARTIFACT };
	PLACES_KIT_ARTIFACT.Dependencies       = new [] { CORE_KIT_ARTIFACT };
	SHARE_KIT_ARTIFACT.Dependencies        = new [] { CORE_KIT_ARTIFACT };
}

void SetArtifactsPodSpecs ()
{
	ACCOUNT_KIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("AccountKit", ACCOUNT_KIT_VERSION)
	};
	AUDIENCE_NETWORK_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FBAudienceNetwork", AUDIENCE_NETWORK_VERSION, frameworkSource: FrameworkSource.Custom)
	};
	CORE_KIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FBSDKCoreKit", CORE_KIT_VERSION)
	};
	FACEBOOK_SDKS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FacebookSdks", FACEBOOK_SDKS_VERSION, frameworkSource: FrameworkSource.Custom)
	};
	LOGIN_KIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FBSDKLoginKit", new Repository ("https://github.com/facebook/facebook-objc-sdk.git", tag: $"v{LOGIN_KIT_VERSION}"))
	};
	MARKETING_KIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FBSDKMarketingKit", MARKETING_KIT_VERSION, canBeBuild: false)
	};
	PLACES_KIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FBSDKPlacesKit", new Repository ("https://github.com/facebook/facebook-objc-sdk.git", tag: $"v{PLACES_KIT_VERSION}"))
	};
	SHARE_KIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FBSDKShareKit", SHARE_KIT_VERSION)
	};
}

void SetArtifactsExtraPodfileLines ()
{
}

void SetArtifactsSamples ()
{
	ACCOUNT_KIT_ARTIFACT.Samples      = new [] { "FBAccountKitSample" };
	AUDIENCE_NETWORK_ARTIFACT.Samples = new [] { "FBAudienceNetworkSample" };
	CORE_KIT_ARTIFACT.Samples         = null;
	FACEBOOK_SDKS_ARTIFACT.Samples    = new [] { "HelloFacebook", "FacebookiOSSample" };
	LOGIN_KIT_ARTIFACT.Samples        = null;
	MARKETING_KIT_ARTIFACT.Samples    = null;
	PLACES_KIT_ARTIFACT.Samples       = null;
	SHARE_KIT_ARTIFACT.Samples        = null;
}
