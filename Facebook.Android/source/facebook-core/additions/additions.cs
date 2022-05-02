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

	public partial class GraphRequestBatch : global::Java.Util.AbstractList
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook']/class[@name='GraphRequestBatch']/method[@name='size' and count(parameter)=0]"
		[Register("size", "()I", "")]
		public override sealed unsafe int Size()
		{
			const string __id = "size.()I";
			try
			{
				var __rm = _members.InstanceMethods.InvokeNonvirtualInt32Method(__id, this, null);
				return __rm;
			}
			finally
			{
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook']/class[@name='GraphRequestBatch']/method[@name='getSize' and count(parameter)=0]"
		[Register("getSize", "()I", "")]
		public unsafe int GetSize()
		{
			const string __id = "getSize.()I";
			try
			{
				var __rm = _members.InstanceMethods.InvokeAbstractInt32Method(__id, this, null);
				return __rm;
			}
			finally
			{
			}
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
				cb_doInBackground_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate((Func<IntPtr,IntPtr,IntPtr, IntPtr>)n_DoInBackground_arrayLjava_lang_String_);
			return cb_doInBackground_arrayLjava_lang_String_;
		}

		static IntPtr n_DoInBackground_arrayLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_args)
		{
			var __this = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.AppEvents.Internal.FileDownloadTask>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var args = (Java.Lang.Object[])JNIEnv.GetArray(native_args, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.DoInBackground(args));
			if (args != null)
				JNIEnv.CopyArray(args, native_args);
			return __ret;
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.appevents.internal']/class[@name='FileDownloadTask']/method[@name='doInBackground' and count(parameter)=1 and parameter[1][@type='java.lang.String...']]"
		[Register("doInBackground", "([Ljava/lang/String;)Ljava/lang/Boolean;", "GetDoInBackground_arrayLjava_lang_String_Handler")]
		protected override unsafe global::Java.Lang.Object DoInBackground(params global::Java.Lang.Object[] args)
		{
			const string __id = "doInBackground.([Ljava/lang/String;)Ljava/lang/Boolean;";
			IntPtr native_args = JNIEnv.NewArray(args);
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(native_args);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (args != null)
				{
					JNIEnv.CopyArray(native_args, args);
					JNIEnv.DeleteLocalRef(native_args);
				}
				global::System.GC.KeepAlive(args);
			}
		}
	}
}
