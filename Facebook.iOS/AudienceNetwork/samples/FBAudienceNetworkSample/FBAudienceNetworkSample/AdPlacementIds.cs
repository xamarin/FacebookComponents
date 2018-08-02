using System;

using Facebook.AudienceNetwork; 

namespace FBAudienceNetworkSample {
	public static class AdPlacementIds {
		public const string Banner = "765057006871425_1663886213655162";
		public const string Interstitial = "765057006871425_1663885900321860";
		public const string Native = "765057006871425_1663884776988639";
		public const string RewardedVideo = "Rewarded_Video_Placement_Id";

		public static void AddTestDevices ()
		{
			AdSettings.LogLevel = AdLogLevel.Log;
			AdSettings.ClearTestDevices ();
			AdSettings.AddTestDevice ("e8ce6015a7efafb41de74ab35bc0674c38e58304");
		}
	}
}
