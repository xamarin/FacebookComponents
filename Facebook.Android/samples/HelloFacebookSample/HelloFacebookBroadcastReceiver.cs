using System;
using Xamarin.Facebook;
using Android.Content;
using Android.App;

namespace HelloFacebookSample
{
   
//    [ContentProvider (new [] { "com.facebook.app.FacebookContentProvider355198514515820" }, 
//        Name="com.facebook.FacebookContentProvider", 
//        Exported=true)]
    [BroadcastReceiverAttribute]
    [IntentFilterAttribute (new [] { "com.facebook.platform.AppCallResultBroadcast" })]
    public class HelloFacebookBroadcastReceiver : FacebookBroadcastReceiver
    {
        protected override void OnSuccessfulAppCall (string appCallId, string action, Android.OS.Bundle extras)
        {
            Console.WriteLine ("HelloFacebook: Photo uploaded by call {0} succeeded.", appCallId);
        }

        protected override void OnFailedAppCall (string appCallId, string action, Android.OS.Bundle extras)
        {
            Console.WriteLine ("HelloFacebook: Photo uploaded by call {0} failed.", appCallId);
        }
    }
}

