using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Facebook.GamingServiceKit
{
    // typedef void (^FBSDKGamingServiceCompletionHandler)(BOOL, NSError * _Nullable);
    delegate void GamingServiceCompletionHandler(bool arg0, [NullAllowed] NSError arg1);

    // typedef void (^FBSDKGamingServiceResultCompletionHandler)(BOOL, NSString * _Nullable, NSError * _Nullable);
    delegate void GamingServiceResultCompletionHandler(bool arg0, [NullAllowed] string arg1, [NullAllowed] NSError arg2);

    // typedef void (^FBSDKGamingServiceProgressHandler)(int64_t, int64_t, int64_t);
    delegate void GamingServiceProgressHandler(long arg0, long arg1, long arg2);

    // @interface FBSDKFriendFinderDialog : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKFriendFinderDialog")]
    [DisableDefaultCtor]
    interface FriendFinderDialog
    {
        // +(void)launchFriendFinderDialogWithCompletionHandler:(FBSDKGamingServiceCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("launchFriendFinderDialogWithCompletionHandler:")]
        void LaunchFriendFinderDialogWithCompletionHandler(GamingServiceCompletionHandler completionHandler);
    }

    // @interface FBSDKGamingGroupIntegration : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGamingGroupIntegration")]
    interface GamingGroupIntegration
    {
        // +(void)openGroupPageWithCompletionHandler:(FBSDKGamingServiceCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("openGroupPageWithCompletionHandler:")]
        void OpenGroupPageWithCompletionHandler(GamingServiceCompletionHandler completionHandler);
    }

    // @interface FBSDKGamingImageUploader : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGamingImageUploader")]
    [DisableDefaultCtor]
    interface GamingImageUploader
    {
        // +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration andCompletionHandler:(FBSDKGamingServiceCompletionHandler _Nonnull)completionHandler __attribute__((deprecated("Please use uploadImageWithConfiguration:andResultCompletionHandler: instead")));
        [Static]
        [Export("uploadImageWithConfiguration:andCompletionHandler:")]
        void UploadImageWithConfiguration(GamingImageUploaderConfiguration configuration, GamingServiceCompletionHandler completionHandler);

        // +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration andResultCompletionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("uploadImageWithConfiguration:andResultCompletionHandler:")]
        void UploadImageWithConfiguration(GamingImageUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler);

        // +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration completionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler andProgressHandler:(FBSDKGamingServiceProgressHandler _Nullable)progressHandler;
        [Static]
        [Export("uploadImageWithConfiguration:completionHandler:andProgressHandler:")]
        void UploadImageWithConfiguration(GamingImageUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler, [NullAllowed] GamingServiceProgressHandler progressHandler);
    }

    // @interface FBSDKGamingImageUploaderConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGamingImageUploaderConfiguration")]
    [DisableDefaultCtor]
    interface GamingImageUploaderConfiguration
    {
        // @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable caption;
        [NullAllowed, Export("caption", ArgumentSemantic.Strong)]
        string Caption { get; }

        // @property (readonly, assign, nonatomic) BOOL shouldLaunchMediaDialog;
        [Export("shouldLaunchMediaDialog")]
        bool ShouldLaunchMediaDialog { get; }

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image caption:(NSString * _Nullable)caption shouldLaunchMediaDialog:(BOOL)shouldLaunchMediaDialog;
        [Export("initWithImage:caption:shouldLaunchMediaDialog:")]
        IntPtr Constructor(UIImage image, [NullAllowed] string caption, bool shouldLaunchMediaDialog);
    }

    // @interface FBSDKGamingVideoUploader : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGamingVideoUploader")]
    [DisableDefaultCtor]
    interface GamingVideoUploader
    {
        // +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration andCompletionHandler:(FBSDKGamingServiceCompletionHandler _Nonnull)completionHandler __attribute__((deprecated("Please use uploadVideoWithConfiguration:andResultCompletionHandler: instead")));
        [Static]
        [Export("uploadVideoWithConfiguration:andCompletionHandler:")]
        void UploadVideoWithConfiguration(GamingVideoUploaderConfiguration configuration, GamingServiceCompletionHandler completionHandler);

        // +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration andResultCompletionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler;
        [Static]
        [Export("uploadVideoWithConfiguration:andResultCompletionHandler:")]
        void UploadVideoWithConfiguration(GamingVideoUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler);

        // +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration completionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler andProgressHandler:(FBSDKGamingServiceProgressHandler _Nullable)progressHandler;
        [Static]
        [Export("uploadVideoWithConfiguration:completionHandler:andProgressHandler:")]
        void UploadVideoWithConfiguration(GamingVideoUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler, [NullAllowed] GamingServiceProgressHandler progressHandler);
    }

    // @interface FBSDKGamingVideoUploaderConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGamingVideoUploaderConfiguration")]
    [DisableDefaultCtor]
    interface GamingVideoUploaderConfiguration
    {
        // @property (readonly, nonatomic, strong) NSURL * _Nonnull videoURL;
        [Export("videoURL", ArgumentSemantic.Strong)]
        NSUrl VideoURL { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable caption;
        [NullAllowed, Export("caption", ArgumentSemantic.Strong)]
        string Caption { get; }

        // -(instancetype _Nonnull)initWithVideoURL:(NSURL * _Nonnull)videoURL caption:(NSString * _Nullable)caption;
        [Export("initWithVideoURL:caption:")]
        IntPtr Constructor(NSUrl videoURL, [NullAllowed] string caption);
    }

    [Static]
    partial interface GamingServicesConstants
    {
        // extern double FBSDKGamingServicesKitVersionNumber;
        [Field("FBSDKGamingServicesKitVersionNumber", "__Internal")]
        double GamingServicesKitVersionNumber { get; }

        // extern const unsigned char [] FBSDKGamingServicesKitVersionString;
        [Field("FBSDKGamingServicesKitVersionString", "__Internal")]
        NSString GamingServicesKitVersionString { get; }
    }
}
