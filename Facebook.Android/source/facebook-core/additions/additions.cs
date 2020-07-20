using System;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Facebook
{
	public partial class GraphRequestAsyncTask {
		protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
		{
			return new Java.Lang.Object(JNIEnv.CallObjectMethod(Handle, JNIEnv.GetMethodID(JNIEnv.GetObjectClass(Handle), "doInBackground", "([Ljava/lang/Object;)Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
		}
	}
}

namespace Xamarin.Facebook.AppEvents.Internal
{
	

	public partial class FileDownloadTask
    {

		static Delegate cb_doInBackground_arrayLjava_lang_String_;
		#pragma warning disable 0169
		static Delegate GetDoInBackground_arrayLjava_lang_String_Handler()
		{
			if (cb_doInBackground_arrayLjava_lang_String_ == null)
				cb_doInBackground_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr, IntPtr>)n_DoInBackground_arrayLjava_lang_String_);
			return cb_doInBackground_arrayLjava_lang_String_;
		}

		static IntPtr n_DoInBackground_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Xamarin.Facebook.AppEvents.Internal.FileDownloadTask __this = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.AppEvents.Internal.FileDownloadTask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string[] p0 = (string[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(string));
			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.DoInBackground(p0));
			if (p0 != null)
				JNIEnv.CopyArray(p0, native_p0);
			return __ret;
		}
		#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.appevents.internal']/class[@name='FileDownloadTask']/method[@name='doInBackground' and count(parameter)=1 and parameter[1][@type='java.lang.String...']]"
		[Register("doInBackground", "([Ljava/lang/String;)Ljava/lang/Boolean;", "GetDoInBackground_arrayLjava_lang_String_Handler")]
		protected override unsafe global::Java.Lang.Object DoInBackground(params global::Java.Lang.Object[] p0)
		{
			const string __id = "doInBackground.([Ljava/lang/String;)Ljava/lang/Boolean;";
			IntPtr native_p0 = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(native_p0);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(native_p0, p0);
					JNIEnv.DeleteLocalRef(native_p0);
				}
			}
		}
	}
}