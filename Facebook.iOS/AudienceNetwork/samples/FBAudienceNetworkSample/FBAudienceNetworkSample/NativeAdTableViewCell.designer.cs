// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FBAudienceNetworkSample
{
	[Register ("NativeAdTableViewCell")]
	partial class NativeAdTableViewCell
	{
		[Outlet]
		Facebook.AudienceNetwork.AdChoicesView AdChoiceView { get; set; }

		[Outlet]
		Facebook.AudienceNetwork.MediaView AdCoverMediaView { get; set; }

		[Outlet]
		Facebook.AudienceNetwork.AdIconView AdIconView { get; set; }

		[Outlet]
		UIKit.UIButton BtnAdCallToAction { get; set; }

		[Outlet]
		UIKit.UILabel LblAdBody { get; set; }

		[Outlet]
		UIKit.UILabel LblAdSocialContext { get; set; }

		[Outlet]
		UIKit.UILabel LblAdTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UILabel LblSocialContext { get; set; }

		[Outlet]
		UIKit.UILabel LblSponsored { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIView View { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AdChoiceView != null) {
				AdChoiceView.Dispose ();
				AdChoiceView = null;
			}

			if (AdCoverMediaView != null) {
				AdCoverMediaView.Dispose ();
				AdCoverMediaView = null;
			}

			if (BtnAdCallToAction != null) {
				BtnAdCallToAction.Dispose ();
				BtnAdCallToAction = null;
			}

			if (AdIconView != null) {
				AdIconView.Dispose ();
				AdIconView = null;
			}

			if (LblAdBody != null) {
				LblAdBody.Dispose ();
				LblAdBody = null;
			}

			if (LblAdSocialContext != null) {
				LblAdSocialContext.Dispose ();
				LblAdSocialContext = null;
			}

			if (LblAdTitle != null) {
				LblAdTitle.Dispose ();
				LblAdTitle = null;
			}

			if (LblSponsored != null) {
				LblSponsored.Dispose ();
				LblSponsored = null;
			}

			if (LblSocialContext != null) {
				LblSocialContext.Dispose ();
				LblSocialContext = null;
			}

			if (View != null) {
				View.Dispose ();
				View = null;
			}
		}
	}
}
