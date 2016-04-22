using Android.Runtime;
using System;

namespace Xamarin.Facebook
{
    public partial class GraphRequestAsyncTask : global::Android.OS.AsyncTask
    {
        protected override Java.Lang.Object DoInBackground (params Java.Lang.Object[] @params)
        {
            return new Java.Lang.Object (JNIEnv.CallObjectMethod (Handle, JNIEnv.GetMethodID (JNIEnv.GetObjectClass (Handle), "doInBackground", "([Ljava/lang/Object;)Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
        }
    }
}

namespace Xamarin.Facebook.Share.Model
{
    public partial class ShareContent 
    {
        public partial class Builder
        {
            static IntPtr id_build;

            [Register ("build", "()Lcom/facebook/share/model/ShareContent;", "")]
            public global::Java.Lang.Object Build ()
            {
                if (id_build == IntPtr.Zero)
                    id_build = JNIEnv.GetMethodID (class_ref, "build", "()Lcom/facebook/share/model/ShareContent;");
                return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_build), JniHandleOwnership.TransferLocalRef);
            }


            // This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
            global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
            {
                return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
            }

            static IntPtr id_readFrom_Landroid_os_Parcel_;

            [Register ("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
            public global::Xamarin.Facebook.Share.Model.ShareContent.Builder ReadFrom (global::Android.OS.Parcel p0)
            {
                if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
                    id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID (class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;");
                global::Xamarin.Facebook.Share.Model.ShareContent.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareContent.Builder> (JNIEnv.CallObjectMethod  (Handle, id_readFrom_Landroid_os_Parcel_, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
                return __ret;
            }
        }
    }


    public partial class ShareMedia 
    {
        public partial class Builder
        {
            static IntPtr id_build;

            [Register ("build", "()Lcom/facebook/share/model/ShareMedia;", "")]
            public global::Java.Lang.Object Build ()
            {
                if (id_build == IntPtr.Zero)
                    id_build = JNIEnv.GetMethodID (class_ref, "build", "()Lcom/facebook/share/model/ShareMedia;");
                return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_build), JniHandleOwnership.TransferLocalRef);
            }


            // This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
            global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
            {
                return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
            }

            static IntPtr id_readFrom_Landroid_os_Parcel_;

            [Register ("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;", "")]
            public global::Xamarin.Facebook.Share.Model.ShareMedia.Builder ReadFrom (global::Android.OS.Parcel p0)
            {
                if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
                    id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID (class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
                global::Xamarin.Facebook.Share.Model.ShareMedia.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareMedia.Builder> (JNIEnv.CallObjectMethod  (Handle, id_readFrom_Landroid_os_Parcel_, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
                return __ret;
            }
        }
    }

    public partial class ShareOpenGraphValueContainer 
    {
        public partial class Builder
        {
            static IntPtr id_build;

            [Register ("build", "()Lcom/facebook/share/model/ShareOpenGraphValueContainer;", "")]
            public global::Java.Lang.Object Build ()
            {
                if (id_build == IntPtr.Zero)
                    id_build = JNIEnv.GetMethodID (class_ref, "build", "()Lcom/facebook/share/model/ShareOpenGraphValueContainer;");
                return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_build), JniHandleOwnership.TransferLocalRef);
            }

            // This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder
            global::Java.Lang.Object global::Xamarin.Facebook.Share.Model.IShareModelBuilder.ReadFrom (global::Android.OS.Parcel p0)
            {
                return global::Java.Interop.JavaObjectExtensions.JavaCast<Java.Lang.Object>(ReadFrom (p0));
            }

            static IntPtr id_readFrom_Landroid_os_Parcel_;

            [Register ("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;", "")]
            public global::Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer.Builder ReadFrom (global::Android.OS.Parcel p0)
            {
                if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
                    id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID (class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareOpenGraphValueContainer$Builder;");
                global::Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer.Builder __ret = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Model.ShareOpenGraphValueContainer.Builder> (JNIEnv.CallObjectMethod  (Handle, id_readFrom_Landroid_os_Parcel_, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
                return __ret;
            }
        }
    }
}

