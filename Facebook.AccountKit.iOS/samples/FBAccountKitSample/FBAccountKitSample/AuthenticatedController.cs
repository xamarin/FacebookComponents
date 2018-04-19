using System;

using UIKit;

using Facebook.AccountKit;
using Foundation;

namespace FBAccountKitSample
{
    public partial class AuthenticatedController : UIViewController, IViewControllerDelegate
    {
        private AccountKit accountKit;
   
        public AuthenticatedController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if(accountKit == null)
            {
                accountKit = new AccountKit(ResponseType.AccessToken);
            }

            RequestAccountHandler handler = AccountHandlerDelegate;

            accountKit.RequestAccount(handler);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void AccountHandlerDelegate(IAccount account, NSError error)
        {
            if (error != null)
            {
                var errorAlertController = UIAlertController.Create("Account Kit Alert", "Facebook Account Kit Login Flow Errored", UIAlertControllerStyle.Alert);

                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                PresentViewController(errorAlertController, true, null);
            }
            else
            {
                var accountIdAlertController = UIAlertController.Create("Account Kit Alert", $"Account Id: {account.AccountID}", UIAlertControllerStyle.Alert);

                accountIdAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                PresentViewController(accountIdAlertController, true, null);

                Email.Text = account.EmailAddress ?? string.Empty;
                PhoneNumber.Text = account.PhoneNumber.PhoneNumberString ?? string.Empty;
            }
        }

        partial void Logout_TouchUpInside(UIButton sender)
        {
            accountKit?.LogOut();
            NavigationController.PopViewController(true);
        }
    }
}

