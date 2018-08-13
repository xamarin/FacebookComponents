using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Facebook.MarketingKit {
	// @interface FBSDKAutoLog : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKAutoLog")]
	interface AutoLog {
	}
}
