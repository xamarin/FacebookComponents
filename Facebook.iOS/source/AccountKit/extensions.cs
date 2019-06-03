using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Facebook.AccountKit
{
    [Preserve(AllMembers = true)]
    public static class Extensions
    {
        public static IViewController AsIViewControllerProtocol(this UIViewController ctrl)
        {
            return ctrl as IViewController ?? Runtime.GetINativeObject<IViewController>(ctrl.Handle, false);
        }
    }
}