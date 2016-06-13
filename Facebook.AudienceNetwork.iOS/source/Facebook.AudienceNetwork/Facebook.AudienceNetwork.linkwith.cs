using System;
using System.Reflection;

using ObjCRuntime;
using Foundation;

[assembly: AssemblyVersion ("4.12.0.0")]
[assembly: LinkerSafe]
[assembly: LinkWith ("Facebook.AudienceNetwork.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, Frameworks = "AVFoundation CoreGraphics CoreImage CoreMedia OpenGLES QuartzCore Security StoreKit", WeakFrameworks = "AdSupport CoreMotion SafariServices WebKit", LinkerFlags = "-lc++ -lxml2", SmartLink = true, ForceLoad = true)]
