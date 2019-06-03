struct Platform
{
	#region Properties

	public string Arch { get; private set; }
	public string Sdk { get; private set; } 

	public static Platform iOSSimulator { get; } = new Platform ("i386", "iphonesimulator");
	public static Platform iOSSimulator64 { get; } = new Platform ("x86_64", "iphonesimulator");
	public static Platform iOSArmV7 { get; } = new Platform ("armv7", "iphoneos");
	public static Platform iOSArmV7s { get; } = new Platform ("armv7s", "iphoneos");
	public static Platform iOSArm64 { get; } = new Platform ("arm64", "iphoneos");

	#endregion

	#region Constructors

	Platform (string arch, string sdk) {
		Arch = arch;
		Sdk = sdk;
	}

	#endregion

	#region Public Functionality

	public static Platform Create (string arch, string sdk) => new Platform (arch, sdk);
	public override string ToString () => $"{Arch} => {Sdk}";

	#endregion

	#region Operations

		public static bool operator == (Platform first, Platform second) =>
			string.Equals (first.ToString (), second.ToString ());

		public static bool operator != (Platform first, Platform second) =>
			!string.Equals (first.ToString (), second.ToString ());

		public override bool Equals (object obj) =>
			obj is Platform platform && this == platform;

		public override int GetHashCode () =>
			base.GetHashCode ();

	#endregion
}

class Artifact
{
	public Artifact (string id, string version, string minimunSupportedVersion, string nugetVersion = null)
	{
		Id = id;
		Version = version;
		MinimunSupportedVersion = minimunSupportedVersion;
		NugetVersion = nugetVersion ?? version;
	}

	public string Id { get; set; }
	public string Version { get; set; }
	public string NugetVersion { get; set; }
	public string MinimunSupportedVersion { get; set; }
}
