using System;
using System.Threading.Tasks;
using UIKit;

using Facebook.AccountKit;
using Foundation;

namespace FBAccountKitSample
{
    public partial class ViewController : UIViewController, IViewControllerDelegate
    {
        public AccountKit accountKit;
        public UIViewController pendingLoginViewController;
        private TaskCompletionSource<string> fbtcs;


        public ViewController(IntPtr handle) : base (handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            if (accountKit == null)
            {
                accountKit = new AccountKit(ResponseType.AccessToken); //Or use Code
            }

            pendingLoginViewController = accountKit.ViewControllerForLoginResume();
            fbtcs = new TaskCompletionSource<string>();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (accountKit.CurrentAccessToken != null)
            {
                PerformSegue("AuthenticatedSegue", null);  
            }
            if(pendingLoginViewController != null)
            {
                PrepareLoginViewController(pendingLoginViewController.AsIViewControllerProtocol());
                UIWindow w = UIApplication.SharedApplication.KeyWindow;
                w.RootViewController.PresentViewController(pendingLoginViewController, true, null);
                pendingLoginViewController = null;
            }
        }

        partial void LoginWithEmail_TouchUpInside(UIButton sender)
        {
            UIViewController loginWithEmailViewController = accountKit.ViewControllerForEmailLogin();
            PrepareLoginViewController(loginWithEmailViewController.AsIViewControllerProtocol());

            UIWindow w = UIApplication.SharedApplication.KeyWindow;

            w.RootViewController.PresentViewController(loginWithEmailViewController, true, null);
        }

        partial void LoginWithPhone_TouchUpInside(UIButton sender)
        {
            UIViewController loginWithPhoneViewController = accountKit.ViewControllerForPhoneLogin();
            PrepareLoginViewController(loginWithPhoneViewController.AsIViewControllerProtocol());
            UIWindow w = UIApplication.SharedApplication.KeyWindow;

            w.RootViewController.PresentViewController(loginWithPhoneViewController, true, null);
        }

        [Export("viewControllerDidCancel:")]
        public void Canceled(UIViewController viewController)
        {
            var CanceledAlertController = UIAlertController.Create("Account Kit Alert", "Facebook Account Kit Login Flow Canceled", UIAlertControllerStyle.Alert);

            CanceledAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(CanceledAlertController, true, null);
            fbtcs.TrySetException(new Exception("Facebook Account Kit Login Flow Canceled"));
        }

        //For server side validation (code)
        //[Export("viewController:didCompleteLoginWithAuthorizationCode:state:")]
        //public void CompletedLoginWithCode(UIViewController viewController, string code, string state)
        //{
        //    Configure for code here
        //}

        [Export("viewController:didCompleteLoginWithAccessToken:state:")]
        public void CompletedLoginWithToken(UIViewController viewController, IAccessToken accessToken, string state)
        {
            if (!string.IsNullOrEmpty(accessToken?.TokenString))
            {
                fbtcs.TrySetResult(accessToken.TokenString);
                PerformSegue("AuthenticatedSegue", null);
            }
            else
            {
                fbtcs.TrySetException(new Exception("Facebook Account Kit Login Flow Failed"));
            }
        }

        [Export("viewController:didFailWithError:")]
        public void FailedWithError(UIViewController viewController, NSError error)
        {
            var errorAlertController = UIAlertController.Create("Account Kit Alert", "Facebook Account Kit Login Flow Errored", UIAlertControllerStyle.Alert);

            errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(errorAlertController, true, null);
            fbtcs.TrySetException(new Exception("Facebook Account Kit Login Flow Errored"));
        }


        private void PrepareLoginViewController(IViewController controller)
        {
            var loginViewController = controller;
            loginViewController.WeakDelegate = this;
        }

    }
}