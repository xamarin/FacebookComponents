using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Facebook.GamingServicesKit {

	// typedef void (^FBSDKGamingServiceCompletionHandler)(BOOL, NSError * _Nullable);
	delegate void GamingServiceCompletionHandler (bool success, [NullAllowed] NSError error);

	// typedef void (^FBSDKGamingServiceResultCompletionHandler)(BOOL, NSString * _Nullable, NSError * _Nullable);
	delegate void GamingServiceResultCompletionHandler (bool success, [NullAllowed] string result, [NullAllowed] NSError error);

	// typedef void (^FBSDKGamingServiceProgressHandler)(int64_t, int64_t, int64_t);
	delegate void GamingServiceProgressHandler (long bytesSent, long totalBytesSent, long totalBytesExpectedToSend);

	// @interface FBSDKFriendFinderDialog : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKFriendFinderDialog")]
	[DisableDefaultCtor]
	interface FriendFinderDialog {

		// +(void)launchFriendFinderDialogWithCompletionHandler:(FBSDKGamingServiceCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("launchFriendFinderDialogWithCompletionHandler:")]
		void LaunchDialog (GamingServiceCompletionHandler completionHandler);
	}

	// @interface FBSDKGamingGroupIntegration : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGamingGroupIntegration")]
	interface GamingGroupIntegration {

		// +(void)openGroupPageWithCompletionHandler:(FBSDKGamingServiceCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("openGroupPageWithCompletionHandler:")]
		void OpenGroupPage (GamingServiceCompletionHandler completionHandler);
	}

	// @interface FBSDKGamingImageUploader : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGamingImageUploader")]
	[DisableDefaultCtor]
	interface GamingImageUploader {

		// +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration andResultCompletionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("uploadImageWithConfiguration:andResultCompletionHandler:")]
		void UploadImage (GamingImageUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler);

		// +(void)uploadImageWithConfiguration:(FBSDKGamingImageUploaderConfiguration * _Nonnull)configuration completionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler andProgressHandler:(FBSDKGamingServiceProgressHandler _Nullable)progressHandler;
		[Static]
		[Export ("uploadImageWithConfiguration:completionHandler:andProgressHandler:")]
		void UploadImage (GamingImageUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler, [NullAllowed] GamingServiceProgressHandler progressHandler);
	}

	// @interface FBSDKGamingImageUploaderConfiguration : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGamingImageUploaderConfiguration")]
	[DisableDefaultCtor]
	interface GamingImageUploaderConfiguration {

		// @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable caption;
		[NullAllowed, Export("caption", ArgumentSemantic.Strong)]
		string Caption { get; }

		// @property (readonly, assign, nonatomic) BOOL shouldLaunchMediaDialog;
		[Export ("shouldLaunchMediaDialog")]
		bool ShouldLaunchMediaDialog { get; }

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image caption:(NSString * _Nullable)caption shouldLaunchMediaDialog:(BOOL)shouldLaunchMediaDialog;
		[Export ("initWithImage:caption:shouldLaunchMediaDialog:")]
		IntPtr Constructor (UIImage image, [NullAllowed] string caption, bool shouldLaunchMediaDialog);
	}

	// @interface FBSDKGamingVideoUploader : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGamingVideoUploader")]
	[DisableDefaultCtor]
	interface GamingVideoUploader {

		// +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration andResultCompletionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("uploadVideoWithConfiguration:andResultCompletionHandler:")]
		void UploadVideo (GamingVideoUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler);

		// +(void)uploadVideoWithConfiguration:(FBSDKGamingVideoUploaderConfiguration * _Nonnull)configuration completionHandler:(FBSDKGamingServiceResultCompletionHandler _Nonnull)completionHandler andProgressHandler:(FBSDKGamingServiceProgressHandler _Nullable)progressHandler;
		[Static]
		[Export ("uploadVideoWithConfiguration:completionHandler:andProgressHandler:")]
		void UploadVideo (GamingVideoUploaderConfiguration configuration, GamingServiceResultCompletionHandler completionHandler, [NullAllowed] GamingServiceProgressHandler progressHandler);
	}

	// @interface FBSDKGamingVideoUploaderConfiguration : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGamingVideoUploaderConfiguration")]
	[DisableDefaultCtor]
	interface GamingVideoUploaderConfiguration {

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull videoURL;
		[Export ("videoURL", ArgumentSemantic.Strong)]
		NSUrl VideoUrl { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable caption;
		[NullAllowed, Export("caption", ArgumentSemantic.Strong)]
		string Caption { get; }

		// -(instancetype _Nonnull)initWithVideoURL:(NSURL * _Nonnull)videoURL caption:(NSString * _Nullable)caption;
		[Export ("initWithVideoURL:caption:")]
		IntPtr Constructor (NSUrl videoUrl, [NullAllowed] string caption);
	}
}
