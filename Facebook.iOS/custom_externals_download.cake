void DownloadAudienceNetwork (Artifact artifact)
{
	var podSpec = artifact.PodSpecs [0];
	var id = podSpec.Name;
	var version = podSpec.Version;
	var url = $"https://developers.facebook.com/resources/{id}-{version}.zip";
	var basePath = $"./externals/{id}";
	DownloadFile (url, $"{basePath}.zip", new Cake.Xamarin.Build.DownloadFileSettings { UserAgent = "curl/7.43.0" });
	Unzip ($"{basePath}.zip", $"{basePath}");
	CopyDirectory ($"{basePath}/Dynamic/{id}.framework", $"./externals/{id}.framework");
}
