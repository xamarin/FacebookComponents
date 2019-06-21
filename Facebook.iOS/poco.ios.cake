class iOSArtifact : Artifact
{
	public string MinimunSupportedVersion { get; set; }
	public string FrameworkName { get; set; }
	public uint BuildOrder { get; set; }

	public iOSArtifact (string id, string version, string minimunSupportedVersion, string nugetVersion = null, string csprojName = null, string frameworkName = null, uint buildOrder = 1, Artifact [] dependencies = null) : base (id, version, nugetVersion, csprojName, dependencies)
	{
		MinimunSupportedVersion = minimunSupportedVersion;
		FrameworkName = frameworkName ?? id;
		BuildOrder = buildOrder;
	}
}