
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
    [Activity (Label = "Banner Ad Sample")]
    public class BannerAdActivity : Activity
    {
        AdView adView;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.BannerAdLayout);

            var placementId = Resources.GetString (Resource.String.fb_placement_id);

            // Instantiate an AdView view
            adView = new AdView(this, placementId, AdSize.BannerHeight90);

            // Find the main layout of your activity
            var layout = FindViewById<LinearLayout> (Resource.Id.container);

            // Add the ad view to your activity layout
            layout.AddView (adView);

            // Request to load an ad    
            adView.LoadAd ();
        }
    }
}

