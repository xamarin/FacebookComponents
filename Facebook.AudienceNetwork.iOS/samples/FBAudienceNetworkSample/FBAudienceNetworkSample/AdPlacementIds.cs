using System;

using Facebook.AudienceNetwork; 

namespace FBAudienceNetworkSample {
	public static class AdPlacementIds {
		public const string Banner = "Banner_Placement_Id";
		public const string Interstitial = "Interstitial_Placement_Id";
		public const string Native = "Native_Placement_Id";
		public const string RewardedVideo = "Rewarded_Video_Placement_Id";

		public static void AddTestDevices ()
		{
			AdSettings.LogLevel = AdLogLevel.Log;
			AdSettings.ClearTestDevices ();
			AdSettings.AddTestDevice ("HASH_ID");
		}
	}
}
