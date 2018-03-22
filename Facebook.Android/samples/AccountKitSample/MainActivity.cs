using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook.AccountKit;
using Xamarin.Facebook.AccountKit.UI;

namespace AccountKitSample
{
    [Activity(Label = "AccountKitSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private AccessToken accessToken;
        int APP_REQUEST_CODE = 99;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            accessToken = AccountKit.CurrentAccessToken;

            if (accessToken != null)
            {
                StartActivity (typeof (LoggedIn));
            }
            else
            {
                FindViewById<Button>(Resource.Id.buttonLogInSms).Click += delegate
                {
                    Intent intent = new Intent(this, typeof(AccountKitActivity));
                    AccountKitConfiguration.AccountKitConfigurationBuilder configurationBuilder =
                        new AccountKitConfiguration.AccountKitConfigurationBuilder(
                            LoginType.Phone,
                            AccountKitActivity.ResponseType.Token); // or .ResponseType.Code for server side flow
                    // ... perform additional configuration ...
                    intent.PutExtra(
                        AccountKitActivity.AccountKitActivityConfiguration,
                        configurationBuilder.Build());
                    StartActivityForResult(intent, APP_REQUEST_CODE);
                };

                FindViewById<Button>(Resource.Id.buttonLogInEmail).Click += delegate
                {
                    GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
                    Intent intent = new Intent(this, typeof(AccountKitActivity));
                    AccountKitConfiguration.AccountKitConfigurationBuilder configurationBuilder =
                        new AccountKitConfiguration.AccountKitConfigurationBuilder(
                            LoginType.Email,
                            AccountKitActivity.ResponseType.Token); // or .ResponseType.Code for server flow
                    // ... perform additional configuration ...
                    intent.PutExtra(
                        AccountKitActivity.AccountKitActivityConfiguration,
                        configurationBuilder.Build());
                    StartActivityForResult(intent, APP_REQUEST_CODE);
                };
            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == APP_REQUEST_CODE)
            {
                // confirm that this response matches your request
                AccountKitLoginResult loginResult = data.GetParcelableExtra(AccountKitLoginResult.ResultKey) as AccountKitLoginResult;
                string toastMessage;
                if (loginResult.Error != null)
                {
                    toastMessage = loginResult.Error.ErrorType.Message;
                }
                else if (loginResult.WasCancelled())
                {
                    toastMessage = "Login Cancelled";
                }
                else
                {
                    if (loginResult.AccessToken != null)
                    {
                        toastMessage = "Success:" + loginResult.AccessToken.AccountId;
                    }
                    else
                    {
                        toastMessage = $"Success:{loginResult.AuthorizationCode.Substring(0, 10)}s...";
                    }

                    // If you have an authorization code, retrieve it from
                    // loginResult.getAuthorizationCode()
                    // and pass it to your server and exchange it for an access token.

                    // Success! Start your next activity...
                    StartActivity(typeof(LoggedIn));
                }

                // Surface the result to your user in an appropriate way.
                Toast.MakeText(
                        this,
                        toastMessage,
                        ToastLength.Long)
                    .Show();
            }
        }

    }
}

