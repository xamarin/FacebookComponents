using System;

using UIKit;

using Facebook.AudienceNetwork;

namespace FBAudienceNetworkSample {
	public class CustomNativeAd {
		public NativeAd NativeAd { get; set; }
		public bool IsTemplate { get; set; }
		public UIImage AdImage { get; set; }

		public CustomNativeAd (NativeAd nativeAd, bool isTemplate)
		{
			NativeAd = nativeAd;
			IsTemplate = isTemplate;
		}
	}
}
