using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook.Ads;

[assembly: UsesPermission (Android.Manifest.Permission.Internet)]
[assembly: UsesPermission (Android.Manifest.Permission.AccessNetworkState)]
[assembly: MetaData ("com.facebook.sdk.ApplicationId", Value="@string/facebook_app_id")]

namespace AudienceNetworkSample
{
    [Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            AdSettings.AddTestDevice ("767abfa11a47905b3664bea003979b22");

            SetContentView (Resource.Layout.main_activity);

            FindViewById<Button>(Resource.Id.buttonBannerAd).Click += (sender, e) =>
                StartActivity (typeof (BannerAdActivity));

            FindViewById<Button>(Resource.Id.buttonInterstitialAd).Click += (sender, e) =>
                StartActivity (typeof (InterstitialAdActivity));

            FindViewById<Button>(Resource.Id.buttonNativeAd).Click += (sender, e) =>
                StartActivity (typeof (NativeAdActivity));
        }
    }
}


