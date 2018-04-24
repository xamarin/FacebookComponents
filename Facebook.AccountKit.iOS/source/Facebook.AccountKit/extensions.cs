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
            var rv = ctrl as IViewController;
            if (rv != null)
                return rv;
            return Runtime.GetINativeObject<IViewController>(ctrl.Handle, false);
        }
    }
}