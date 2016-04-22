// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using System.CodeDom.Compiler;

namespace FBAudienceNetworkSample
{
	[Register ("FBAudienceNetworkSampleViewController")]
	partial class FBAudienceNetworkSampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAudience { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnIntersitial { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblAdViewStatus { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblInterstitalStatusLabel { get; set; }

		[Action ("btnAudience_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnAudience_TouchUpInside (UIButton sender);

		[Action ("btnIntersitial_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnIntersitial_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnAudience != null) {
				btnAudience.Dispose ();
				btnAudience = null;
			}
			if (btnIntersitial != null) {
				btnIntersitial.Dispose ();
				btnIntersitial = null;
			}
			if (lblAdViewStatus != null) {
				lblAdViewStatus.Dispose ();
				lblAdViewStatus = null;
			}
			if (lblInterstitalStatusLabel != null) {
				lblInterstitalStatusLabel.Dispose ();
				lblInterstitalStatusLabel = null;
			}
		}
	}
}
