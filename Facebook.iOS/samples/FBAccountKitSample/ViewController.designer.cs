// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace FBAccountKitSample
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginWithEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginWithPhone { get; set; }

        [Action ("LoginWithEmail_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LoginWithEmail_TouchUpInside (UIKit.UIButton sender);

        [Action ("LoginWithPhone_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LoginWithPhone_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (LoginWithEmail != null) {
                LoginWithEmail.Dispose ();
                LoginWithEmail = null;
            }

            if (LoginWithPhone != null) {
                LoginWithPhone.Dispose ();
                LoginWithPhone = null;
            }
        }
    }
}