using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook.Messenger;

[assembly: MetaData ("com.facebook.sdk.ApplicationId", Value="@string/facebook_app_id")]

namespace MessengerSendSample
{
    [Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
    [IntentFilter (new [] { Intent.ActionPick }, 
        Categories = new [] { Intent.CategoryDefault, "com.facebook.orca.category.PLATFORM_THREAD_20150311" })]
    [IntentFilter (new [] { Intent.ActionPick }, 
        Categories = new [] { Intent.CategoryDefault, "com.facebook.orca.category.PLATFORM_THREAD_20150314" })]
    public class MainActivity : Activity
    {
        // This is the request code that the SDK uses for startActivityForResult. See the code below
        // that references it. Messenger currently doesn't return any data back to the calling
        // application.0
        const int REQUEST_CODE_SHARE_TO_MESSENGER = 1;


        Android.Support.V7.Widget.Toolbar toolbar;
        View messengerButton;
        MessengerThreadParams threadParams;
        bool picking;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            Xamarin.Facebook.FacebookSdk.SdkInitialize (this);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.main_activity);

            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
            messengerButton = FindViewById<View> (Resource.Id.messenger_send_button);

            toolbar.SetTitle (Resource.String.app_name);

            if (this.Intent.Action == Intent.ActionPick) {
                threadParams = MessengerUtils.GetMessengerThreadParamsForIntent (this.Intent);
                picking = true;
            }

            messengerButton.Click += MessengerButton_Click;
        }

        void MessengerButton_Click (object sender, EventArgs e)
        {
            // The URI can reference a file://, content://, or android.resource. Here we use
            // android.resource for sample purposes.
            var uri = Android.Net.Uri.Parse ("android.resource://com.facebook.samples.messenger.send/" + Resource.Drawable.tree);

            // Create the parameters for what we want to send to Messenger.
            var shareToMessengerParams = ShareToMessengerParams.NewBuilder (uri, "image/jpeg")
                .SetMetaData ("{ \"image\" : \"tree\" }")
                .Build ();

            if (picking) {
                // If we were launched from Messenger, we call MessengerUtils.finishShareToMessenger to return
                // the content to Messenger.
                MessengerUtils.FinishShareToMessenger (this, shareToMessengerParams);
            } else {
                // Otherwise, we were launched directly (for example, user clicked the launcher icon). We
                // initiate the broadcast flow in Messenger. If Messenger is not installed or Messenger needs
                // to be upgraded, this will direct the user to the play store.
                MessengerUtils.ShareToMessenger (this,
                    REQUEST_CODE_SHARE_TO_MESSENGER,
                    shareToMessengerParams);
            }
        }
    }
}


