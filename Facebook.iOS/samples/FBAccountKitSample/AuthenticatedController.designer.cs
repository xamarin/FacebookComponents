// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FBAccountKitSample
{
    [Register ("AuthenticatedController")]
    partial class AuthenticatedController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Email { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Logout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PhoneNumber { get; set; }

        [Action ("Logout_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Logout_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Email != null) {
                Email.Dispose ();
                Email = null;
            }

            if (Logout != null) {
                Logout.Dispose ();
                Logout = null;
            }

            if (PhoneNumber != null) {
                PhoneNumber.Dispose ();
                PhoneNumber = null;
            }
        }
    }
}