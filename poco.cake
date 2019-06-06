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

class Artifact : IEquatable<Artifact>
{
	public string Id { get; set; }
	public string Version { get; set; }
	public string NugetVersion { get; set; }
	public string MinimunSupportedVersion { get; set; }
	public string CsprojName { get; set; }
	public uint BuildOrder { get; set; }
	public Artifact [] Dependencies;

	public Artifact (string id, string version, string minimunSupportedVersion, string nugetVersion = null, string csprojName = null, uint buildOrder = 1, Artifact [] dependencies = null)
	{
		Id = id;
		Version = version;
		MinimunSupportedVersion = minimunSupportedVersion;
		NugetVersion = nugetVersion ?? version;
		CsprojName = csprojName ?? id;
		BuildOrder = buildOrder;
		Dependencies = dependencies;
	}

	public bool Equals (Artifact other)
	{
		if (Object.ReferenceEquals(other, null)) return false;
		if (Object.ReferenceEquals(this, other)) return true;

		return Id == other.Id;
	}

	public override int GetHashCode()
	{
		int hashCode = Id.GetHashCode();
		return hashCode ^ hashCode;
	}
}
