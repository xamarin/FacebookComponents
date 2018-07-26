using System;

using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace Facebook.CoreKit {
	interface AccessTokenDidChangeEventArgs {
		[Export ("FBSDKAccessTokenChangeNewKey")]
		AccessToken NewToken { get; }

		[Export ("FBSDKAccessTokenDidChangeUserID")]
		bool DidChangeUserIdToken { get; }

		[Export ("FBSDKAccessTokenChangeOldKey")]
		AccessToken OldToken { get; }

		[Export ("FBSDKAccessTokenDidExpire")]
		bool DidExpireKey { get; }
	}

	// @interface FBSDKAccessToken : NSObject <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAccessToken")]
	interface AccessToken : Copying, INSSecureCoding {

		// extern NSString *const FBSDKAccessTokenDidChangeNotification;
		[Notification (typeof (AccessTokenDidChangeEventArgs))]
		[Field ("FBSDKAccessTokenDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		[Field ("FBSDKAccessTokenChangeNewKey", "__Internal")]
		NSString NewTokenKey { get; }

		[Field ("FBSDKAccessTokenDidChangeUserID", "__Internal")]
		NSString UserIdKey { get; }

		[Field ("FBSDKAccessTokenChangeOldKey", "__Internal")]
		NSString OldTokenKey { get; }

		// FBSDK_EXTERN NSString *const FBSDKAccessTokenDidExpire;
		[Field ("FBSDKAccessTokenDidExpire", "__Internal")]
		NSString DidExpireKey { get; }

		// @property (readonly, copy, nonatomic) NSString * appID;
		[Export ("appID")]
		string AppId { get; }

		[Obsolete ("Use AppId property instead. This will be removed in future versions.")]
		[Wrap ("AppId")]
		string AppID { get; }

		// @property (readonly, copy, nonatomic) NSSet * declinedPermissions;
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet DeclinedPermissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NSSet * permissions;
		[Export ("permissions", ArgumentSemantic.Copy)]
		NSSet Permissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * refreshDate;
		[Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID", ArgumentSemantic.Copy)]
		string UserId { get; }

		[Obsolete ("Use UserId property instead. This will be removed in future versions.")]
		[Wrap ("UserID")]
		string UserID { get; }

		// @property (readonly, assign, nonatomic, getter = isExpired) BOOL expired;
		[Export ("isExpired", ArgumentSemantic.Assign)]
		bool IsExpired { get; }

		// -(instancetype)initWithTokenString:(NSString *)tokenString permissions:(NSArray *)permissions declinedPermissions:(NSArray *)declinedPermissions appID:(NSString *)appID userID:(NSString *)userID expirationDate:(NSDate *)expirationDate refreshDate:(NSDate *)refreshDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithTokenString:permissions:declinedPermissions:appID:userID:expirationDate:refreshDate:")]
		IntPtr Constructor (string tokenString, [NullAllowed] string [] permissions, [NullAllowed] string [] declinedPermissions, string appId, string userId, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate);

		// -(BOOL)hasGranted:(NSString *)permission;
		[Export ("hasGranted:")]
		bool HasGranted (string permission);

		// -(BOOL)isEqualToAccessToken:(FBSDKAccessToken *)token;
		[Export ("isEqualToAccessToken:")]
		bool IsEqualToAccessToken (AccessToken token);

		// +(FBSDKAccessToken *)currentAccessToken;
		// +(void)setCurrentAccessToken:(FBSDKAccessToken *)token;
		[Static]
		[Export ("currentAccessToken")]
		AccessToken CurrentAccessToken { get; set; }

		// + (BOOL)currentAccessTokenIsActive;
		[Static]
		[Export ("currentAccessTokenIsActive")]
		bool CurrentAccessTokenIsActive { get; }

		// + (void)refreshCurrentAccessToken:(FBSDKGraphRequestHandler)completionHandler;
		[Static]
		[Export ("refreshCurrentAccessToken:")]
		void RefreshCurrentAccessToken (GraphRequestHandler completionHandler);
	}

	// @interface FBSDKAppEvents : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppEvents")]
	interface AppEvents {

		// extern NSString *const FBSDKAppEventsLoggingResultNotification;
		[Notification]
		[Field ("FBSDKAppEventsLoggingResultNotification", "__Internal")]
		NSString LoggingResultNotification { get; }

		// extern NSString *const FBSDKAppEventsOverrideAppIDBundleKey;
		[Field ("FBSDKAppEventsOverrideAppIDBundleKey", "__Internal")]
		NSString OverrideAppIdBundleKey { get; }

		// extern NSString *const FBSDKAppEventNameAchievedLevel;
		[Field ("FBSDKAppEventNameAchievedLevel", "__Internal")]
		NSString AchievedLevelEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedPaymentInfo;
		[Field ("FBSDKAppEventNameAddedPaymentInfo", "__Internal")]
		NSString AddedPaymentInfoEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedToCart;
		[Field ("FBSDKAppEventNameAddedToCart", "__Internal")]
		NSString AddedToCartEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedToWishlist;
		[Field ("FBSDKAppEventNameAddedToWishlist", "__Internal")]
		NSString AddedToWishlistEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCompletedRegistration;
		[Field ("FBSDKAppEventNameCompletedRegistration", "__Internal")]
		NSString CompletedRegistrationEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCompletedTutorial;
		[Field ("FBSDKAppEventNameCompletedTutorial", "__Internal")]
		NSString CompletedTutorialEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameInitiatedCheckout;
		[Field ("FBSDKAppEventNameInitiatedCheckout", "__Internal")]
		NSString InitiatedCheckoutEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameRated;
		[Field ("FBSDKAppEventNameRated", "__Internal")]
		NSString RatedEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSearched;
		[Field ("FBSDKAppEventNameSearched", "__Internal")]
		NSString SearchedEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSpentCredits;
		[Field ("FBSDKAppEventNameSpentCredits", "__Internal")]
		NSString SpentCreditsEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameUnlockedAchievement;
		[Field ("FBSDKAppEventNameUnlockedAchievement", "__Internal")]
		NSString UnlockedAchievementEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameViewedContent;
		[Field ("FBSDKAppEventNameViewedContent", "__Internal")]
		NSString ViewedContentEventNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContent;
		[Field ("FBSDKAppEventParameterNameContent", "__Internal")]
		NSString ContentParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContentID;
		[Field ("FBSDKAppEventParameterNameContentID", "__Internal")]
		NSString ContentIdParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContentType;
		[Field ("FBSDKAppEventParameterNameContentType", "__Internal")]
		NSString ContentTypeParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameCurrency;
		[Field ("FBSDKAppEventParameterNameCurrency", "__Internal")]
		NSString CurrencyParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameDescription;
		[Field ("FBSDKAppEventParameterNameDescription", "__Internal")]
		NSString DescriptionParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameLevel;
		[Field ("FBSDKAppEventParameterNameLevel", "__Internal")]
		NSString LevelParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameMaxRatingValue;
		[Field ("FBSDKAppEventParameterNameMaxRatingValue", "__Internal")]
		NSString MaxRatingValueParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameNumItems;
		[Field ("FBSDKAppEventParameterNameNumItems", "__Internal")]
		NSString NumItemsParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNamePaymentInfoAvailable;
		[Field ("FBSDKAppEventParameterNamePaymentInfoAvailable", "__Internal")]
		NSString PaymentInfoAvailableParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameRegistrationMethod;
		[Field ("FBSDKAppEventParameterNameRegistrationMethod", "__Internal")]
		NSString RegistrationMethodParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameSearchString;
		[Field ("FBSDKAppEventParameterNameSearchString", "__Internal")]
		NSString SearchStringParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameSuccess;
		[Field ("FBSDKAppEventParameterNameSuccess", "__Internal")]
		NSString SuccessParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterValueYes;
		[Field ("FBSDKAppEventParameterValueYes", "__Internal")]
		NSString YesParameterValueKey { get; }

		// extern NSString *const FBSDKAppEventParameterValueNo;
		[Field ("FBSDKAppEventParameterValueNo", "__Internal")]
		NSString NoParameterValueKey { get; }

		// +(void)logEvent:(NSString *)eventName;
		[Static]
		[Export ("logEvent:")]
		void LogEvent (string eventName);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum;
		[Static]
		[Export ("logEvent:valueToSum:")]
		void LogEvent (string eventName, double valueToSum);

		// +(void)logEvent:(NSString *)eventName parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logEvent:parameters:")]
		void LogEvent (string eventName, NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (string eventName, double valueToSum, [NullAllowed] NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(NSNumber *)valueToSum parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("logEvent:valueToSum:parameters:accessToken:")]
		void LogEvent (string eventName, NSNumber valueToSum, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency;
		[Static]
		[Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("logPurchase:currency:parameters:accessToken:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// + (void)logPushNotificationOpen:(NSDictionary *)payload;
		[Static]
		[Export ("logPushNotificationOpen:")]
		void LogPushNotificationOpen (NSDictionary payload);

		// + (void)logPushNotificationOpen:(NSDictionary *)payload action:(NSString *)action;
		[Static]
		[Export ("logPushNotificationOpen:action:")]
		void LogPushNotificationOpen (NSDictionary payload, string action);

		// +(void)activateApp;
		[Static]
		[Export ("activateApp")]
		void ActivateApp ();

		// + (void)setPushNotificationsDeviceToken:(NSData *)deviceToken;
		[Static]
		[Export ("setPushNotificationsDeviceToken:")]
		void SetPushNotificationsDeviceToken (NSData deviceToken);

		// +(FBSDKAppEventsFlushBehavior)flushBehavior;
		// +(void)setFlushBehavior:(FBSDKAppEventsFlushBehavior)flushBehavior;
		[Static]
		[Export ("flushBehavior")]
		AppEventsFlushBehavior FlushBehavior { get; set; }

		// +(NSString *)loggingOverrideAppID;
		// +(void)setLoggingOverrideAppID:(NSString *)appID;
		[Static]
		[Export ("loggingOverrideAppID")]
		string LoggingOverrideAppID { get; set; }

		// +(void)flush;
		[Static]
		[Export ("flush")]
		void Flush ();

		// +(FBSDKGraphRequest *)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
		GraphRequest RequestForCustomAudienceThirdPartyId (AccessToken accessToken);

		// +(void)setUserID:(NSString *)userID;
		// +(NSString *)userID;
		[Static]
		[NullAllowed]
		[Export ("userID")]
		string UserId { get; set; }

		[Obsolete ("Use UserId property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("UserId")]
		string UserID { get; set; }

		// +(void)updateUserProperties:(NSDictionary *)properties handler:(FBSDKGraphRequestHandler)handler;
		[Static]
		[Export ("updateUserProperties:handler:")]
		void UpdateUserProperties (NSDictionary properties, [NullAllowed]GraphRequestHandler handler);

		// +(void)augmentHybridWKWebView:(WKWebView *)webView;
		[Unavailable (PlatformName.TvOS)]
		[Static]
		[Export ("augmentHybridWKWebView:")]
		void AugmentHybrid (WKWebView webView);
	}

	// @interface FBSDKApplicationDelegate : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKApplicationDelegate")]
	interface ApplicationDelegate {

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ApplicationDelegate SharedInstance { get; }

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool OpenUrl ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;
		[Export ("application:openURL:options:")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary options);

		[Obsolete ("This will be removed in future versions, please, use OpenUrl (UIApplication, NSUrl, NSDictionary) overload method instead.")]
		[Wrap ("OpenUrl (application, url, NSDictionary.FromObjectsAndKeys (options.Values, options.Keys, options.Keys.Length))")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);

		// -(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool FinishedLaunching ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions);
	}

	// @interface FBSDKAppLinkResolver : NSObject<BFAppLinkResolving>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolver")]
	interface AppLinkResolver : AppLinkResolving {

		// - (BFTask *)appLinksFromURLsInBackground:(NSArray *)urls;
		[Export ("appLinksFromURLsInBackground:")]
		Task AppLinksInBackground (NSUrl [] urls);

		// + (instancetype)resolver;
		[Static]
		[Export ("resolver")]
		AppLinkResolver Resolver { get; }
	}

	// typedef void (^FBSDKDeferredAppLinkHandler)(NSURL *, NSError *);
	delegate void DeferredAppLinkHandler (NSUrl url, NSError error);
	// typedef void (^FBSDKDeferredAppInviteHandler)(NSURL *url);
	delegate void DeferredAppInviteHandler (NSUrl url);

	// @interface FBSDKAppLinkUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkUtility")]
	interface AppLinkUtility {

		// +(void)fetchDeferredAppLink:(FBSDKDeferredAppLinkHandler)handler;
		[Static]
		[Async]
		[Export ("fetchDeferredAppLink:")]
		void FetchDeferredAppLink (DeferredAppLinkHandler handler);

		// + (BOOL)fetchDeferredAppInvite:(FBSDKDeferredAppInviteHandler)handler;
		[Static]
		[Export ("fetchDeferredAppInvite:")]
		[Obsolete ("This method is no longer available and will always return NO.")]
		bool FetchDeferredAppInvite (DeferredAppInviteHandler handler);

		// + (NSString*)appInvitePromotionCodeFromURL:(NSURL*)url;
		[Static]
		[Export ("appInvitePromotionCodeFromURL:")]
		string AppInvitePromotionCode (NSUrl url);
	}

	// @interface FBSDKButton : UIButton
	[BaseType (typeof (UIButton), Name = "FBSDKButton")]
	interface Button {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	[Static]
	interface Errors {

		// extern NSString *const FBSDKErrorDomain;
		[Field ("FBSDKErrorDomain", "__Internal")]
		NSString DomainKey { get; }

		// extern NSString *const FBSDKErrorArgumentCollectionKey;
		[Field ("FBSDKErrorArgumentCollectionKey", "__Internal")]
		NSString ArgumentCollectionKey { get; }

		// extern NSString *const FBSDKErrorArgumentNameKey;
		[Field ("FBSDKErrorArgumentNameKey", "__Internal")]
		NSString ArgumentNameKey { get; }

		// extern NSString *const FBSDKErrorArgumentValueKey;
		[Field ("FBSDKErrorArgumentValueKey", "__Internal")]
		NSString ArgumentValueKey { get; }

		// extern NSString *const FBSDKErrorDeveloperMessageKey;
		[Field ("FBSDKErrorDeveloperMessageKey", "__Internal")]
		NSString DeveloperMessageKey { get; }

		// extern NSString *const FBSDKErrorLocalizedDescriptionKey;
		[Field ("FBSDKErrorLocalizedDescriptionKey", "__Internal")]
		NSString LocalizedDescriptionKey { get; }

		// extern NSString *const FBSDKErrorLocalizedTitleKey;
		[Field ("FBSDKErrorLocalizedTitleKey", "__Internal")]
		NSString LocalizedTitleKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorCategoryKey;
		[Field ("FBSDKGraphRequestErrorCategoryKey", "__Internal")]
		NSString CategoryKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorGraphErrorCode;
		[Field ("FBSDKGraphRequestErrorGraphErrorCode", "__Internal")]
		NSString GraphErrorCode { get; }

		// extern NSString *const FBSDKGraphRequestErrorGraphErrorSubcode;
		[Field ("FBSDKGraphRequestErrorGraphErrorSubcode", "__Internal")]
		NSString GraphErrorSubcode { get; }

		// extern NSString *const FBSDKGraphRequestErrorHTTPStatusCodeKey;
		[Field ("FBSDKGraphRequestErrorHTTPStatusCodeKey", "__Internal")]
		NSString HttpStatusCodeKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorParsedJSONResponseKey;
		[Field ("FBSDKGraphRequestErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJSONResponseKey { get; }
	}

	// @protocol FBSDKErrorRecoveryAttempting <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKErrorRecoveryAttempting")]
	interface ErrorRecoveryAttempting {
		// @required -(void)attemptRecoveryFromError:(NSError *)error optionIndex:(NSUInteger)recoveryOptionIndex delegate:(id)delegate didRecoverSelector:(SEL)didRecoverSelector contextInfo:(void *)contextInfo;
		[Abstract]
		[Export ("attemptRecoveryFromError:optionIndex:delegate:didRecoverSelector:contextInfo:")]
		unsafe void AttemptRecovery (NSError error, nuint recoveryOptionIndex, NSObject aDelegate, Selector didRecoverSelector, NSObject contextInfo);
	}

	interface ICopying {

	}

	// @protocol FBSDKCopying <NSCopying, NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKCopying")]
	interface Copying : INSCopying {
		// @required -(id)copy;
		[New]
		[Abstract]
		[Export ("copy")]
		NSObject Copy ();
	}

	interface IGraphErrorRecoveryProcessorDelegate {

	}

	// @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessorDelegate")]
	interface GraphErrorRecoveryProcessorDelegate {

		// @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor *)processor didRecover:(BOOL)didRecover error:(NSError *)error;
		[Abstract]
		[Export ("processorDidAttemptRecovery:didRecover:error:")]
		void DidAttemptRecovery (GraphErrorRecoveryProcessor processor, bool didRecover, NSError error);

		// @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor *)processor error:(NSError *)error;
		[Export ("processorWillProcessError:error:")]
		bool WillProcessError (GraphErrorRecoveryProcessor processor, NSError error);
	}

	// @interface FBSDKGraphErrorRecoveryProcessor : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessor")]
	interface GraphErrorRecoveryProcessor {

		// @property (readonly, nonatomic, strong) id<FBSDKGraphErrorRecoveryProcessorDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Strong)]
		IGraphErrorRecoveryProcessorDelegate Delegate { get; }

		// -(BOOL)processError:(NSError *)error request:(FBSDKGraphRequest *)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate>)delegate;
		[Export ("processError:request:delegate:")]
		bool ProcessError (NSError error, GraphRequest request, [NullAllowed] IGraphErrorRecoveryProcessorDelegate aDelegate);

		// -(void)didPresentErrorWithRecovery:(BOOL)didRecover contextInfo:(void *)contextInfo;
		[Export ("didPresentErrorWithRecovery:contextInfo:")]
		unsafe void ErrorPresentedWithRecovery (bool didRecover, [NullAllowed] NSObject contextInfo);
	}

	// @interface FBSDKGraphRequest : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequest")]
	interface GraphRequest {

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters;
		[Export ("initWithGraphPath:parameters:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters HTTPMethod:(NSString *)HTTPMethod;
		[Export ("initWithGraphPath:parameters:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string httpMethod);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters tokenString:(NSString *)tokenString version:(NSString *)version HTTPMethod:(NSString *)HTTPMethod __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, [NullAllowed] string httpMethod);

		// @property (readonly, nonatomic, strong) NSMutableDictionary * parameters;
		[Export ("parameters", ArgumentSemantic.Strong)]
		NSMutableDictionary Parameters { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * graphPath;
		[Export ("graphPath", ArgumentSemantic.Copy)]
		string GraphPath { get; }

		// @property (readonly, copy, nonatomic) NSString * HTTPMethod;
		[Export ("HTTPMethod", ArgumentSemantic.Copy)]
		string HttpMethod { get; }

		[Obsolete ("Use HttpMethod property instead. This will be removed in future versions.")]
		[Wrap ("HttpMethod")]
		string HTTPMethod { get; }

		// @property (readonly, copy, nonatomic) NSString * version;
		[Export ("version", ArgumentSemantic.Copy)]
		string Version { get; }

		// -(void)setGraphErrorRecoveryDisabled:(BOOL)disable;
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disable);

		// -(FBSDKGraphRequestConnection *)startWithCompletionHandler:(FBSDKGraphRequestHandler)handler;
		[Export ("startWithCompletionHandler:")]
		GraphRequestConnection Start (GraphRequestHandler handler);
	}

	// typedef void (^FBSDKGraphRequestHandler)(FBSDKGraphRequestConnection *id, NSError *);
	delegate void GraphRequestHandler (GraphRequestConnection connection, NSObject result, NSError error);

	interface IGraphRequestConnectionDelegate {

	}

	// @protocol FBSDKGraphRequestConnectionDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestConnectionDelegate")]
	interface GraphRequestConnectionDelegate {

		// @optional -(void)requestConnectionWillBeginLoading:(FBSDKGraphRequestConnection *)connection;
		[EventArgs ("GraphRequestConnectionWillBeginLoading")]
		[Export ("requestConnectionWillBeginLoading:")]
		void WillBeginLoading (GraphRequestConnection connection);

		// @optional -(void)requestConnectionDidFinishLoading:(FBSDKGraphRequestConnection *)connection;
		[EventArgs ("GraphRequestConnectionLoadingFinished")]
		[EventName ("LoadingFinished")]
		[Export ("requestConnectionDidFinishLoading:")]
		void DidFinishLoading (GraphRequestConnection connection);

		// @optional -(void)requestConnection:(FBSDKGraphRequestConnection *)connection didFailWithError:(NSError *)error;
		[EventArgs ("GraphRequestConnectionFailed")]
		[EventName ("Failed")]
		[Export ("requestConnection:didFailWithError:")]
		void DidFail (GraphRequestConnection connection, NSError error);

		// @optional -(void)requestConnection:(FBSDKGraphRequestConnection *)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
		[EventArgs ("GraphRequestConnectionBodyDataSent")]
		[EventName ("BodyDataSent")]
		[Export ("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
		void DidSendBodyData (GraphRequestConnection connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
	}

	// @interface FBSDKGraphRequestConnection : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKGraphRequestConnection",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (GraphRequestConnectionDelegate) })]
	interface GraphRequestConnection {

		// extern NSString *const FBSDKNonJSONResponseProperty;
		[Field ("FBSDKNonJSONResponseProperty", "__Internal")]
		NSString NonJsonResponsePropertyKey { get; }

		// @property (assign, nonatomic) id<FBSDKGraphRequestConnectionDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGraphRequestConnectionDelegate Delegate { get; set; }

		// @property (nonatomic) NSTimeInterval timeout;
		[Export ("timeout")]
		double Timeout { get; set; }

		// @property (readonly, retain, nonatomic) NSHTTPURLResponse * URLResponse;
		[Export ("URLResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		// + (void)setDefaultConnectionTimeout:(NSTimeInterval)defaultConnectionTimeout;
		[Static]
		[Export ("setDefaultConnectionTimeout:")]
		void SetDefaultConnectionTimeout (double defaultConnectionTimeout);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler;
		[Export ("addRequest:completionHandler:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchEntryName:(NSString *)name;
		[Export ("addRequest:completionHandler:batchEntryName:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler, string name);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchParameters:(NSDictionary *)batchParameters;
		[Export ("addRequest:completionHandler:batchParameters:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler, [NullAllowed] NSDictionary batchParameters);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)setDelegateQueue:(NSOperationQueue *)queue;
		[Export ("setDelegateQueue:")]
		void SetDelegateQueue (NSOperationQueue queue);

		// -(void)overrideVersionPartWith:(NSString *)version;
		[Export ("overrideVersionPartWith:")]
		void OverrideVersionPart (string version);
	}

	// @interface FBSDKGraphRequestDataAttachment : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestDataAttachment")]
	interface GraphRequestDataAttachment {
		// -(instancetype)initWithData:(NSData *)data filename:(NSString *)filename contentType:(NSString *)contentType __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithData:filename:contentType:")]
		IntPtr Constructor ([NullAllowed] NSData data, string filename, string contentType);

		// @property (readonly, copy, nonatomic) NSString * contentType;
		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		// @property (readonly, nonatomic, strong) NSData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; }

		// @property (readonly, copy, nonatomic) NSString * filename;
		[Export ("filename", ArgumentSemantic.Copy)]
		string Filename { get; }
	}

	interface IMutableCopying { }

	// @protocol FBSDKMutableCopying <FBSDKCopying, NSMutableCopying>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKMutableCopying")]
	interface MutableCopying : Copying, INSMutableCopying {

		// @required -(id)mutableCopy;
		[New]
		[Abstract]
		[Export ("mutableCopy")]
		NSObject MutableCopy ();
	}

	interface ProfileDidChangeEventArgs {
		[Export ("FBSDKProfileChangeOldKey")]
		Profile OldProfile { get; }

		[Export ("FBSDKProfileChangeNewKey")]
		Profile NewProfile { get; }
	}

	// void(^)(FBSDKProfile *profile, NSError *error))completion
	delegate void ProfileLoadCurrentProfileHandler (Profile profile, NSError error);

	// @interface FBSDKProfile : NSObject <NSCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKProfile")]
	interface Profile : INSCopying, INSSecureCoding {

		// extern NSString *const FBSDKProfileDidChangeNotification;
		[Notification (typeof (ProfileDidChangeEventArgs))]
		[Field ("FBSDKProfileDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		[Field ("FBSDKProfileChangeOldKey", "__Internal")]
		NSString OldProfileKey { get; }

		[Field ("FBSDKProfileChangeNewKey", "__Internal")]
		NSString NewProfileKey { get; }

		// -(instancetype)initWithUserID:(NSString *)userID firstName:(NSString *)firstName middleName:(NSString *)middleName lastName:(NSString *)lastName name:(NSString *)name linkURL:(NSURL *)linkURL refreshDate:(NSDate *)refreshDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:")]
		IntPtr Constructor (string userID, string firstName, string middleName, string lastName, string name, [NullAllowed] NSUrl linkUrl, [NullAllowed] NSDate refreshDate);

		// @property (readonly, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserId { get; }

		[Obsolete ("Use UserId property instead. This will be removed in future versions.")]
		[Wrap ("UserId")]
		string UserID { get; }

		// @property (readonly, nonatomic) NSString * firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * middleName;
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, nonatomic) NSString * lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSURL * linkURL;
		[Export ("linkURL")]
		NSUrl LinkUrl { get; }

		// @property (readonly, nonatomic) NSDate * refreshDate;
		[Export ("refreshDate")]
		NSDate RefreshDate { get; }

		// +(FBSDKProfile *)currentProfile;
		// +(void)setCurrentProfile:(FBSDKProfile *)profile;
		[Static]
		[Export ("currentProfile")]
		Profile CurrentProfile { get; set; }

		// +(void)enableUpdatesOnAccessTokenChange:(BOOL)enable;
		[Static]
		[Export ("enableUpdatesOnAccessTokenChange:")]
		void EnableUpdatesOnAccessTokenChange (bool enable);

		// + (void)loadCurrentProfileWithCompletion:(void(^)(FBSDKProfile *profile, NSError *error))completion;
		[Static]
		[Export ("loadCurrentProfileWithCompletion:")]
		void LoadCurrentProfile (ProfileLoadCurrentProfileHandler completion);

		// - (NSURL *)imageURLForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[Export ("imageURLForPictureMode:size:")]
		NSUrl ImageUrl (ProfilePictureMode mode, CGSize size);

		// -(NSString *)imagePathForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[Obsolete ("Use ImageUrl method instead")]
		[Export ("imagePathForPictureMode:size:")]
		string ImagePath (ProfilePictureMode mode, CGSize size);

		// -(BOOL)isEqualToProfile:(FBSDKProfile *)profile;
		[Export ("isEqualToProfile:")]
		bool IsEqualToProfile (Profile profile);
	}

	// @interface FBSDKProfilePictureView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKProfilePictureView")]
	interface ProfilePictureView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, nonatomic) FBSDKProfilePictureMode pictureMode;
		[Export ("pictureMode", ArgumentSemantic.Assign)]
		ProfilePictureMode PictureMode { get; set; }

		// @property (copy, nonatomic) NSString * profileID;
		[Export ("profileID", ArgumentSemantic.Copy)]
		string ProfileId { get; set; }

		// -(void)setNeedsImageUpdate;
		[Export ("setNeedsImageUpdate")]
		void SetNeedsImageUpdate ();
	}

	[Static]
	interface LoggingBehavior {

		// extern NSString *const FBSDKLoggingBehaviorAccessTokens;
		[Field ("FBSDKLoggingBehaviorAccessTokens", "__Internal")]
		NSString AccessTokensKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorPerformanceCharacteristics;
		[Field ("FBSDKLoggingBehaviorPerformanceCharacteristics", "__Internal")]
		NSString PerformanceCharacteristicsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorAppEvents;
		[Field ("FBSDKLoggingBehaviorAppEvents", "__Internal")]
		NSString AppEventsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorInformational;
		[Field ("FBSDKLoggingBehaviorInformational", "__Internal")]
		NSString InformationalKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorCacheErrors;
		[Field ("FBSDKLoggingBehaviorCacheErrors", "__Internal")]
		NSString CacheErrorsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorUIControlErrors;
		[Field ("FBSDKLoggingBehaviorUIControlErrors", "__Internal")]
		NSString UIControlErrorsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugWarning;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugWarning", "__Internal")]
		NSString GraphAPIDebugWarningKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugInfo;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugInfo", "__Internal")]
		NSString GraphAPIDebugInfoKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorNetworkRequests;
		[Field ("FBSDKLoggingBehaviorNetworkRequests", "__Internal")]
		NSString NetworkRequestsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorDeveloperErrors;
		[Field ("FBSDKLoggingBehaviorDeveloperErrors", "__Internal")]
		NSString DeveloperErrorsKey { get; }
	}

	// @interface FBSDKSettings : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKSettings")]
	interface Settings {

		// +(NSString *)appID;
		// +(void)setAppID:(NSString *)appID;
		[Static]
		[Export ("appID")]
		string AppId { get; set; }

		[Obsolete ("Use AppId property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("AppId")]
		string AppID { get; set; }

		// +(NSString *)appURLSchemeSuffix;
		// +(void)setAppURLSchemeSuffix:(NSString *)appURLSchemeSuffix;
		[Static]
		[Export ("appURLSchemeSuffix")]
		string AppUrlSchemeSuffix { get; set; }

		// +(NSString *)clientToken;
		// +(void)setClientToken:(NSString *)clientToken;
		[Static]
		[Export ("clientToken")]
		string ClientToken { get; set; }

		// +(void)setGraphErrorRecoveryDisabled:(BOOL)disableGraphErrorRecovery;
		[Static]
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disableGraphErrorRecovery);

		// +(NSString *)displayName;
		// +(void)setDisplayName:(NSString *)displayName;
		[Static]
		[Export ("displayName")]
		string DisplayName { get; set; }

		// +(NSString *)facebookDomainPart;
		// +(void)setFacebookDomainPart:(NSString *)facebookDomainPart;
		[Static]
		[Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		// +(CGFloat)JPEGCompressionQuality;
		// +(void)setJPEGCompressionQuality:(CGFloat)JPEGCompressionQuality;
		[Static]
		[Export ("JPEGCompressionQuality")]
		nfloat JpegCompressionQuality { get; set; }

		// + (NSNumber *)autoLogAppEventsEnabled;
		// + (void)setAutoLogAppEventsEnabled:(NSNumber*)AutoLogAppEventsEnabled;
		[Internal]
		[Static]
		[Export ("autoLogAppEventsEnabled")]
		NSNumber _AutoLogAppEventsEnabled { get; set; }

		// +(BOOL)limitEventAndDataUsage;
		// +(void)setLimitEventAndDataUsage:(BOOL)limitEventAndDataUsage;
		[Static]
		[Export ("limitEventAndDataUsage")]
		bool LimitEventAndDataUsage { get; set; }

		// +(NSString *)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// +(NSSet *)loggingBehavior;
		// +(void)setLoggingBehavior:(NSSet *)loggingBehavior;
		[Static]
		[Export ("loggingBehavior")]
		NSSet LoggingBehavior { get; set; }

		// +(void)enableLoggingBehavior:(NSString *)loggingBehavior;
		[Static]
		[Export ("enableLoggingBehavior:")]
		void EnableLoggingBehavior (string loggingBehavior);

		// +(void)disableLoggingBehavior:(NSString *)loggingBehavior;
		[Static]
		[Export ("disableLoggingBehavior:")]
		void DisableLoggingBehavior (string loggingBehavior);

		// +(NSString *)legacyUserDefaultTokenInformationKeyName;
		// +(void)setLegacyUserDefaultTokenInformationKeyName:(NSString *)tokenInformationKeyName;
		[Static]
		[Export ("legacyUserDefaultTokenInformationKeyName")]
		string LegacyUserDefaultTokenInformationKeyName { get; set; }

		// +(void)setGraphAPIVersion:(NSString *)version;
		// +(NSString *)graphAPIVersion;
		[Static]
		[Export ("graphAPIVersion")]
		string GraphApiVersion { get; set; }

		[Obsolete ("Use GraphApiVersion property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("GraphApiVersion")]
		string GraphAPIVersion { get; set; }
	}

	delegate void TestUsersManagerRetrieveTestAccountTokensHandler (AccessToken [] tokens, NSError error);
	delegate void TestUsersManagerRemoveTestAccountHandler (NSError error);

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKTestUsersManager")]
	interface TestUsersManager {

		// +(instancetype)sharedInstanceForAppID:(NSString *)appID appSecret:(NSString *)appSecret;
		[Static]
		[Export ("sharedInstanceForAppID:appSecret:")]
		TestUsersManager SharedInstance (string appID, string appSecret);

		// -(void)requestTestAccountTokensWithArraysOfPermissions:(NSArray *)arraysOfPermissions createIfNotFound:(BOOL)createIfNotFound completionHandler:(FBSDKTestUsersManagerRetrieveTestAccountTokensHandler)handler;
		[Export ("requestTestAccountTokensWithArraysOfPermissions:createIfNotFound:completionHandler:")]
		void RequestTestAccount (string [] arraysOfPermissions, bool createIfNotFound, TestUsersManagerRetrieveTestAccountTokensHandler handler);

		// -(void)addTestAccountWithPermissions:(NSSet *)permissions completionHandler:(FBSDKTestUsersManagerRetrieveTestAccountTokensHandler)handler;
		[Export ("addTestAccountWithPermissions:completionHandler:")]
		void AddTestAccount (NSSet permissions, TestUsersManagerRetrieveTestAccountTokensHandler handler);

		// -(void)removeTestAccount:(NSString *)userId completionHandler:(FBSDKTestUsersManagerRemoveTestAccountHandler)handler;
		[Export ("removeTestAccount:completionHandler:")]
		void RemoveTestAccount (string userId, TestUsersManagerRemoveTestAccountHandler handler);

		// -(void)makeFriendsWithFirst:(FBSDKAccessToken *)first second:(FBSDKAccessToken *)second callback:(void (^)(NSError *))callback;
		[Export ("makeFriendsWithFirst:second:callback:")]
		void MakeFriends (AccessToken first, AccessToken second, TestUsersManagerRemoveTestAccountHandler callback);
	}

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKUtility")]
	interface Utility {

		// +(NSDictionary *)dictionaryWithQueryString:(NSString *)queryString;
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary DictionaryWithQueryString (string queryString);

		// +(NSString *)queryStringWithDictionary:(NSDictionary *)dictionary error:(NSError **)errorRef;
		[Static]
		[Export ("queryStringWithDictionary:error:")]
		string QueryStringWithDictionary ([NullAllowed] NSDictionary dictionary, out NSError errorRef);

		// +(NSString *)URLDecode:(NSString *)value;
		[Static]
		[Export ("URLDecode:")]
		string UrlDecode (string value);

		// +(NSString *)URLEncode:(NSString *)value;
		[Static]
		[Export ("URLEncode:")]
		string UrlEncode (string value);

		// +(dispatch_source_t)startGCDTimerWithInterval:(double)interval block:(dispatch_block_t)block;
		[Internal]
		[Static]
		[Export ("startGCDTimerWithInterval:block:")]
		IntPtr _StartGcdTimer (double interval, Action block);

		[Static]
		[Wrap ("new DispatchSource.Timer (_StartGcdTimer (interval, block))")]
		DispatchSource StartGcdTimer (double interval, Action block);

		// +(void)stopGCDTimer:(dispatch_source_t)timer;
		[Internal]
		[Static]
		[Export ("stopGCDTimer:")]
		void _StopGcdTimer (IntPtr timer);

		[Static]
		[Wrap ("_StopGcdTimer (timer.Handle)")]
		void StopGcdTimer (DispatchSource timer);
	}

	#region Facebook.Bolts

	// This just binds what is needed to work
	[BaseType (typeof (NSObject), Name = "BFTask")]
	interface Task {

		[Export ("result", ArgumentSemantic.Strong)]
		NSObject Result { get; }

		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; }

		[Export ("exception", ArgumentSemantic.Strong)]
		[Obsolete ("Task exception handling is deprecated and will be removed in a future release.")]
		NSException Exception { get; }

		[Export ("isCancelled", ArgumentSemantic.Assign)]
		bool IsCancelled { get; }

		[Export ("isFaulted", ArgumentSemantic.Assign)]
		bool IsFaulted { get; }

		[Export ("isCompleted", ArgumentSemantic.Assign)]
		bool IsCompleted { get; }
	}

	interface IAppLinkResolving {

	}

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "BFAppLinkResolving")]
	interface AppLinkResolving {

		// @required -(BFTask *)appLinkFromURLInBackground:(NSURL *)url;
		[Abstract]
		[Export ("appLinkFromURLInBackground:")]
		Task AppLinkInBackground (NSUrl url);
	}

	#endregion
}
