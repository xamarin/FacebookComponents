var FACEBOOK_SDK_VERSION = "5.6.0";

var ACCOUNT_KIT_VERSION      = "5.4.0";
var AUDIENCE_NETWORK_VERSION = "5.3.2";
var CORE_KIT_VERSION         = FACEBOOK_SDK_VERSION;
var FACEBOOK_SDKS_VERSION    = FACEBOOK_SDK_VERSION;
var LOGIN_KIT_VERSION        = FACEBOOK_SDK_VERSION;
var MARKETING_KIT_VERSION    = "5.5.0";
var PLACES_KIT_VERSION       = FACEBOOK_SDK_VERSION;
var SHARE_KIT_VERSION        = FACEBOOK_SDK_VERSION;

// Artifacts available to be built.
Artifact ACCOUNT_KIT_ARTIFACT      = new Artifact ("AccountKit",      ACCOUNT_KIT_VERSION,      "8.0");
Artifact AUDIENCE_NETWORK_ARTIFACT = new Artifact ("AudienceNetwork", AUDIENCE_NETWORK_VERSION, "9.0");
Artifact CORE_KIT_ARTIFACT         = new Artifact ("CoreKit",         CORE_KIT_VERSION,         "8.0");
Artifact FACEBOOK_SDKS_ARTIFACT    = new Artifact ("FacebookSdks",    FACEBOOK_SDKS_VERSION,    "8.0");
Artifact LOGIN_KIT_ARTIFACT        = new Artifact ("LoginKit",        LOGIN_KIT_VERSION,        "8.0");
Artifact MARKETING_KIT_ARTIFACT    = new Artifact ("MarketingKit",    MARKETING_KIT_VERSION,    "8.0");
Artifact PLACES_KIT_ARTIFACT       = new Artifact ("PlacesKit",       PLACES_KIT_VERSION,       "8.0");
Artifact SHARE_KIT_ARTIFACT        = new Artifact ("ShareKit",        SHARE_KIT_VERSION,        "8.0");

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
		new PodSpec ("AccountKit", ACCOUNT_KIT_VERSION)
	};
	AUDIENCE_NETWORK_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FBAudienceNetwork", AUDIENCE_NETWORK_VERSION, frameworkSource: FrameworkSource.Custom)
	};
	CORE_KIT_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FBSDKCoreKit", CORE_KIT_VERSION)
	};
	FACEBOOK_SDKS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FacebookSdks", FACEBOOK_SDKS_VERSION, frameworkSource: FrameworkSource.Custom)
	};
	LOGIN_KIT_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FBSDKLoginKit", LOGIN_KIT_VERSION)
	};
	MARKETING_KIT_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FBSDKMarketingKit", MARKETING_KIT_VERSION)
	};
	PLACES_KIT_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FBSDKPlacesKit", PLACES_KIT_VERSION)
	};
	SHARE_KIT_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FBSDKShareKit", SHARE_KIT_VERSION)
	};
}

void SetArtifactsExtraPodfileLines ()
{
	PLACES_KIT_ARTIFACT.ExtraPodfileLines = new [] {	
		"=begin",
		"This override the source.git version,",
		"in order to be able to build the most recent version using Pods.",
		"=end",
		"pre_install do |installer|",
		"\tinstaller.pod_targets.each do |pod|",
		"\t\tdef pod.source.tag?;",
		"\t\t\tv5.6.0",
		"\t\tend",
		"\tend",
		"end",
	};
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
