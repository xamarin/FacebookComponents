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
using Xamarin.Facebook.AccountKit;

namespace AccountKitSample
{
    [Activity(Label = "LoggedIn")]
    public class LoggedIn : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.LoggedIn);

            var accountKitCallback = new AccountKitCallback<Account>
            {
                HandleSuccess = accountResult =>
                {
                    string email = accountResult.Email;
                    string phone = accountResult.PhoneNumber?.ToString();
                    FindViewById<TextView>(Resource.Id.LogginInText).Text = email ?? phone;
                },
                HandleError = loginError =>
                {
                    Toast.MakeText(
                            this,
                            loginError.UserFacingMessage,
                            ToastLength.Long)
                        .Show();        
                }
            };

            AccountKit.GetCurrentAccount(accountKitCallback);


            FindViewById<Button>(Resource.Id.LogOut).Click += (sender, e) =>
            {
                AccountKit.LogOut();
                StartActivity(typeof(MainActivity));
            };
        }
    }
}