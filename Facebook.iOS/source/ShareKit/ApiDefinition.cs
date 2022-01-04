using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Photos;

namespace Facebook.ShareKit {
	// @interface FBSDKAppGroupContent : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKAppGroupContent")]
	interface AppGroupContent : INSCopying, INSSecureCoding {

		// @property (copy, nonatomic) NSString * groupDescription;
		[Export ("groupDescription", ArgumentSemantic.Copy)]
		string GroupDescription { get; set; }

		// @property (copy, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		// @property (assign, nonatomic) FBSDKAppGroupPrivacy privacy;
		[Export ("privacy", ArgumentSemantic.Assign)]
		AppGroupPrivacy Privacy { get; set; }

		// -(BOOL)isEqualToAppGroupContent:(FBSDKAppGroupContent *)content;
		[Export ("isEqualToAppGroupContent:")]
		bool Equals (AppGroupContent content);
	}

	// @interface FBSDKAppInviteContent : NSObject <NSCopying, NSObject, FBSDKSharingValidation, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKAppInviteContent")]
	interface AppInviteContent : INSCopying, SharingValidation, INSSecureCoding {

		// @property (copy, nonatomic) NSURL * appLinkURL;
		[NullAllowed]
		[Export ("appLinkURL", ArgumentSemantic.Copy)]
		NSUrl AppLinkUrl { get; set; }

		// @property (nonatomic, copy) NSURL *appInvitePreviewImageURL;
		[NullAllowed]
		[Export ("appInvitePreviewImageURL", ArgumentSemantic.Copy)]
		NSUrl PreviewImageUrl { get; set; }

		// @property (nonatomic, copy) NSString *promotionCode;
		[NullAllowed]
		[Export ("promotionCode")]
		string PromotionCode { get; set; }

		// @property (nonatomic, copy) NSString *promotionText;
		[NullAllowed]
		[Export ("promotionText")]
		string PromotionText { get; set; }

		// @property FBSDKAppInviteDestination destination;
		[Export ("destination", ArgumentSemantic.Assign)]
		AppInviteDestination Destination { get; set; }

		// -(BOOL)isEqualToAppInviteContent:(FBSDKAppInviteContent *)content;
		[Export ("isEqualToAppInviteContent:")]
		bool Equals (AppInviteContent content);
	}

	// @interface FBSDKCameraEffectArguments : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKCameraEffectArguments")]
	interface CameraEffectArguments : INSCopying, INSSecureCoding {
		// -(void)setString:(NSString *)string forKey:(NSString *)key;
		[Export ("setString:forKey:")]
		void SetString ([NullAllowed] string aString, string key);

		// -(NSString *)stringForKey:(NSString *)key;
		[return: NullAllowed]
		[Export ("stringForKey:")]
		string GetString (string key);

		// -(void)setArray:(NSArray<NSString *> *)array forKey:(NSString *)key;
		[Export ("setArray:forKey:")]
		void SetArray ([NullAllowed] string [] array, string key);

		// -(NSArray *)arrayForKey:(NSString *)key;
		[return: NullAllowed]
		[Export ("arrayForKey:")]
		string [] GetArray (string key);
	}

	// @interface FBSDKCameraEffectTextures : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKCameraEffectTextures")]
	interface CameraEffectTextures : INSCopying, INSSecureCoding {
		// -(void)setImage:(UIImage *)image forKey:(NSString *)key;
		[Export ("setImage:forKey:")]
		void SetImage ([NullAllowed] UIImage image, string key);

		// -(UIImage *)imageForKey:(NSString *)key;
		[return: NullAllowed]
		[Export ("imageForKey:")]
		UIImage GetImage (string key);
	}

	// @interface FBSDKGameRequestContent : NSObject <NSCopying, NSObject, FBSDKSharingValidation, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKGameRequestContent")]
	interface GameRequestContent : INSCopying, SharingValidation, INSSecureCoding {

		// @property (assign, nonatomic) FBSDKGameRequestActionType actionType;
		[Export ("actionType", ArgumentSemantic.Assign)]
		GameRequestActionType ActionType { get; set; }

		// -(BOOL)isEqualToGameRequestContent:(FBSDKGameRequestContent *)content;
		[Export ("isEqualToGameRequestContent:")]
		bool Equals (GameRequestContent content);

		// @property (copy, nonatomic) NSString * data;
		[NullAllowed]
		[Export ("data", ArgumentSemantic.Copy)]
		string Data { get; set; }

		// @property (assign, nonatomic) FBSDKGameRequestFilter filters;
		[Export ("filters", ArgumentSemantic.Assign)]
		GameRequestFilter Filters { get; set; }

		// @property (copy, nonatomic) NSString * message;
		[Export ("message", ArgumentSemantic.Copy)]
		string Message { get; set; }

		// @property (copy, nonatomic) NSString * objectID;
		[Export ("objectID", ArgumentSemantic.Copy)]
		string ObjectId { get; set; }

		// @property (nonatomic, copy) NSArray *recipients;
		[Export ("recipients", ArgumentSemantic.Copy)]
		string [] Recipients { get; set; }

		// @property (copy, nonatomic) NSArray * recipientSuggestions;
		[Export ("recipientSuggestions", ArgumentSemantic.Copy)]
		string [] RecipientSuggestions { get; set; }

		// @property (copy, nonatomic) NSString * title;
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull cta;
		[Export ("cta", ArgumentSemantic.Copy)]
		string Cta { get; set; }
	}

	// @interface FBSDKGameRequestDialog : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGameRequestDialog")]
	interface GameRequestDialog {
		// +(instancetype _Nonnull)dialogWithContent:(FBSDKGameRequestContent * _Nonnull)content delegate:(id<FBSDKGameRequestDialogDelegate> _Nullable)delegate __attribute__((swift_name("init(content:delegate:)")));
		[Static]
		[Export ("dialogWithContent:delegate:")]
		GameRequestDialog Create (GameRequestContent content, [NullAllowed] IGameRequestDialogDelegate aDelegate);

		// +(instancetype)showWithContent:(FBSDKGameRequestContent *)content delegate:(id<FBSDKGameRequestDialogDelegate>)delegate;
		[Static]
		[Export ("showWithContent:delegate:")]
		GameRequestDialog Show ([NullAllowed] GameRequestContent content, [NullAllowed] IGameRequestDialogDelegate aDelegate);

		// @property (nonatomic, weak) id<FBSDKGameRequestDialogDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGameRequestDialogDelegate Delegate { get; set; }

		// @property (copy, nonatomic) FBSDKGameRequestContent * content;
		[NullAllowed]
		[Export ("content", ArgumentSemantic.Copy)]
		GameRequestContent Content { get; set; }

		// @property (getter = isFrictionlessRequestsEnabled, assign, nonatomic) BOOL frictionlessRequestsEnabled;
		[Export ("frictionlessRequestsEnabled")]
		bool FrictionlessRequestsEnabled { [Bind ("isFrictionlessRequestsEnabled")] get; set; }

		// -(BOOL)canShow;
		[Export ("canShow")]
		bool CanShow { get; }

		// -(BOOL)show;
		[Export ("show")]
		bool Show ();

		// -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		bool Validate (out NSError error);
	}

	interface IGameRequestDialogDelegate { }

	// @protocol FBSDKGameRequestDialogDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGameRequestDialogDelegate")]
	interface GameRequestDialogDelegate {

		// @required -(void)gameRequestDialog:(FBSDKGameRequestDialog *)gameRequestDialog didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[Export ("gameRequestDialog:didCompleteWithResults:")]
		void DidComplete (GameRequestDialog gameRequestDialog, NSDictionary results);

		// @required -(void)gameRequestDialog:(FBSDKGameRequestDialog *)gameRequestDialog didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("gameRequestDialog:didFailWithError:")]
		void DidFail (GameRequestDialog gameRequestDialog, NSError error);

		// @required -(void)gameRequestDialogDidCancel:(FBSDKGameRequestDialog *)gameRequestDialog;
		[Abstract]
		[Export ("gameRequestDialogDidCancel:")]
		void DidCancel (GameRequestDialog gameRequestDialog);
	}

	// @interface FBSDKGameRequestURLProvider : NSObject
	[BaseType (typeof(NSObject), Name = "FBSDKGameRequestURLProvider")]
	interface GameRequestUrlProvider
	{
		// +(NSURL * _Nullable)createDeepLinkURLWithQueryDictionary:(NSDictionary<NSString *,id> * _Nonnull __strong)queryDictionary;
		[Static]
		[Export ("createDeepLinkURLWithQueryDictionary:")]
		[return: NullAllowed]
		NSUrl CreateDeepLinkUrl (NSDictionary<NSString, NSObject> queryDictionary);

		// +(NSString * _Nullable)filtersNameForFilters:(FBSDKGameRequestFilter)filters;
		[Static]
		[Export ("filtersNameForFilters:")]
		[return: NullAllowed]
		string GetFiltersName (GameRequestFilter filters);

		// +(NSString * _Nullable)actionTypeNameForActionType:(FBSDKGameRequestActionType)actionType;
		[Static]
		[Export ("actionTypeNameForActionType:")]
		[return: NullAllowed]
		string GetActionTypeName (GameRequestActionType actionType);
	}

	// @interface FBSDKHashtag : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKHashtag")]
	interface Hashtag : INSCopying, INSSecureCoding {
		// + (instancetype)hashtagWithString:(NSString *)hashtagString;
		[Static]
		[Export ("hashtagWithString:")]
		Hashtag Create (string hashtag);

		// @property (nonatomic, readwrite, copy) NSString *stringRepresentation;
		[Export ("stringRepresentation")]
		string StringRepresentation { get; set; }

		// @property (nonatomic, readonly, assign, getter=isValid) BOOL valid;
		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; set; }

		// - (BOOL)isEqualToHashtag:(FBSDKHashtag *)hashtag;
		[Export ("isEqualToHashtag:")]
		bool Equals (Hashtag hashtag);
	}

	// @interface FBSDKMessageDialog : NSObject <FBSDKSharingDialog>
	[Obsolete ("Sharing to Messenger via the SDK is unsupported. https://developers.facebook.com/docs/messenger-platform/changelog/#20190610. Sharing should be performed by the native share sheet.")]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKMessageDialog")]
	interface MessageDialog : SharingDialog {
		// -(instancetype _Nonnull)initWithContent:(id<FBSDKSharingContent>  _Nullable __strong)content delegate:(id<FBSDKSharingDelegate>  _Nullable __strong)delegate __attribute__((ns_consumes_self)) __attribute__((ns_returns_retained));
		[Export ("initWithContent:delegate:")]
		IntPtr Constructor ([NullAllowed] ISharingContent content, [NullAllowed] ISharingDelegate @delegate);
		
		// +(instancetype _Nonnull)dialogWithContent:(id<FBSDKSharingContent> _Nonnull)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((swift_name("init(content:delegate:)")));
		[Static]
		[Export ("dialogWithContent:delegate:")]
		MessageDialog Create (ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);

		// +(instancetype)showWithContent:(id<FBSDKSharingContent>)content delegate:(id<FBSDKSharingDelegate>)delegate;
		[Static]
		[Export ("showWithContent:delegate:")]
		MessageDialog Show ([NullAllowed] ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);
	}

	// @interface FBSDKSendButton : FBSDKButton <FBSDKSharingButton>
	[Obsolete ("Sharing to Messenger via the SDK is unsupported. https://developers.facebook.com/docs/messenger-platform/changelog/#20190610. Sharing should be performed by the native share sheet.")]
	[BaseType (typeof (CoreKit.Button), Name = "FBSDKSendButton")]
	interface SendButton : SharingButton {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	// @interface FBSDKShareButton : FBSDKButton <FBSDKSharingButton>
	[BaseType (typeof (CoreKit.Button), Name = "FBSDKShareButton")]
	interface ShareButton : SharingButton {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	// @interface FBSDKShareCameraEffectContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareCameraEffectContent")]
	interface ShareCameraEffectContent : SharingContent, SharingScheme {
		// @property (copy, nonatomic) NSString * effectID;
		[Export ("effectID")]
		string EffectId { get; set; }

		// @property (copy, nonatomic) FBSDKCameraEffectArguments * effectArguments;
		[Export ("effectArguments", ArgumentSemantic.Copy)]
		CameraEffectArguments EffectArguments { get; set; }

		// @property (copy, nonatomic) FBSDKCameraEffectTextures * effectTextures;
		[Export ("effectTextures", ArgumentSemantic.Copy)]
		CameraEffectTextures EffectTextures { get; set; }

		// -(BOOL)isEqualToShareCameraEffectContent:(FBSDKShareCameraEffectContent *)content;
		[Export ("isEqualToShareCameraEffectContent:")]
		bool Equals (ShareCameraEffectContent content);
	}

	// @interface FBSDKShareDialog : NSObject <FBSDKSharingDialog>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKShareDialog")]
	interface ShareDialog : SharingDialog {
		// -(instancetype _Nonnull)initWithViewController:(UIViewController * _Nullable __strong)viewController content:(id<FBSDKSharingContent>  _Nullable __strong)content delegate:(id<FBSDKSharingDelegate>  _Nullable __strong)delegate __attribute__((ns_consumes_self)) __attribute__((ns_returns_retained));
		[Export ("initWithViewController:content:delegate:")]
		IntPtr Constructor ([NullAllowed] UIViewController viewController, [NullAllowed] ISharingContent content, [NullAllowed] ISharingDelegate @delegate);
		
		// +(instancetype _Nonnull)dialogWithViewController:(UIViewController * _Nullable)viewController withContent:(id<FBSDKSharingContent> _Nonnull)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((swift_name("init(fromViewController:content:delegate:)")));
		[Static]
		[Export ("dialogWithViewController:withContent:delegate:")]
		ShareDialog Create ([NullAllowed] UIViewController viewController, ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);

		// +(instancetype)showFromViewController:(UIViewController *)viewController withContent:(id<FBSDKSharingContent>)content delegate:(id<FBSDKSharingDelegate>)delegate;
		[Static]
		[Export ("showFromViewController:withContent:delegate:")]
		ShareDialog Show (UIViewController viewController, ISharingContent content, [NullAllowed] ISharingDelegate aDelegate);

		// @property (nonatomic, weak) UIViewController * fromViewController;
		[NullAllowed]
		[Export ("fromViewController", ArgumentSemantic.Weak)]
		UIViewController FromViewController { get; set; }

		// @property (assign, nonatomic) FBSDKShareDialogMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		ShareDialogMode Mode { get; set; }
	}

	// @interface FBSDKShareLinkContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareLinkContent")]
	interface ShareLinkContent : SharingContent {
		// @property (copy, nonatomic) NSString * _Nullable quote;
		[NullAllowed]
		[Export ("quote")]
		string Quote { get; set; }

		// -(BOOL)isEqualToShareLinkContent:(FBSDKShareLinkContent *)content;
		[Export ("isEqualToShareLinkContent:")]
		bool Equals (ShareLinkContent content);
	}

	interface IShareMedia { }

	// @protocol FBSDKShareMedia <NSObject>
	[Protocol (Name = "FBSDKShareMedia")]
	interface ShareMedia { }

	// @interface FBSDKShareMediaContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareMediaContent")]
	interface ShareMediaContent {
		// @property (nonatomic, copy) NSArray *media;
		[Export ("media", ArgumentSemantic.Copy)]
		IShareMedia [] Media { get; set; }

		// - (BOOL)isEqualToShareMediaContent:(FBSDKShareMediaContent *)content;
		[Export ("isEqualToShareMediaContent:")]
		bool Equals (ShareMediaContent content);
	}

	// @interface FBSDKSharePhoto : NSObject <NSSecureCoding, NSCopying, NSObject, FBSDKShareMedia, FBSDKSharingValidation>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKSharePhoto")]
	interface SharePhoto : INSSecureCoding, INSCopying, ShareMedia, SharingValidation {

		// +(instancetype)photoWithImage:(UIImage *)image userGenerated:(BOOL)userGenerated;
		[Static]
		[Export ("photoWithImage:userGenerated:")]
		SharePhoto From ([NullAllowed] UIImage image, bool userGenerated);

		// +(instancetype)photoWithImageURL:(NSURL *)imageURL userGenerated:(BOOL)userGenerated;
		[Static]
		[Export ("photoWithImageURL:userGenerated:")]
		SharePhoto From ([NullAllowed] NSUrl imageURL, bool userGenerated);

		// +(instancetype)photoWithPhotoAsset:(PHAsset *)photoAsset userGenerated:(BOOL)userGenerated;
		[Static]
		[Export ("photoWithPhotoAsset:userGenerated:")]
		SharePhoto From (PHAsset photoAsset, bool userGenerated);

		// @property (nonatomic, strong) UIImage * image;
		[NullAllowed]
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @property (copy, nonatomic) NSURL * imageURL;
		[NullAllowed]
		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; set; }

		// @property (copy, nonatomic) PHAsset * photoAsset;
		[Export ("photoAsset", ArgumentSemantic.Copy)]
		PHAsset PhotoAsset { get; set; }

		// @property (getter = isUserGenerated, assign, nonatomic) BOOL userGenerated;
		[Export ("userGenerated")]
		bool UserGenerated { [Bind ("isUserGenerated")] get; set; }

		// @property (nonatomic, copy) NSString *caption;
		[NullAllowed]
		[Export ("caption", ArgumentSemantic.Copy)]
		string Caption { get; set; }

		// -(BOOL)isEqualToSharePhoto:(FBSDKSharePhoto *)photo;
		[Export ("isEqualToSharePhoto:")]
		bool Equals (SharePhoto photo);
	}

	// @interface FBSDKSharePhotoContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKSharePhotoContent")]
	interface SharePhotoContent : SharingContent {

		// @property (copy, nonatomic) NSArray * photos;
		[NullAllowed]
		[Export ("photos", ArgumentSemantic.Copy)]
		SharePhoto [] Photos { get; set; }

		// -(BOOL)isEqualToSharePhotoContent:(FBSDKSharePhotoContent *)content;
		[Export ("isEqualToSharePhotoContent:")]
		bool Equals (SharePhotoContent content);
	}

	// @interface FBSDKShareVideo : NSObject <NSSecureCoding, NSCopying, NSObject, FBSDKShareMedia, FBSDKSharingValidation>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKShareVideo")]
	interface ShareVideo : INSSecureCoding, INSCopying, ShareMedia, SharingValidation {
		// +(instancetype)videoWithData:(NSData *)data;
		[Static]
		[Export ("videoWithData:")]
		ShareVideo From (NSData data);

		// +(instancetype)videoWithData:(NSData *)data previewPhoto:(FBSDKSharePhoto *)previewPhoto;
		[Static]
		[Export ("videoWithData:previewPhoto:")]
		ShareVideo From (NSData data, SharePhoto previewPhoto);

		// + (instancetype)videoWithVideoAsset:(PHAsset *)videoAsset;
		[Static]
		[Export ("videoWithVideoAsset:")]
		ShareVideo From ([NullAllowed] PHAsset videoAsset);

		// + (instancetype)videoWithVideoAsset:(PHAsset *)videoAsset previewPhoto:(FBSDKSharePhoto *)previewPhoto;
		[Static]
		[Export ("videoWithVideoAsset:previewPhoto:")]
		ShareVideo From ([NullAllowed] PHAsset videoAsset, [NullAllowed] SharePhoto previewPhoto);

		// +(instancetype)videoWithVideoURL:(NSURL *)videoURL;
		[Static]
		[Export ("videoWithVideoURL:")]
		ShareVideo From ([NullAllowed] NSUrl videoURL);

		// + (instancetype)videoWithVideoURL:(NSURL *)videoURL previewPhoto:(FBSDKSharePhoto *)previewPhoto;
		[Static]
		[Export ("videoWithVideoURL:previewPhoto:")]
		ShareVideo From ([NullAllowed] NSUrl videoURL, [NullAllowed] SharePhoto previewPhoto);

		// @property (nonatomic, strong) NSData * data;
		[NullAllowed]
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; set; }

		// @property (nonatomic, copy) PHAsset *videoAsset;
		[NullAllowed]
		[Export ("videoAsset", ArgumentSemantic.Copy)]
		PHAsset VideoAsset { get; set; }

		// @property (copy, nonatomic) NSURL * videoURL;
		[NullAllowed]
		[Export ("videoURL", ArgumentSemantic.Copy)]
		NSUrl VideoUrl { get; set; }

		// @property (nonatomic, copy) FBSDKSharePhoto *previewPhoto;
		[NullAllowed]
		[Export ("previewPhoto", ArgumentSemantic.Copy)]
		SharePhoto PreviewPhoto { get; set; }

		// -(BOOL)isEqualToShareVideo:(FBSDKShareVideo *)video;
		[Export ("isEqualToShareVideo:")]
		bool Equals (ShareVideo video);
	}

	// @interface FBSDKShareVideo (PHAsset)
	[Category]
	[BaseType (typeof (PHAsset))]
	interface PHAsset_FBSDKShareVideo {
		// @property (readonly, copy, nonatomic) NSURL * videoURL;
		[Export ("videoURL")]
		NSUrl GetVideoUrl ();
	}

	// @interface FBSDKShareVideoContent : NSObject <FBSDKSharingContent>
	[BaseType (typeof (NSObject), Name = "FBSDKShareVideoContent")]
	interface ShareVideoContent : SharingContent {
		// @property (copy, nonatomic) FBSDKShareVideo * video;
		[NullAllowed]
		[Export ("video", ArgumentSemantic.Copy)]
		ShareVideo Video { get; set; }

		// -(BOOL)isEqualToShareVideoContent:(FBSDKShareVideoContent *)content;
		[Export ("isEqualToShareVideoContent:")]
		bool Equals (ShareVideoContent content);
	}

	interface ISharing {

	}

	// @protocol FBSDKSharing <NSObject>
	[Protocol (Name = "FBSDKSharing")]
	interface Sharing {

		// @required @property (nonatomic, weak) id<FBSDKSharingDelegate> delegate;
		[Export ("delegate")]
		ISharingDelegate GetDelegate ();

		[Export ("setDelegate:")]
		void SetDelegate ([NullAllowed] ISharingDelegate aDelegate);

		// @required @property (copy, nonatomic) id<FBSDKSharingContent> shareContent;
		[Export ("shareContent")]
		ISharingContent GetShareContent ();

		[Export ("setShareContent:")]
		void SetShareContent ([NullAllowed] ISharingContent shareContent);

		// @required @property (assign, nonatomic) BOOL shouldFailOnDataError;
		[Export ("shouldFailOnDataError")]
		bool GetShouldFailOnDataError ();

		[Export ("setShouldFailOnDataError:")]
		void SetShouldFailOnDataError (bool shouldFail);

		// @required -(BOOL)validateWithError:(NSError **)errorRef;
		[Export ("validateWithError:")]
		bool Validate (out NSError errorRef);
	}

	interface ISharingDialog {

	}

	// @protocol FBSDKSharingDialog <FBSDKSharing>
	[Protocol (Name = "FBSDKSharingDialog")]
	interface SharingDialog : Sharing {

		// @required -(BOOL)canShow;
		[Abstract]
		[Export ("canShow")]
		bool CanShow ();

		// @required -(BOOL)show;
		[Abstract]
		[Export ("show")]
		bool Show ();
	}

	interface ISharingDelegate {

	}

	// @protocol FBSDKSharingDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingDelegate")]
	interface SharingDelegate {

		// @required -(void)sharer:(id<FBSDKSharing>)sharer didCompleteWithResults:(NSDictionary *)results;
		[Abstract]
		[Export ("sharer:didCompleteWithResults:")]
		void DidComplete (ISharing sharer, NSDictionary results);

		// @required -(void)sharer:(id<FBSDKSharing>)sharer didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("sharer:didFailWithError:")]
		void DidFail (ISharing sharer, NSError error);

		// @required -(void)sharerDidCancel:(id<FBSDKSharing>)sharer;
		[Abstract]
		[Export ("sharerDidCancel:")]
		void DidCancel (ISharing sharer);
	}

	interface ISharingButton {

	}

	// @protocol FBSDKSharingButton <NSObject>
	[Protocol (Name = "FBSDKSharingButton")]
	interface SharingButton {

		// @required @property (copy, nonatomic) id<FBSDKSharingContent> shareContent;
		[Abstract]
		[Export ("shareContent")]
		ISharingContent GetShareContent ();

		[Abstract]
		[Export ("setShareContent:")]
		void SetShareContent ([NullAllowed] ISharingContent shareContent);
	}

	interface ISharingContent {

	}

	// @protocol FBSDKSharingContent <NSCopying, NSObject, FBSDKSharingValidation, NSSecureCoding>
	[Protocol (Name = "FBSDKSharingContent")]
	interface SharingContent : INSCopying, SharingValidation, INSSecureCoding {

		// @required @property (copy, nonatomic) NSURL * contentURL;
		[Abstract]
		[Export ("contentURL")]
		NSUrl GetContentUrl ();

		[Abstract]
		[Export ("setContentURL:")]
		void SetContentUrl ([NullAllowed] NSUrl url);

		// @property (nonatomic, copy) FBSDKHashtag *hashtag;
		[Abstract]
		[Export ("hashtag", ArgumentSemantic.Copy)]
		Hashtag Hashtag { get; set; }

		// @required @property (copy, nonatomic) NSArray * peopleIDs;
		[Abstract]
		[Export ("peopleIDs")]
		string [] GetPeopleIds ();

		[Abstract]
		[Export ("setPeopleIDs:")]
		void SetPeopleIds ([NullAllowed] string [] peolpleId);

		// @required @property (copy, nonatomic) NSString * placeID;
		[Abstract]
		[Export ("placeID")]
		string GetPlaceId ();

		[Abstract]
		[Export ("setPlaceID:")]
		void SetPlaceId (string placeId);

		// @required @property (copy, nonatomic) NSString * ref;
		[Abstract]
		[Export ("ref")]
		string GetRef ();

		[Abstract]
		[Export ("setRef:")]
		void SetRef (string aRef);

		// @required @property (copy, nonatomic) NSString * pageID;
		[Abstract]
		[Export ("pageID")]
		string PageId { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * shareUUID;
		[Abstract]
		[Export ("shareUUID")]
		string ShareUuid { get; }

		// @required -(NSDictionary<NSString *,id> *)addParameters:(NSDictionary<NSString *,id> *)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions;
		[Abstract]
		[Export ("addParameters:bridgeOptions:")]
		NSDictionary<NSString, NSObject> AddParameters (NSDictionary<NSString, NSObject> existingParameters, ShareBridgeOptions bridgeOptions);
	}

	interface ISharingScheme { }

	// @protocol FBSDKSharingScheme
	[Obsolete ("`SharingScheme` is deprecated and will be removed in the next major release.")]
	[Protocol (Name = "FBSDKSharingScheme")]
	interface SharingScheme {
		// @required -(NSString * _Nullable)schemeForMode:(FBSDKShareDialogMode)mode;
		[Abstract]
		[return: NullAllowed]
		[Export ("schemeForMode:")]
		string GetScheme (ShareDialogMode mode);
	}

	interface ISharingValidation { }

	// @protocol FBSDKSharingValidation
	[Protocol (Name = "FBSDKSharingValidation")]
	interface SharingValidation {
		// @required -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError **)errorRef;
		[Abstract]
		[Export ("validateWithOptions:error:")]
		bool Validate (ShareBridgeOptions bridgeOptions, out NSError errorRef);
	}
}
