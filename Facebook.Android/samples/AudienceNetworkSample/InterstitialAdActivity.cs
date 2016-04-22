
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
    [Activity (Label = "Interstitial Ad Sample")]
    public class InterstitialAdActivity : Activity, IInterstitialAdListener
    {
        const string TAG = "FB_AUDIENCE_NETWORK";

        InterstitialAd interstitialAd;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.InterstitialAdLayout);

            loadInterstitialAd ();
        }

        void loadInterstitialAd ()
        {
            var placementId = Resources.GetString (Resource.String.fb_placement_id);

            interstitialAd = new InterstitialAd (this, placementId);
            interstitialAd.SetAdListener (this);
            interstitialAd.LoadAd ();
        }

        public void OnInterstitialDismissed (IAd ad)
        {
            Android.Util.Log.Debug (TAG, "Interstitial Ad Dismissed");
        }

        public void OnInterstitialDisplayed (IAd ad)
        {
            Android.Util.Log.Debug (TAG, "Interstitial Ad Displayed");
        }

        public void OnAdClicked (IAd ad)
        {
            Android.Util.Log.Debug (TAG, "Interstitial Ad Clicked");
        }

        public void OnAdLoaded (IAd ad)
        {
            if (interstitialAd != null)
                interstitialAd.Show ();
            
            Android.Util.Log.Debug (TAG, "Interstitial Ad Loaded");
        }

        public void OnError (IAd ad, AdError error)
        {
            Android.Util.Log.Error (TAG, "Interstitial Ad Error: " + error.ErrorMessage);
        }

        protected override void OnDestroy ()
        {
            if (interstitialAd != null) {
                interstitialAd.Destroy ();
            }

            base.OnDestroy ();
        }
    }
}

