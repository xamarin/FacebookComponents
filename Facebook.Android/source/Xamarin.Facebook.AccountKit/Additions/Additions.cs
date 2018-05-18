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

namespace Xamarin.Facebook.AccountKit
{
    public class AccountKitCallback<T> : Java.Lang.Object, IAccountKitCallback where T : Java.Lang.Object
    {
        public Action<AccountKitError> HandleError { get; set; }
        public Action<T> HandleSuccess { get; set; }

        public void OnError(AccountKitError error)
        {
            HandleError?.Invoke(error);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            HandleSuccess?.Invoke(result.JavaCast<T>());
        }
    }
}

namespace Xamarin.Facebook.AccountKit.UI
{
    //Adding to the AccountKitLoginResult implementation instead of using the parallel class that the Java binding created, this came from the interface.
    public partial class AccountKitLoginResult: global::Java.Lang.Object
    {
        [Register("RESULT_KEY")]
        public const string ResultKey = (string)"account_kit_log_in_result";
    }

    //Not including because it is now obsolete, also it is part of a different namespace. Not worth dealing with.
    //[Register("com/facebook/accountkit/AccountKitLoginResult", DoNotGenerateAcw = true)]
    //[global::System.Obsolete("Use the 'AccountKitLoginResult' type. This type will be removed in a future release.")]
    //public abstract class AccountKitLoginResultConsts : AccountKitLoginResult
    //{

    //    private AccountKitLoginResultConsts()
    //    {
    //    }
    //}
}