
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook.Ads;

namespace AudienceNetworkSample
{
    [Activity (Label = "Native Ad Sample")]
    public class NativeAdActivity : Activity, IAdListener
    {
        const string TAG = "FB_AUDIENCE_NETWORK";

        LinearLayout  nativeAdContainer;
        LinearLayout  adView;
        AdChoicesView adChoicesView;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Create your application here
            SetContentView (Resource.Layout.NativeAdLayout);

            showNativeAd ();
        }

        NativeAd nativeAd;

        void showNativeAd ()
        {
            var placementId = Resources.GetString (Resource.String.fb_placement_id);

            nativeAd = new NativeAd(this, placementId);
            nativeAd.SetAdListener (this);

            nativeAd.LoadAd ();
        }

        public void OnAdClicked (IAd ad)
        {
            Android.Util.Log.Debug (TAG, "Native Ad Clicked");
        }

        public void OnAdLoaded (IAd ad)
        {
            Android.Util.Log.Debug (TAG, "Native Ad Loaded");

            if (ad != nativeAd) {
                return;
            }

            // Add ad into the ad container.
            nativeAdContainer = FindViewById<LinearLayout> (Resource.Id.native_ad_container);

            var inflater = LayoutInflater.From (this);
            adView = (LinearLayout)inflater.Inflate (Resource.Layout.NativeAdView, nativeAdContainer, false);
            nativeAdContainer.AddView (adView);

            // Create native UI using the ad metadata.
            var nativeAdIcon = adView.FindViewById<ImageView> (Resource.Id.native_ad_icon);
            var nativeAdTitle = adView.FindViewById<TextView> (Resource.Id.native_ad_title);
            var nativeAdBody = adView.FindViewById<TextView> (Resource.Id.native_ad_body);
            var nativeAdMedia = adView.FindViewById<MediaView> (Resource.Id.native_ad_media);
            var nativeAdSocialContext = adView.FindViewById<TextView> (Resource.Id.native_ad_social_context);
            var nativeAdCallToAction = adView.FindViewById<Button> (Resource.Id.native_ad_call_to_action);

            // Setting the Text.
            nativeAdSocialContext.Text = nativeAd.AdSocialContext;
            nativeAdCallToAction.Text = nativeAd.AdCallToAction;
            nativeAdTitle.Text = nativeAd.AdTitle;
            nativeAdBody.Text = nativeAd.AdBody;

            // Downloading and setting the ad icon.
            var adIcon = nativeAd.AdIcon;
            NativeAd.DownloadAndDisplayImage (adIcon, nativeAdIcon);

            // Download and setting the cover image.
            var adCoverImage = nativeAd.AdCoverImage;
            nativeAdMedia.SetNativeAd (nativeAd);

            // Add adChoices icon
            if (adChoicesView == null) { 
                adChoicesView = new AdChoicesView (this, nativeAd, true);
                adView.AddView (adChoicesView, 0);
            }

            nativeAd.RegisterViewForInteraction (adView);
        }

        public void OnError (IAd ad, AdError error)
        {
            Android.Util.Log.Error (TAG, "Native Ad Error: " + error.ErrorMessage);
        }
    }
}

