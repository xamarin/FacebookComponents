// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
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
        UIKit.UIButton BtnAdCallToAction { get; set; }


        [Outlet]
        UIKit.UIImageView ImgAdIcon { get; set; }


        [Outlet]
        UIKit.UILabel LblAdBody { get; set; }


        [Outlet]
        UIKit.UILabel LblAdSocialContext { get; set; }


        [Outlet]
        UIKit.UILabel LblAdTitle { get; set; }


        [Outlet]
        UIKit.UILabel LblSponsored { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblSocialContext { get; set; }

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

            if (ImgAdIcon != null) {
                ImgAdIcon.Dispose ();
                ImgAdIcon = null;
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

            if (LblSocialContext != null) {
                LblSocialContext.Dispose ();
                LblSocialContext = null;
            }

            if (LblSponsored != null) {
                LblSponsored.Dispose ();
                LblSponsored = null;
            }

            if (View != null) {
                View.Dispose ();
                View = null;
            }
        }
    }
}