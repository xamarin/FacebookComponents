using System;

using Foundation;
using ObjCRuntime;
using UIKit;

namespace Facebook.MessengerShareKit {
	// @interface FBSDKMessengerBroadcastContext : FBSDKMessengerContext
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerBroadcastContext")]
	interface MessengerBroadcastContext {

	}

	// @interface FBSDKMessengerShareButton : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerShareButton")]
	interface MessengerShareButton {

		// +(UIButton *)rectangularButtonWithStyle:(FBSDKMessengerShareButtonStyle)style;
		[Static]
		[Export ("rectangularButtonWithStyle:")]
		UIButton RectangularButton (MessengerShareButtonStyle style);

		// +(UIButton *)circularButtonWithStyle:(FBSDKMessengerShareButtonStyle)style width:(CGFloat)width;
		[Static]
		[Export ("circularButtonWithStyle:width:")]
		UIButton CircularButton (MessengerShareButtonStyle style, nfloat width);

		// +(UIButton *)circularButtonWithStyle:(FBSDKMessengerShareButtonStyle)style;
		[Static]
		[Export ("circularButtonWithStyle:")]
		UIButton CircularButton (MessengerShareButtonStyle style);
	}

	// @interface FBSDKMessengerContext : NSObject <NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerContext")]
	interface MessengerContext : INSSecureCoding {

	}

	// @interface FBSDKMessengerShareOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerShareOptions")]
	interface MessengerShareOptions {

		// @property (readwrite, copy, nonatomic) NSString * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		string Metadata { get; set; }

		// @property (readwrite, copy, nonatomic) NSURL * sourceURL;
		[NullAllowed]
		[Export ("sourceURL", ArgumentSemantic.Copy)]
		NSUrl SourceUrl { get; set; }

		// @property (nonatomic, readwrite, assign) BOOL renderAsSticker;
		[Export ("renderAsSticker")]
		bool RenderAsSticker { get; set; }

		// @property (readwrite, nonatomic, strong) FBSDKMessengerContext * contextOverride;
		[NullAllowed]
		[Export ("contextOverride", ArgumentSemantic.Strong)]
		MessengerContext ContextOverride { get; set; }
	}

	// @interface FBSDKMessengerSharer : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerSharer")]
	interface MessengerSharer {

		// +(FBSDKMessengerPlatformCapability)messengerPlatformCapabilities;
		[Obsolete ("This is deprecated as of iOS 9. If you use this, you must configure your plist as described in https://developers.facebook.com/docs/ios/ios9")]
		[Static]
		[Export ("messengerPlatformCapabilities")]
		MessengerPlatformCapability MessengerPlatformCapabilities { get; }

		// +(void)openMessenger;
		[Static]
		[Export ("openMessenger")]
		void OpenMessenger ();

		// +(void)shareImage:(UIImage *)image withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareImage:withOptions: instead")));
		[Obsolete ("Use ShareImage (UIImage, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareImage:withMetadata:withContext:")]
		void ShareImage ([NullAllowed] UIImage image, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareImage:(UIImage *)image withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareImage:withOptions:")]
		void ShareImage ([NullAllowed] UIImage image, [NullAllowed] MessengerShareOptions options);

		// +(void)shareAnimatedGIF:(NSData *)animatedGIFData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareAnimatedGIF:withOptions: instead")));
		[Obsolete ("Use ShareAnimatedGif (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareAnimatedGIF:withMetadata:withContext:")]
		void ShareAnimatedGif ([NullAllowed] NSData animatedGIFData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareAnimatedGIF:(NSData *)animatedGIFData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareAnimatedGIF:withOptions:")]
		void ShareAnimatedGif ([NullAllowed] NSData animatedGIFData, [NullAllowed] MessengerShareOptions options);

		// +(void)shareAnimatedWebP:(NSData *)animatedWebPData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareAnimatedWebP:withOptions: instead")));
		[Obsolete ("Use ShareAnimatedWebP (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareAnimatedWebP:withMetadata:withContext:")]
		void ShareAnimatedWebP ([NullAllowed] NSData animatedWebPData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareAnimatedWebP:(NSData *)animatedWebPData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareAnimatedWebP:withOptions:")]
		void ShareAnimatedWebP ([NullAllowed] NSData animatedWebPData, [NullAllowed] MessengerShareOptions options);

		// +(void)shareVideo:(NSData *)videoData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareVideo:withOptions: instead")));
		[Obsolete ("Use ShareVideo (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareVideo:withMetadata:withContext:")]
		void ShareVideo ([NullAllowed] NSData videoData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareVideo:(NSData *)videoData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareVideo:withOptions:")]
		void ShareVideo ([NullAllowed] NSData videoData, [NullAllowed] MessengerShareOptions options);

		// +(void)shareAudio:(NSData *)audioData withMetadata:(NSString *)metadata withContext:(FBSDKMessengerContext *)context __attribute__((deprecated("use use shareAudio:withOptions: instead")));
		[Obsolete ("Use ShareAudio (NSData, MessengerShareOptions) instead")]
		[Static]
		[Export ("shareAudio:withMetadata:withContext:")]
		void ShareAudio ([NullAllowed] NSData audioData, string metadata, [NullAllowed] MessengerContext context);

		// +(void)shareAudio:(NSData *)audioData withOptions:(FBSDKMessengerShareOptions *)options;
		[Static]
		[Export ("shareAudio:withOptions:")]
		void ShareAudio ([NullAllowed] NSData audioData, [NullAllowed] MessengerShareOptions options);
	}

	interface IMessengerUrlHandlerDelegate {

	}

	// @protocol FBSDKMessengerURLHandlerDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKMessengerURLHandlerDelegate")]
	interface MessengerUrlHandlerDelegate {

		// @optional -(void)messengerURLHandler:(FBSDKMessengerURLHandler *)messengerURLHandler didHandleReplyWithContext:(FBSDKMessengerURLHandlerReplyContext *)context;
		[EventArgs ("MessengerUrlHandlerReplyHandled")]
		[EventName ("ReplyHandled")]
		[Export ("messengerURLHandler:didHandleReplyWithContext:")]
		void DidHandleReply (MessengerUrlHandler messengerURLHandler, MessengerUrlHandlerReplyContext context);

		// @optional -(void)messengerURLHandler:(FBSDKMessengerURLHandler *)messengerURLHandler didHandleOpenFromComposerWithContext:(FBSDKMessengerURLHandlerOpenFromComposerContext *)context;
		[EventArgs ("MessengerUrlHandlerOpenHandledFromComposer")]
		[EventName ("OpenHandledFromComposer")]
		[Export ("messengerURLHandler:didHandleOpenFromComposerWithContext:")]
		void DidHandleOpenFromComposer (MessengerUrlHandler messengerURLHandler, MessengerUrlHandlerOpenFromComposerContext context);

		// @optional -(void)messengerURLHandler:(FBSDKMessengerURLHandler *)messengerURLHandler didHandleCancelWithContext:(FBSDKMessengerURLHandlerCancelContext *)context;
		[EventArgs ("MessengerUrlHandlerCancelHandled")]
		[EventName ("CancelHandled")]
		[Export ("messengerURLHandler:didHandleCancelWithContext:")]
		void DidHandleCancel (MessengerUrlHandler messengerURLHandler, MessengerUrlHandlerCancelContext context);
	}

	// @interface FBSDKMessengerURLHandler : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKMessengerURLHandler",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (MessengerUrlHandlerDelegate) })]
	interface MessengerUrlHandler {

		// -(BOOL)canOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("canOpenURL:sourceApplication:")]
		bool CanOpenUrl (NSUrl url, string sourceApplication);

		[Obsolete ("Use CanOpenUrl method instead. This will be removed in future versions.")]
		[Wrap ("CanOpenUrl (url, sourceApplication)")]
		bool CanOpenURL (NSUrl url, string sourceApplication);

		// -(BOOL)openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("openURL:sourceApplication:")]
		bool OpenUrl (NSUrl url, string sourceApplication);

		[Obsolete ("Use OpenUrl method instead. This will be removed in future versions.")]
		[Wrap ("OpenUrl (url, sourceApplication)")]
		bool OpenURL (NSUrl url, string sourceApplication);

		// @property (nonatomic, weak) id<FBSDKMessengerURLHandlerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IMessengerUrlHandlerDelegate Delegate { get; set; }
	}

	// @interface FBSDKMessengerURLHandlerCancelContext : FBSDKMessengerContext
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerURLHandlerCancelContext")]
	interface MessengerUrlHandlerCancelContext {

	}

	// @interface FBSDKMessengerURLHandlerOpenFromComposerContext : FBSDKMessengerContext
	[DisableDefaultCtor]
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerURLHandlerOpenFromComposerContext")]
	interface MessengerUrlHandlerOpenFromComposerContext {

		// @property (readonly, copy, nonatomic) NSString * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		string Metadata { get; }

		// @property (readonly, copy, nonatomic) NSSet * userIDs;
		[Export ("userIDs", ArgumentSemantic.Copy)]
		NSSet UserIds { get; }

		[Obsolete ("Use UserIds property instead. This will be removed in future versions.")]
		[Wrap ("UserIds")]
		NSSet UserIDs { get; }
	}

	// @interface FBSDKMessengerURLHandlerReplyContext : FBSDKMessengerContext
	[BaseType (typeof (MessengerContext), Name = "FBSDKMessengerURLHandlerReplyContext")]
	interface MessengerUrlHandlerReplyContext {
		// @property (readonly, copy, nonatomic) NSString * metadata;
		[Export ("metadata", ArgumentSemantic.Copy)]
		string Metadata { get; }

		// @property (readonly, copy, nonatomic) NSSet * userIDs;
		[Export ("userIDs", ArgumentSemantic.Copy)]
		NSSet UserIds { get; }

		[Obsolete ("Use UserIds property instead. This will be removed in future versions.")]
		[Wrap ("UserIds")]
		NSSet UserIDs { get; }
	}
}
