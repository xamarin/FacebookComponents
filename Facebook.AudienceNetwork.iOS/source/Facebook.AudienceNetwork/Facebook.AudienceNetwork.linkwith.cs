using System;
using System.Reflection;

using ObjCRuntime;
using Foundation;

[assembly: AssemblyVersion ("4.10.0.0")]
[assembly: LinkerSafe]
[assembly: LinkWith ("Facebook.AudienceNetwork.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, Frameworks = "AdSupport AVFoundation CoreImage CoreMedia CoreMotion OpenGLES QuartzCore Security StoreKit", SmartLink = true, ForceLoad = true)]
