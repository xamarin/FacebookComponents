using Foundation;
using ObjCRuntime;
using Photos;
using UIKit;

namespace Facebook.ShareKit
{
    // @interface FBSDKAppGroupContent : NSObject <FBSDKCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKAppGroupContent")]
    interface AppGroupContent : CoreKit.ICopying, INSSecureCoding
    {
        // @property (copy, nonatomic) NSString * _Nonnull groupDescription;
        [Export("groupDescription")] string GroupDescription { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull name;
        [Export("name")] string Name { get; set; }

        // @property (assign, nonatomic) FBSDKAppGroupPrivacy privacy;
        [Export("privacy", ArgumentSemantic.Assign)]
        AppGroupPrivacy Privacy { get; set; }

        // -(BOOL)isEqualToAppGroupContent:(FBSDKAppGroupContent * _Nonnull)content;
        [Export("isEqualToAppGroupContent:")]
        bool Equals(AppGroupContent content);
    }

    // @interface FBSDKAppInviteContent : NSObject <FBSDKCopying, FBSDKSharingValidation, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKAppInviteContent")]
    interface AppInviteContent : CoreKit.ICopying, SharingValidation, INSSecureCoding
    {
        // @property (copy, nonatomic) NSURL * _Nullable appInvitePreviewImageURL;
        [NullAllowed, Export("appInvitePreviewImageURL", ArgumentSemantic.Copy)]
        NSUrl AppInvitePreviewImageUrl { get; set; }

        // @property (copy, nonatomic) NSURL * _Nonnull appLinkURL;
        [Export("appLinkURL", ArgumentSemantic.Copy)]
        NSUrl AppLinkUrl { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable promotionCode;
        [NullAllowed, Export("promotionCode")] string PromotionCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable promotionText;
        [NullAllowed, Export("promotionText")] string PromotionText { get; set; }

        // @property (assign, nonatomic) FBSDKAppInviteDestination destination;
        [Export("destination", ArgumentSemantic.Assign)]
        AppInviteDestination Destination { get; set; }

        // -(BOOL)isEqualToAppInviteContent:(FBSDKAppInviteContent * _Nonnull)content;
        [Export("isEqualToAppInviteContent:")]
        bool Equals(AppInviteContent content);
    }

    // @interface FBSDKCameraEffectArguments : NSObject <FBSDKCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKCameraEffectArguments")]
    interface CameraEffectArguments : CoreKit.ICopying, INSSecureCoding
    {
        // -(void)setString:(NSString * _Nullable)string forKey:(NSString * _Nonnull)key __attribute__((swift_name("set(_:forKey:)")));
        [Export("setString:forKey:")]
        void SetString([NullAllowed] string @string, string key);

        // -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key;
        [Export("stringForKey:")]
        [return: NullAllowed]
        string StringForKey(string key);

        // -(void)setArray:(NSArray<NSString *> * _Nullable)array forKey:(NSString * _Nonnull)key __attribute__((swift_name("set(_:forKey:)")));
        [Export("setArray:forKey:")]
        void SetArray([NullAllowed] string[] array, string key);

        // -(NSArray<NSString *> * _Nullable)arrayForKey:(NSString * _Nonnull)key;
        [Export("arrayForKey:")]
        [return: NullAllowed]
        string[] ArrayForKey(string key);
    }

    // @interface FBSDKCameraEffectTextures : NSObject <FBSDKCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKCameraEffectTextures")]
    interface CameraEffectTextures : CoreKit.ICopying, INSSecureCoding
    {
        // -(void)setImage:(UIImage * _Nullable)image forKey:(NSString * _Nonnull)key __attribute__((swift_name("set(_:forKey:)")));
        [Export("setImage:forKey:")]
        void SetImage([NullAllowed] UIImage image, string key);

        // -(UIImage * _Nullable)imageForKey:(NSString * _Nonnull)key;
        [Export("imageForKey:")]
        [return: NullAllowed]
        UIImage ImageForKey(string key);
    }

    // @interface FBSDKGameRequestContent : NSObject <FBSDKCopying, FBSDKSharingValidation, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKGameRequestContent")]
    interface GameRequestContent : CoreKit.ICopying, SharingValidation, INSSecureCoding
    {
        // @property (assign, nonatomic) FBSDKGameRequestActionType actionType;
        [Export("actionType", ArgumentSemantic.Assign)]
        GameRequestActionType ActionType { get; set; }

        // -(BOOL)isEqualToGameRequestContent:(FBSDKGameRequestContent * _Nonnull)content;
        [Export("isEqualToGameRequestContent:")]
        bool Equals(GameRequestContent content);

        // @property (copy, nonatomic) NSString * _Nullable data;
        [NullAllowed, Export("data")] string Data { get; set; }

        // @property (assign, nonatomic) FBSDKGameRequestFilter filters;
        [Export("filters", ArgumentSemantic.Assign)]
        GameRequestFilter Filters { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull message;
        [Export("message")] string Message { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull objectID;
        [Export("objectID")] string ObjectID { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nonnull recipients;
        [Export("recipients", ArgumentSemantic.Copy)]
        string[] Recipients { get; set; }

        // @property (copy, nonatomic) NSArray<NSString *> * _Nonnull recipientSuggestions;
        [Export("recipientSuggestions", ArgumentSemantic.Copy)]
        string[] RecipientSuggestions { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull title;
        [Export("title")] string Title { get; set; }
    }

    // @interface FBSDKGameRequestDialog : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGameRequestDialog")]
    [DisableDefaultCtor]
    interface GameRequestDialog
    {
        // +(instancetype _Nonnull)dialogWithContent:(FBSDKGameRequestContent * _Nonnull)content delegate:(id<FBSDKGameRequestDialogDelegate> _Nullable)delegate __attribute__((swift_name("init(content:delegate:)")));
        [Static]
        [Export("dialogWithContent:delegate:")]
        GameRequestDialog DialogWithContent(GameRequestContent content, [NullAllowed] GameRequestDialogDelegate @delegate);

        // +(instancetype _Nonnull)showWithContent:(FBSDKGameRequestContent * _Nonnull)content delegate:(id<FBSDKGameRequestDialogDelegate> _Nullable)delegate __attribute__((availability(swift, unavailable)));
        [Static]
        [Export("showWithContent:delegate:")]
        GameRequestDialog ShowWithContent(GameRequestContent content, [NullAllowed] GameRequestDialogDelegate @delegate);

        [Wrap("WeakDelegate")] [NullAllowed] GameRequestDialogDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FBSDKGameRequestDialogDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (copy, nonatomic) FBSDKGameRequestContent * _Nonnull content;
        [Export("content", ArgumentSemantic.Copy)]
        GameRequestContent Content { get; set; }

        // @property (getter = isFrictionlessRequestsEnabled, assign, nonatomic) BOOL frictionlessRequestsEnabled;
        [Export("frictionlessRequestsEnabled")]
        bool FrictionlessRequestsEnabled
        {
            [Bind("isFrictionlessRequestsEnabled")]
            get;
            set;
        }

        // @property (readonly, nonatomic) BOOL canShow;
        [Export("canShow")] bool CanShow { get; }

        // -(BOOL)show;
        [Export("show")]
        bool Show();

        // -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)errorRef;
        [Export("validateWithError:")]
        bool ValidateWithError([NullAllowed] out NSError errorRef);
    }

    // @protocol FBSDKGameRequestDialogDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "FBSDKGameRequestDialogDelegate")]
    interface GameRequestDialogDelegate
    {
        // @required -(void)gameRequestDialog:(FBSDKGameRequestDialog * _Nonnull)gameRequestDialog didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
        [Abstract]
        [Export("gameRequestDialog:didCompleteWithResults:")]
        void GameRequestDialog(GameRequestDialog gameRequestDialog, NSDictionary<NSString, NSObject> results);

        // @required -(void)gameRequestDialog:(FBSDKGameRequestDialog * _Nonnull)gameRequestDialog didFailWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("gameRequestDialog:didFailWithError:")]
        void GameRequestDialog(GameRequestDialog gameRequestDialog, NSError error);

        // @required -(void)gameRequestDialogDidCancel:(FBSDKGameRequestDialog * _Nonnull)gameRequestDialog;
        [Abstract]
        [Export("gameRequestDialogDidCancel:")]
        void GameRequestDialogDidCancel(GameRequestDialog gameRequestDialog);
    }

    // @interface FBSDKHashtag : NSObject <FBSDKCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKHashtag")]
    interface Hashtag : CoreKit.ICopying, INSSecureCoding
    {
        // +(instancetype _Nonnull)hashtagWithString:(NSString * _Nonnull)hashtagString __attribute__((swift_name("init(_:)")));
        [Static]
        [Export("hashtagWithString:")]
        Hashtag HashtagWithString(string hashtagString);

        // @property (copy, nonatomic) NSString * _Nonnull stringRepresentation;
        [Export("stringRepresentation")] string StringRepresentation { get; set; }

        // @property (readonly, getter = isValid, assign, nonatomic) BOOL valid;
        [Export("valid")] bool Valid { [Bind("isValid")] get; }

        // -(BOOL)isEqualToHashtag:(FBSDKHashtag * _Nonnull)hashtag;
        [Export("isEqualToHashtag:")]
        bool Equals(Hashtag hashtag);
    }

    // @protocol FBSDKLiking <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "FBSDKLiking")]
    interface Liking
    {
        // @required @property (copy, nonatomic) NSString * _Nonnull objectID;
        [Abstract] [Export("objectID")] string ObjectID { get; set; }

        // @required @property (assign, nonatomic) FBSDKLikeObjectType objectType;
        [Abstract]
        [Export("objectType", ArgumentSemantic.Assign)]
        LikeObjectType ObjectType { get; set; }
    }

    // @interface FBSDKMessageDialog : NSObject <FBSDKSharingDialog>
    [BaseType(typeof(NSObject), Name = "FBSDKMessageDialog")]
    interface MessageDialog : SharingDialog
    {
        // +(instancetype _Nonnull)dialogWithContent:(id<FBSDKSharingContent> _Nonnull)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((swift_name("init(content:delegate:)")));
        [Static]
        [Export("dialogWithContent:delegate:")]
        MessageDialog Create(ISharingContent content, [NullAllowed] SharingDelegate @delegate);

        // +(instancetype _Nonnull)showWithContent:(id<FBSDKSharingContent> _Nonnull)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((availability(swift, unavailable)));
        [Static]
        [Export("showWithContent:delegate:")]
        MessageDialog Show(ISharingContent content, [NullAllowed] SharingDelegate @delegate);
    }

    // @interface FBSDKSendButton : FBSDKButton <FBSDKSharingButton>
    [BaseType(typeof(CoreKit.Button), Name = "FBSDKSendButton")]
    interface SendButton : SharingButton
    {
    }

    // @interface FBSDKShareButton : FBSDKButton <FBSDKSharingButton>
    [BaseType(typeof(CoreKit.Button), Name = "FBSDKShareButton")]
    interface ShareButton : SharingButton
    {
    }

    // @interface FBSDKShareCameraEffectContent : NSObject <FBSDKSharingContent, FBSDKSharingScheme>
    [BaseType(typeof(NSObject), Name = "FBSDKShareCameraEffectContent")]
    interface ShareCameraEffectContent : SharingContent, SharingScheme
    {
        // @property (copy, nonatomic) NSString * _Nonnull effectID;
        [Export("effectID")] string EffectID { get; set; }

        // @property (copy, nonatomic) FBSDKCameraEffectArguments * _Nonnull effectArguments;
        [Export("effectArguments", ArgumentSemantic.Copy)]
        CameraEffectArguments EffectArguments { get; set; }

        // @property (copy, nonatomic) FBSDKCameraEffectTextures * _Nonnull effectTextures;
        [Export("effectTextures", ArgumentSemantic.Copy)]
        CameraEffectTextures EffectTextures { get; set; }

        // -(BOOL)isEqualToShareCameraEffectContent:(FBSDKShareCameraEffectContent * _Nonnull)content;
        [Export("isEqualToShareCameraEffectContent:")]
        bool Equals(ShareCameraEffectContent content);
    }

    // @interface FBSDKShareDialog : NSObject <FBSDKSharingDialog>
    [BaseType(typeof(NSObject), Name = "FBSDKShareDialog")]
    interface ShareDialog : SharingDialog
    {
        // +(instancetype _Nonnull)dialogWithViewController:(UIViewController * _Nullable)viewController withContent:(id<FBSDKSharingContent> _Nonnull)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((swift_name("init(fromViewController:content:delegate:)")));
        [Static]
        [Export("dialogWithViewController:withContent:delegate:")]
        ShareDialog DialogWithViewController([NullAllowed] UIViewController viewController, ISharingContent content, [NullAllowed] SharingDelegate @delegate);

        // +(instancetype _Nonnull)showFromViewController:(UIViewController * _Nonnull)viewController withContent:(id<FBSDKSharingContent> _Nonnull)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((availability(swift, unavailable)));
        [Static]
        [Export("showFromViewController:withContent:delegate:")]
        ShareDialog ShowFromViewController(UIViewController viewController, ISharingContent content, [NullAllowed] SharingDelegate @delegate);

        // @property (nonatomic, weak) UIViewController * _Nullable fromViewController;
        [NullAllowed, Export("fromViewController", ArgumentSemantic.Weak)]
        UIViewController FromViewController { get; set; }

        // @property (assign, nonatomic) FBSDKShareDialogMode mode;
        [Export("mode", ArgumentSemantic.Assign)]
        ShareDialogMode Mode { get; set; }
    }

    // @interface FBSDKShareLinkContent : NSObject <FBSDKSharingContent>
    [BaseType(typeof(NSObject), Name = "FBSDKShareLinkContent")]
    interface ShareLinkContent : SharingContent
    {
        // @property (copy, nonatomic) NSString * _Nullable quote;
        [NullAllowed, Export("quote")] string Quote { get; set; }

        // -(BOOL)isEqualToShareLinkContent:(FBSDKShareLinkContent * _Nonnull)content;
        [Export("isEqualToShareLinkContent:")]
        bool Equals(ShareLinkContent content);
    }

    // @protocol FBSDKShareMedia <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "FBSDKShareMedia")]
    interface ShareMedia
    {
    }

    // @interface FBSDKShareMediaContent : NSObject <FBSDKSharingContent>
    [BaseType(typeof(NSObject), Name = "FBSDKShareMediaContent")]
    interface ShareMediaContent : SharingContent
    {
        // @property (copy, nonatomic) NSArray<id<FBSDKShareMedia>> * _Nonnull media;
        [Export("media", ArgumentSemantic.Copy)]
        ShareMedia[] Media { get; set; }

        // -(BOOL)isEqualToShareMediaContent:(FBSDKShareMediaContent * _Nonnull)content;
        [Export("isEqualToShareMediaContent:")]
        bool Equals(ShareMediaContent content);
    }

    // @interface FBSDKSharePhoto : NSObject <NSSecureCoding, FBSDKCopying, FBSDKShareMedia, FBSDKSharingValidation>
    [BaseType(typeof(NSObject), Name = "FBSDKSharePhoto")]
    interface SharePhoto : INSSecureCoding, CoreKit.ICopying, ShareMedia, SharingValidation
    {
        // +(instancetype _Nonnull)photoWithImage:(UIImage * _Nonnull)image userGenerated:(BOOL)userGenerated;
        [Static]
        [Export("photoWithImage:userGenerated:")]
        SharePhoto PhotoWithImage(UIImage image, bool userGenerated);

        // +(instancetype _Nonnull)photoWithImageURL:(NSURL * _Nonnull)imageURL userGenerated:(BOOL)userGenerated;
        [Static]
        [Export("photoWithImageURL:userGenerated:")]
        SharePhoto PhotoWithImageUrl(NSUrl imageUrl, bool userGenerated);

        // +(instancetype _Nonnull)photoWithPhotoAsset:(PHAsset * _Nonnull)photoAsset userGenerated:(BOOL)userGenerated;
        [Static]
        [Export("photoWithPhotoAsset:userGenerated:")]
        SharePhoto PhotoWithPhotoAsset(PHAsset photoAsset, bool userGenerated);

        // @property (nonatomic, strong) UIImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable imageURL;
        [NullAllowed, Export("imageURL", ArgumentSemantic.Copy)]
        NSUrl ImageUrl { get; set; }

        // @property (copy, nonatomic) PHAsset * _Nullable photoAsset;
        [NullAllowed, Export("photoAsset", ArgumentSemantic.Copy)]
        PHAsset PhotoAsset { get; set; }

        // @property (getter = isUserGenerated, assign, nonatomic) BOOL userGenerated;
        [Export("userGenerated")] bool UserGenerated { [Bind("isUserGenerated")] get; set; }

        // @property (copy, nonatomic) NSString * _Nullable caption;
        [NullAllowed, Export("caption")] string Caption { get; set; }

        // -(BOOL)isEqualToSharePhoto:(FBSDKSharePhoto * _Nonnull)photo;
        [Export("isEqualToSharePhoto:")]
        bool Equals(SharePhoto photo);
    }

    // @interface FBSDKSharePhotoContent : NSObject <FBSDKSharingContent>
    [BaseType(typeof(NSObject), Name = "FBSDKSharePhotoContent")]
    interface SharePhotoContent : SharingContent
    {
        // @property (copy, nonatomic) NSArray<FBSDKSharePhoto *> * _Nonnull photos;
        [Export("photos", ArgumentSemantic.Copy)]
        SharePhoto[] Photos { get; set; }

        // -(BOOL)isEqualToSharePhotoContent:(FBSDKSharePhotoContent * _Nonnull)content;
        [Export("isEqualToSharePhotoContent:")]
        bool Equals(SharePhotoContent content);
    }

    // @interface FBSDKShareVideo : NSObject <NSSecureCoding, FBSDKCopying, FBSDKShareMedia, FBSDKSharingValidation>
    [BaseType(typeof(NSObject), Name = "FBSDKShareVideo")]
    interface ShareVideo : INSSecureCoding, CoreKit.ICopying, ShareMedia, SharingValidation
    {
        // +(instancetype _Nonnull)videoWithData:(NSData * _Nonnull)data;
        [Static]
        [Export("videoWithData:")]
        ShareVideo VideoWithData(NSData data);

        // +(instancetype _Nonnull)videoWithData:(NSData * _Nonnull)data previewPhoto:(FBSDKSharePhoto * _Nonnull)previewPhoto;
        [Static]
        [Export("videoWithData:previewPhoto:")]
        ShareVideo VideoWithData(NSData data, SharePhoto previewPhoto);

        // +(instancetype _Nonnull)videoWithVideoAsset:(PHAsset * _Nonnull)videoAsset;
        [Static]
        [Export("videoWithVideoAsset:")]
        ShareVideo VideoWithVideoAsset(PHAsset videoAsset);

        // +(instancetype _Nonnull)videoWithVideoAsset:(PHAsset * _Nonnull)videoAsset previewPhoto:(FBSDKSharePhoto * _Nonnull)previewPhoto;
        [Static]
        [Export("videoWithVideoAsset:previewPhoto:")]
        ShareVideo VideoWithVideoAsset(PHAsset videoAsset, SharePhoto previewPhoto);

        // +(instancetype _Nonnull)videoWithVideoURL:(NSURL * _Nonnull)videoURL;
        [Static]
        [Export("videoWithVideoURL:")]
        ShareVideo VideoWithVideoUrl(NSUrl videoUrl);

        // +(instancetype _Nonnull)videoWithVideoURL:(NSURL * _Nonnull)videoURL previewPhoto:(FBSDKSharePhoto * _Nonnull)previewPhoto;
        [Static]
        [Export("videoWithVideoURL:previewPhoto:")]
        ShareVideo VideoWithVideoUrl(NSUrl videoUrl, SharePhoto previewPhoto);

        // @property (nonatomic, strong) NSData * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Strong)]
        NSData Data { get; set; }

        // @property (copy, nonatomic) PHAsset * _Nullable videoAsset;
        [NullAllowed, Export("videoAsset", ArgumentSemantic.Copy)]
        PHAsset VideoAsset { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable videoURL;
        [NullAllowed, Export("videoURL", ArgumentSemantic.Copy)]
        NSUrl VideoUrl { get; set; }

        // @property (copy, nonatomic) FBSDKSharePhoto * _Nullable previewPhoto;
        [NullAllowed, Export("previewPhoto", ArgumentSemantic.Copy)]
        SharePhoto PreviewPhoto { get; set; }

        // -(BOOL)isEqualToShareVideo:(FBSDKShareVideo * _Nonnull)video;
        [Export("isEqualToShareVideo:")]
        bool Equals(ShareVideo video);
    }

    // @interface FBSDKShareVideo (PHAsset)
    [Category]
    [BaseType(typeof(PHAsset))]
    interface PHAsset_FBSDKShareVideo
    {
        // @property (readonly, copy, nonatomic) NSURL * _Nonnull videoURL;
        [Export("videoURL", ArgumentSemantic.Copy)]
        NSUrl GetVideoUrl();
    }

    // @interface FBSDKShareVideoContent : NSObject <FBSDKSharingContent>
    [BaseType(typeof(NSObject), Name = "FBSDKShareVideoContent")]
    interface ShareVideoContent : SharingContent
    {
        // @property (copy, nonatomic) FBSDKShareVideo * _Nonnull video;
        [Export("video", ArgumentSemantic.Copy)]
        ShareVideo Video { get; set; }

        // -(BOOL)isEqualToShareVideoContent:(FBSDKShareVideoContent * _Nonnull)content;
        [Export("isEqualToShareVideoContent:")]
        bool Equals(ShareVideoContent content);
    }

    // @protocol FBSDKSharing <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "FBSDKSharing")]
    interface Sharing
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SharingDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<FBSDKSharingDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required @property (copy, nonatomic) id<FBSDKSharingContent> _Nonnull shareContent;
        [Abstract]
        [Export("shareContent", ArgumentSemantic.Copy)]
        ISharingContent ShareContent { get; set; }

        // @required @property (assign, nonatomic) BOOL shouldFailOnDataError;
        [Abstract]
        [Export("shouldFailOnDataError")]
        bool ShouldFailOnDataError { get; set; }

        // @required -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)errorRef;
        [Abstract]
        [Export("validateWithError:")]
        bool Validate([NullAllowed] out NSError errorRef);
    }

    // @protocol FBSDKSharingDialog <FBSDKSharing>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "FBSDKSharingDialog")]
    interface SharingDialog : Sharing
    {
        // @required @property (readonly, nonatomic) BOOL canShow;
        [Abstract] [Export("canShow")] bool CanShow { get; }

        // @required -(BOOL)show;
        [Abstract]
        [Export("show")]
        bool Show();
    }

    // @protocol FBSDKSharingDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "FBSDKSharingDelegate")]
    interface SharingDelegate
    {
        // @required -(void)sharer:(id<FBSDKSharing> _Nonnull)sharer didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
        [Abstract]
        [Export("sharer:didCompleteWithResults:")]
        void DidComplete(Sharing sharer, NSDictionary<NSString, NSObject> results);

        // @required -(void)sharer:(id<FBSDKSharing> _Nonnull)sharer didFailWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("sharer:didFailWithError:")]
        void DidFail(Sharing sharer, NSError error);

        // @required -(void)sharerDidCancel:(id<FBSDKSharing> _Nonnull)sharer;
        [Abstract]
        [Export("sharerDidCancel:")]
        void DidCancel(Sharing sharer);
    }

    // @protocol FBSDKSharingButton <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "FBSDKSharingButton")]
    interface SharingButton
    {
        // @required @property (copy, nonatomic) id<FBSDKSharingContent> _Nullable shareContent;
        [Abstract]
        [NullAllowed, Export("shareContent", ArgumentSemantic.Copy)]
        ISharingContent ShareContent { get; set; }
    }

    // @protocol FBSDKSharingScheme
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "FBSDKSharingScheme")]
    interface SharingScheme
    {
        // @required -(NSString * _Nullable)schemeForMode:(FBSDKShareDialogMode)mode;
        [Abstract]
        [Export("schemeForMode:")]
        [return: NullAllowed]
        string SchemeForMode(ShareDialogMode mode);
    }

    // @protocol FBSDKSharingValidation
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "FBSDKSharingValidation")]
    interface SharingValidation
    {
        // @required -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)bridgeOptions error:(NSError * _Nullable * _Nullable)errorRef;
        [Abstract]
        [Export("validateWithOptions:error:")]
        bool Error(ShareBridgeOptions bridgeOptions, [NullAllowed] out NSError errorRef);
    }

    [Static]
    partial interface Errors
    {
        // extern NS_SWIFT_NAME(ShareErrorDomain) const NSErrorDomain FBSDKShareErrorDomain __attribute__((swift_name("ShareErrorDomain")));
        [Field("FBSDKShareErrorDomain", "__Internal")]
        NSString ShareErrorDomain { get; }
    }

    interface ISharingContent
    {
    }

    // @protocol FBSDKSharingContent <FBSDKCopying, FBSDKSharingValidation, NSSecureCoding>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "FBSDKSharingContent")]
    interface SharingContent : CoreKit.ICopying, SharingValidation, INSSecureCoding
    {
        // @required @property (copy, nonatomic) NSURL * _Nonnull contentURL;
        [Abstract]
        [Export("contentURL", ArgumentSemantic.Copy)]
        NSUrl ContentUrl { get; set; }

        // @required @property (copy, nonatomic) FBSDKHashtag * _Nullable hashtag;
        [Abstract]
        [NullAllowed, Export("hashtag", ArgumentSemantic.Copy)]
        Hashtag Hashtag { get; set; }

        // @required @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
        [Abstract]
        [Export("peopleIDs", ArgumentSemantic.Copy)]
        string[] PeopleIDs { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable placeID;
        [Abstract]
        [NullAllowed, Export("placeID")]
        string PlaceID { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable ref;
        [Abstract]
        [NullAllowed, Export("ref")]
        string Ref { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable pageID;
        [Abstract]
        [NullAllowed, Export("pageID")]
        string PageID { get; set; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
        [Abstract]
        [NullAllowed, Export("shareUUID")]
        string ShareUUID { get; }

        // @required -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((swift_name("addParameters(_:options:)")));
        [Abstract]
        [Export("addParameters:bridgeOptions:")]
        NSDictionary<NSString, NSObject> AddParameters(NSDictionary<NSString, NSObject> existingParameters, ShareBridgeOptions bridgeOptions);
    }

    [Static]
    partial interface ShareKitVersionConstants
    {
        // extern double FBSDKShareKitVersionNumber;
        [Field("FBSDKShareKitVersionNumber", "__Internal")]
        double VersionNumber { get; }

        // extern const unsigned char [] FBSDKShareKitVersionString;
        [Field("FBSDKShareKitVersionString", "__Internal")]
        NSString VersionString { get; }
    }
}
