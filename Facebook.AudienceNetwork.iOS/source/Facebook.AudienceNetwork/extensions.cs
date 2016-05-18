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
		static AdSize? size320x50;

		[Obsolete]
		public static AdSize Size320x50 {
			get {
				if (size320x50 != null)
					return size320x50.Value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSize320x50");
				size320x50 = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return size320x50.Value;
			}
		}

		static AdSize? bannerHeight50;

		public static AdSize BannerHeight50 {
			get {
				if (bannerHeight50 != null)
					return bannerHeight50.Value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeHeight50Banner");
				bannerHeight50 = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return bannerHeight50.Value;
			}
		}

		static AdSize? bannerHeight90;

		public static AdSize BannerHeight90 {
			get {
				if (bannerHeight90 != null)
					return bannerHeight90.Value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeHeight90Banner");
				bannerHeight90 = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return bannerHeight90.Value;
			}
		}

		static AdSize? interstital;

		[Obsolete]
		public static AdSize Interstital {
			get {
				if (interstital != null)
					return interstital.Value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeInterstital");
				interstital = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return interstital.Value;
			}
		}

		static AdSize? rectangleHeight250;

		public static AdSize RectangleHeight250 {
			get {
				if (rectangleHeight250 != null)
					return rectangleHeight250.Value;

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "kFBAdSizeHeight250Rectangle");
				rectangleHeight250 = (AdSize)Marshal.PtrToStructure (ptr, typeof (AdSize));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);

				return rectangleHeight250.Value;
			}
		}
	}
}