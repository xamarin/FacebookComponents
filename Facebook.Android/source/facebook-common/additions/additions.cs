using Android.Runtime;
using System;
using System.Linq;

namespace Xamarin.Facebook.Share.Model
{
	public partial class ShareContent
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareContent;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareContent;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}


			//// This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
			//global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
			//{
			//    return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
			//}

			static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public global::Xamarin.Facebook.Share.Model.ShareContent.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;");
				global::Xamarin.Facebook.Share.Model.ShareContent.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareContent.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}

	public partial class ShareMedia
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareMedia;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareMedia;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}


			//// This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
			//global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
			//{
			//    return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
			//}

			static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;", "")]
			public global::Xamarin.Facebook.Share.Model.ShareMedia.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
				global::Xamarin.Facebook.Share.Model.ShareMedia.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareMedia.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}

	public partial class ShareOpenGraphValueContainer
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareOpenGraphValueContainer;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareOpenGraphValueContainer;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}

			//// This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
			//global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
			//{
			//    return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
			//}

			static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "")]
			public global::Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;");
				global::Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}

	public partial class ShareMessengerActionButton
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareMessengerActionButton;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareMessengerActionButton;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}


			//// This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
			//global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
			//{
			//    return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
			//}

			static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", "")]
			public global::Xamarin.Facebook.Share.Model.ShareMessengerActionButton.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
				global::Xamarin.Facebook.Share.Model.ShareMessengerActionButton.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareMessengerActionButton.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}
}

namespace Xamarin.Facebook.Share.Widget
{
	//public partial class DeviceShareButton
	//{
	//	static IntPtr id_setEnabled_Z;
	//	// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.widget']/class[@name='DeviceShareButton']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
	//	[Register("setEnabled", "(Z)V", "")]
	//	public unsafe void SetEnabled(bool enabled)
	//	{
	//		if (id_setEnabled_Z == IntPtr.Zero)
	//			id_setEnabled_Z = JNIEnv.GetMethodID(class_ref, "setEnabled", "(Z)V");
	//		try
	//		{
	//			JValue* __args = stackalloc JValue[1];
	//			__args[0] = new JValue(enabled);
	//			JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setEnabled_Z, __args);
	//		}
	//		finally
	//		{
	//		}
	//	}
	//}

//	public partial class LikeView
//	{
//		static Delegate cb_setEnabled_Z;
//#pragma warning disable 0169
//		static Delegate GetSetEnabled_ZHandler()
//		{
//			if (cb_setEnabled_Z == null)
//				cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
//			return cb_setEnabled_Z;
//		}

//		static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
//		{
//			global::Xamarin.Facebook.Share.Widget.LikeView __this = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Widget.LikeView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			__this.SetEnabled(enabled);
//		}
//#pragma warning restore 0169

//		static IntPtr id_setEnabled_Z;
//		// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.widget']/class[@name='LikeView']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
//		[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
//		public unsafe void SetEnabled(bool enabled)
//		{
//			if (id_setEnabled_Z == IntPtr.Zero)
//				id_setEnabled_Z = JNIEnv.GetMethodID(class_ref, "setEnabled", "(Z)V");
//			try
//			{
//				JValue* __args = stackalloc JValue[1];
//				__args[0] = new JValue(enabled);

//				if (GetType() == ThresholdType)
//					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setEnabled_Z, __args);
//				else
//					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setEnabled", "(Z)V"), __args);
//			}
//			finally
//			{
//			}
//		}
//	}


//	public partial class ShareButtonBase
//	{
//		static Delegate cb_setEnabled_Z;
//#pragma warning disable 0169
//		static Delegate GetSetEnabled_ZHandler()
//		{
//			if (cb_setEnabled_Z == null)
//				cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
//			return cb_setEnabled_Z;
//		}

//		static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
//		{
//			global::Xamarin.Facebook.Share.Widget.ShareButtonBase __this = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Widget.ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			__this.SetEnabled(enabled);
//		}
//#pragma warning restore 0169

	//	static IntPtr id_setEnabled_Z;
	//	// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.widget']/class[@name='ShareButtonBase']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
	//	[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
	//	public unsafe void SetEnabled(bool enabled)
	//	{
	//		if (id_setEnabled_Z == IntPtr.Zero)
	//			id_setEnabled_Z = JNIEnv.GetMethodID(class_ref, "setEnabled", "(Z)V");
	//		try
	//		{
	//			JValue* __args = stackalloc JValue[1];
	//			__args[0] = new JValue(enabled);

	//			if (GetType() == ThresholdType)
	//				JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setEnabled_Z, __args);
	//			else
	//				JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setEnabled", "(Z)V"), __args);
	//		}
	//		finally
	//		{
	//		}
	//	}
	//}

	//public partial class AppInviteDialog
	//{
	//	protected override global::System.Collections.IList _OrderedModeHandlers()
	//	{
	//		return OrderedModeHandlers.ToList();
	//	}
	//}

	//public partial class CreateAppGroupDialog
	//{
	//	protected override global::System.Collections.IList _OrderedModeHandlers()
	//	{
	//		return OrderedModeHandlers.ToList();
	//	}
	//}

	//public partial class GameRequestDialog
	//{
	//	protected override global::System.Collections.IList _OrderedModeHandlers()
	//	{
	//		return OrderedModeHandlers.ToList();
	//	}
	//}

	//public partial class JoinAppGroupDialog
	//{
	//	protected override global::System.Collections.IList _OrderedModeHandlers()
	//	{
	//		return OrderedModeHandlers.ToList();
	//	}
	//}

	//public partial class MessageDialog
	//{
	//	protected override global::System.Collections.IList _OrderedModeHandlers()
	//	{
	//		return OrderedModeHandlers.ToList();
	//	}
	//}

	public partial class ShareDialog
	{
		//public bool ShouldFailOnDataError { get; set; }


        protected override global::System.Collections.IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}
	}
}

//namespace Xamarin.Facebook.Share
//{
//	public partial class DeviceShareDialog
//	{
//		protected override global::System.Collections.IList _OrderedModeHandlers()
//		{
//			return OrderedModeHandlers.ToList();
//		}
//	}
//}

