using ObjCRuntime;

[assembly: LinkWith ("FBSDKCoreKit.a",
		     LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,
		     WeakFrameworks = "Accounts CoreLocation Social Security QuartzCore CoreGraphics UIKit Foundation AudioToolbox",
		     LinkerFlags = "-ObjC",
		     SmartLink = true,
		     ForceLoad = true)]

[assembly: LinkWith ("Bolts.a", 
                     LinkTarget.ArmV7 |  LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, 
                     LinkerFlags = "-ObjC", 
                     SmartLink = true, 
                     ForceLoad = true)]
