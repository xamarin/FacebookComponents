//
// extensions.cs: Convenience methods.
//
//	Authors:
//		Alex Soto 	(alex.soto@xamarin.com)
//		Israel Soto 	(israel.soto@xamarin.com)
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Foundation;
using ObjCRuntime;

namespace Facebook.AudienceNetwork
{
	public static partial class AdSizes
	{
		static AdSize size320x50;

		[Obsolete ()]
		public static AdSize Size320x50 {
			get {
				Console.WriteLine ("Error: " + Dlfcn.dlerror ());
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				Console.WriteLine ("Error RTLD_MAIN_ONLY: " + Dlfcn.dlerror ());
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSize320x50");
				Console.WriteLine ("Error ptr: " + Dlfcn.dlerror ());
				size320x50 = (AdSize)Marshal.PtrToStructure (ptr, typeof(AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return size320x50;
			}
		}

		static AdSize bannerHeight50;

		public static AdSize BannerHeight50 {
			get {
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeHeight50Banner");
				bannerHeight50 = (AdSize)Marshal.PtrToStructure (ptr, typeof(AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return bannerHeight50;
			}
		}

		static AdSize bannerHeight90;

		public static AdSize BannerHeight90 {
			get {
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeHeight90Banner");
				bannerHeight90 = (AdSize)Marshal.PtrToStructure (ptr, typeof(AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return bannerHeight90;
			}
		}

		static AdSize interstital;

		public static AdSize Interstital {
			get {
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeInterstital");
				interstital = (AdSize)Marshal.PtrToStructure (ptr, typeof(AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return interstital;
			}
		}

		static AdSize rectangleHeight250;

		public static AdSize RectangleHeight250 {
			get {
				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeHeight250Rectangle");
				rectangleHeight250 = (AdSize)Marshal.PtrToStructure (ptr, typeof(AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return rectangleHeight250;
			}
		}
	}
}