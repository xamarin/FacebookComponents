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

		[Export ("FBSDKAccessTokenDidChangeUserIDKey")]
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

		[Field ("FBSDKAccessTokenDidChangeUserIDKey", "__Internal")]
		NSString UserIdKey { get; }

		[Field ("FBSDKAccessTokenChangeOldKey", "__Internal")]
		NSString OldTokenKey { get; }

		// FBSDK_EXTERN NSString *const FBSDKAccessTokenDidExpire;
		[Field ("FBSDKAccessTokenDidExpireKey", "__Internal")]
		NSString DidExpireKey { get; }

		// @property (copy, nonatomic, class) FBSDKAccessToken * _Nullable currentAccessToken;
		[Static]
		[NullAllowed]
		[Export ("currentAccessToken", ArgumentSemantic.Copy)]
		AccessToken CurrentAccessToken { get; set; }

		// @property (readonly, getter = isCurrentAccessTokenActive, assign, nonatomic, class) BOOL currentAccessTokenIsActive;
		[Static]
		[Export ("isCurrentAccessTokenActive")]
		bool CurrentAccessTokenIsActive { get; }

		// @property (readonly, copy, nonatomic) NSString * appID;
		[Export ("appID")]
		string AppId { get; }

		// @property (readonly, copy, nonatomic) NSDate * dataAccessExpirationDate;
		[Export ("dataAccessExpirationDate", ArgumentSemantic.Copy)]
		NSDate DataAccessExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NSSet * declinedPermissions;
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet DeclinedPermissions { get; }

		// @property (readonly, copy, nonatomic) NSSet<NSString *> * _Nonnull expiredPermissions;
		[Export ("expiredPermissions", ArgumentSemantic.Copy)]
		NSSet ExpiredPermissions { get; }

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

		// @property (readonly, getter = isDataAccessExpired, assign, nonatomic) BOOL dataAccessExpired;
		[Export ("isDataAccessExpired")]
		bool IsDataAccessExpired { get; }

		// -(instancetype)initWithTokenString:(NSString *)tokenString permissions:(NSArray *)permissions declinedPermissions:(NSArray *)declinedPermissions expiredPermissions:(NSArray<NSString *> *)expiredPermissions appID:(NSString *)appID userID:(NSString *)userID expirationDate:(NSDate *)expirationDate refreshDate:(NSDate *)refreshDate dataAccessExpirationDate:(NSDate *)dataAccessExpirationDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:")]
		IntPtr Constructor (string tokenString, string [] permissions, string [] declinedPermissions, string [] expiredPermissions, string appId, string userId, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate);

		// -(BOOL)hasGranted:(NSString *)permission;
		[Export ("hasGranted:")]
		bool HasGranted (string permission);

		// -(BOOL)isEqualToAccessToken:(FBSDKAccessToken *)token;
		[Export ("isEqualToAccessToken:")]
		bool Equals (AccessToken token);

		// + (void)refreshCurrentAccessToken:(FBSDKGraphRequestBlockHandler)completionHandler;
		[Static]
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("refreshCurrentAccessToken:")]
		void RefreshCurrentAccessToken ([NullAllowed] GraphRequestBlockHandler completionHandler);
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

		// @property (assign, nonatomic, class) FBSDKAppEventsFlushBehavior flushBehavior;
		[Static]
		[Export ("flushBehavior", ArgumentSemantic.Assign)]
		AppEventsFlushBehavior FlushBehavior { get; set; }

		// @property (copy, nonatomic, class) NSString * _Nullable loggingOverrideAppID;
		[Static]
		[NullAllowed]
		[Export ("loggingOverrideAppID")]
		string LoggingOverrideAppId { get; set; }

		[Obsolete ("Use the LoggingOverrideAppId static property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("LoggingOverrideAppId")]
		string LoggingOverrideAppID { get; set; }

		// @property (copy, nonatomic, class) NSString * _Nullable userID;
		[Static]
		[NullAllowed]
		[Export ("userID")]
		string UserId { get; set; }

		// +(void)logEvent:(NSString *)eventName;
		[Protected]
		[Static]
		[Export ("logEvent:")]
		void LogEvent (NSString eventName);

		[Static]
		[Wrap ("LogEvent (eventName.GetConstant ())")]
		void LogEvent (AppEventName eventName);

		[Static]
		[Wrap ("LogEvent (new NSString (eventName))")]
		void LogEvent (string eventName);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum;
		[Protected]
		[Static]
		[Export ("logEvent:valueToSum:")]
		void LogEvent (NSString eventName, double valueToSum);

		[Static]
		[Wrap ("LogEvent (eventName.GetConstant (), valueToSum)")]
		void LogEvent (AppEventName eventName, double valueToSum);

		[Static]
		[Wrap ("LogEvent (new NSString (eventName), valueToSum)")]
		void LogEvent (string eventName, double valueToSum);

		// +(void)logEvent:(NSString *)eventName parameters:(NSDictionary *)parameters;
		[Protected]
		[Static]
		[Export ("logEvent:parameters:")]
		void LogEvent (NSString eventName, NSDictionary parameters);

		[Static]
		[Wrap ("LogEvent (eventName.GetConstant (), parameters)")]
		void LogEvent (AppEventName eventName, NSDictionary parameters);

		[Static]
		[Wrap ("LogEvent (new NSString (eventName), parameters)")]
		void LogEvent (string eventName, NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum parameters:(NSDictionary *)parameters;
		[Protected]
		[Static]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (NSString eventName, double valueToSum, NSDictionary parameters);

		[Static]
		[Wrap ("LogEvent (eventName.GetConstant (), valueToSum, parameters)")]
		void LogEvent (AppEventName eventName, double valueToSum, NSDictionary parameters);

		[Static]
		[Wrap ("LogEvent (new NSString (eventName), valueToSum, parameters)")]
		void LogEvent (string eventName, double valueToSum, NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(NSNumber *)valueToSum parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Protected]
		[Static]
		[Export ("logEvent:valueToSum:parameters:accessToken:")]
		void LogEvent (NSString eventName, [NullAllowed] NSNumber valueToSum, NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		[Static]
		[Wrap ("LogEvent (eventName.GetConstant (), valueToSum, parameters, accessToken)")]
		void LogEvent (AppEventName eventName, [NullAllowed] NSNumber valueToSum, NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		[Static]
		[Wrap ("LogEvent (new NSString (eventName), valueToSum, parameters, accessToken)")]
		void LogEvent (string eventName, [NullAllowed] NSNumber valueToSum, NSDictionary parameters, [NullAllowed] AccessToken accessToken);

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

		// +(void)logProductItem:(NSString *)itemID availability:(FBSDKProductAvailability)availability condition:(FBSDKProductCondition)condition description:(NSString *)description imageLink:(NSString *)imageLink link:(NSString *)link title:(NSString *)title priceAmount:(double)priceAmount currency:(NSString *)currency gtin:(NSString *)gtin mpn:(NSString *)mpn brand:(NSString *)brand parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logProductItem:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:")]
		void LogProductItem (string itemId, ProductAvailability availability, ProductCondition condition, string description, string imageLink, string link, string title, double priceAmount, string currency, [NullAllowed] string gtin, [NullAllowed] string mpn, [NullAllowed] string brand, [NullAllowed] NSDictionary parameters);

		// +(void)activateApp;
		[Static]
		[Export ("activateApp")]
		void ActivateApp ();

		// + (void)setPushNotificationsDeviceToken:(NSData *)deviceToken;
		[Static]
		[Export ("setPushNotificationsDeviceToken:")]
		void SetPushNotificationsDeviceToken (NSData deviceToken);

		// +(void)setPushNotificationsDeviceTokenString:(NSString *)deviceTokenString;
		[Static]
		[Export ("setPushNotificationsDeviceTokenString:")]
		void SetPushNotificationsDeviceToken (string deviceTokenString);

		// +(void)flush;
		[Static]
		[Export ("flush")]
		void Flush ();

		// +(FBSDKGraphRequest *)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
		GraphRequest RequestForCustomAudienceThirdPartyId (AccessToken accessToken);

		// + (void)clearUserID;
		[Static]
		[Export ("clearUserID")]
		void ClearUserId ();

		// +(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country;
		[Static]
		[Export ("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:")]
		void SetUserEmail ([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country);

		// +(NSString *)getUserData;
		[Static]
		[return: NullAllowed]
		[Export ("getUserData")]
		string GetUserData ();

		// +(void)clearUserData;
		[Static]
		[Export ("clearUserData")]
		void ClearUserData ();

		// +(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Static]
		[Export ("setUserData:forType:")]
		void SetUserData ([NullAllowed] string data, string type);

		// +(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Static]
		[Export ("clearUserDataForType:")]
		void ClearUserDataForType (string type);

		// +(void)updateUserProperties:(NSDictionary *)properties handler:(FBSDKGraphRequestBlockHandler)handler;
		[Static]
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("updateUserProperties:handler:")]
		void UpdateUserProperties (NSDictionary properties, [NullAllowed] GraphRequestBlockHandler handler);

		// +(void)augmentHybridWKWebView:(WKWebView *)webView;
		[Unavailable (PlatformName.TvOS)]
		[Static]
		[Export ("augmentHybridWKWebView:")]
		void AugmentHybrid (WKWebView webView);

		// +(void)setIsUnityInit:(BOOL)isUnityInit;
		[Static]
		[Export ("setIsUnityInit:")]
		void SetIsUnityInit (bool isUnityInit);

		// +(void)sendEventBindingsToUnity;
		[Static]
		[Export ("sendEventBindingsToUnity")]
		void SendEventBindingsToUnity ();
	}

	// @interface FBSDKApplicationDelegate : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKApplicationDelegate")]
	interface ApplicationDelegate {

		// @property (readonly, nonatomic, strong, class) FBSDKApplicationDelegate * _Nonnull sharedInstance;
		[Static]
		[Export ("sharedInstance", ArgumentSemantic.Strong)]
		ApplicationDelegate SharedInstance { get; }

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool OpenUrl (UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;
		[Export ("application:openURL:options:")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary options);

		// -(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool FinishedLaunching ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions);

		// +(void)initializeSDK:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
		[Static]
		[Export ("initializeSDK:")]
		void InitializeSdk ([NullAllowed] NSDictionary launchOptions);
	}

	// @interface FBSDKAppLink : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLink")]
	interface AppLink : INativeObject {
		// extern NSString *const _Nonnull FBSDKAppLinkVersion;
		[Field ("FBSDKAppLinkVersion", "__Internal")]
		NSString Version { get; }

		// +(instancetype _Nonnull)appLinkWithSourceURL:(NSURL * _Nonnull)sourceURL targets:(NSArray<FBSDKAppLinkTarget *> * _Nonnull)targets webURL:(NSURL * _Nullable)webURL;
		[Static]
		[Export ("appLinkWithSourceURL:targets:webURL:")]
		AppLink Create (NSUrl sourceUrl, AppLinkTarget [] targets, [NullAllowed] NSUrl webUrl);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull sourceURL;
		[Export ("sourceURL", ArgumentSemantic.Strong)]
		NSUrl SourceUrl { get; }

		// @property (readonly, copy, nonatomic) NSArray<FBSDKAppLinkTarget *> * _Nonnull targets;
		[Export ("targets", ArgumentSemantic.Copy)]
		AppLinkTarget [] Targets { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nullable webURL;
		[NullAllowed]
		[Export ("webURL", ArgumentSemantic.Strong)]
		NSUrl WebUrl { get; }
	}

	// typedef void (^FBSDKAppLinkNavigationBlockHandler)(FBSDKAppLinkNavigationType, NSError * _Nullable);
	delegate void AppLinkNavigationBlockHandler (AppLinkNavigationType navType, [NullAllowed] NSError error);

	// @interface FBSDKAppLinkNavigation : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkNavigation")]
	interface AppLinkNavigation {
		// @property (nonatomic, strong, class) id<FBSDKAppLinkResolving> _Nonnull defaultResolver;
		[Static]
		[Export ("defaultResolver", ArgumentSemantic.Strong)]
		IAppLinkResolving DefaultResolver { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull extras;
		[Export ("extras", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Extras { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull appLinkData;
		[Export ("appLinkData", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLink;
		[Export ("appLink", ArgumentSemantic.Strong)]
		AppLink AppLink { get; }

		// -(FBSDKAppLinkNavigationType)navigationType;
		[Export ("navigationType")]
		AppLinkNavigationType GetNavigationType ();

		// +(instancetype _Nonnull)navigationWithAppLink:(FBSDKAppLink * _Nonnull)appLink extras:(NSDictionary<NSString *,id> * _Nonnull)extras appLinkData:(NSDictionary<NSString *,id> * _Nonnull)appLinkData;
		[Static]
		[Export ("navigationWithAppLink:extras:appLinkData:")]
		AppLinkNavigation Create (AppLink appLink, NSDictionary<NSString, NSObject> extras, NSDictionary<NSString, NSObject> appLinkData);

		// +(NSDictionary<NSString *,NSDictionary<NSString *,NSString *> *> * _Nonnull)callbackAppLinkDataForAppWithName:(NSString * _Nonnull)appName url:(NSString * _Nonnull)url;
		[Static]
		[Export ("callbackAppLinkDataForAppWithName:url:")]
		NSDictionary<NSString, NSDictionary<NSString, NSString>> GetCallbackAppLinkData (string appName, string url);

		// -(FBSDKAppLinkNavigationType)navigate:(NSError * _Nullable * _Nullable)error;
		[Export ("navigate:")]
		AppLinkNavigationType Navigate ([NullAllowed] out NSError error);

		// +(void)resolveAppLink:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkBlockHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("resolveAppLink:handler:")]
		void ResolveAppLink (NSUrl destination, AppLinkBlockHandler handler);

		// +(void)resolveAppLink:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkBlockHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("resolveAppLink:resolver:handler:")]
		void ResolveAppLink (NSUrl destination, IAppLinkResolving resolver, AppLinkBlockHandler handler);

		// +(FBSDKAppLinkNavigationType)navigateToAppLink:(FBSDKAppLink * _Nonnull)link error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export ("navigateToAppLink:error:")]
		AppLinkNavigationType Navigate (AppLink link, [NullAllowed] out NSError error);

		// +(FBSDKAppLinkNavigationType)navigationTypeForLink:(FBSDKAppLink * _Nonnull)link;
		[Static]
		[Export ("navigationTypeForLink:")]
		AppLinkNavigationType GetNavigationType (AppLink link);

		// +(void)navigateToURL:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkNavigationBlockHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("navigateToURL:handler:")]
		void Navigate (NSUrl destination, AppLinkNavigationBlockHandler handler);

		// +(void)navigateToURL:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkNavigationBlockHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("navigateToURL:resolver:handler:")]
		void Navigate (NSUrl destination, IAppLinkResolving resolver, AppLinkNavigationBlockHandler handler);
	}

	// typedef void (^FBSDKAppLinksBlock)(NSDictionary<NSURL *,FBSDKAppLink *> * _Nonnull, NSError * _Nullable);
	delegate void AppLinksBlockHandler (NSDictionary<NSUrl, AppLink> appLinks, [NullAllowed] NSError error);

	// @interface FBSDKAppLinkResolver : NSObject<AppLinkResolving>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolver")]
	interface AppLinkResolver : AppLinkResolving {
		// -(void)appLinksFromURLs:(NSArray<NSURL *> *)urls handler:(FBSDKAppLinksFromURLArrayHandler)handler __attribute__((availability(ios_app_extension, unavailable)));
		[Async]
		[Export ("appLinksFromURLs:handler:")]
		void GetAppLinks (NSUrl [] urls, AppLinksBlockHandler handler);

		// + (instancetype)resolver;
		[Static]
		[Export ("resolver")]
		AppLinkResolver Resolver { get; }
	}

	// typedef void (^FBSDKAppLinkBlock)(FBSDKAppLink * _Nullable, NSError * _Nullable);
	delegate void AppLinkBlockHandler ([NullAllowed] AppLink appLink, [NullAllowed] NSError error);

	interface IAppLinkResolving { }

	// @protocol FBSDKAppLinkResolving <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolving")]
	interface AppLinkResolving {
		// @required -(void)appLinkFromURL:(NSURL * _Nonnull)url handler:(FBSDKAppLinkBlockHandler _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)));
		[Abstract]
		[Export ("appLinkFromURL:handler:")]
		void Handler (NSUrl url, AppLinkBlockHandler handler);
	}

	interface IAppLinkReturnToRefererControllerDelegate { }

	// @protocol FBSDKAppLinkReturnToRefererControllerDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkReturnToRefererControllerDelegate")]
	interface AppLinkReturnToRefererControllerDelegate {		// @optional -(void)returnToRefererController:(FBSDKAppLinkReturnToRefererController * _Nonnull)controller willNavigateToAppLink:(FBSDKAppLink * _Nonnull)appLink;
		[EventArgs ("AppLinkReturnToRefererControllerWillNavigateToAppLink")]
		[Export ("returnToRefererController:willNavigateToAppLink:")]
		void WillNavigateToAppLink (AppLinkReturnToRefererController controller, AppLink appLink);

		// @optional -(void)returnToRefererController:(FBSDKAppLinkReturnToRefererController * _Nonnull)controller didNavigateToAppLink:(FBSDKAppLink * _Nonnull)url type:(FBSDKAppLinkNavigationType)type;
		[EventArgs ("AppLinkReturnToRefererControllerNavigatedToAppLink")]
		[EventName ("NavigatedToAppLink")]
		[Export ("returnToRefererController:didNavigateToAppLink:type:")]
		void DidNavigateToAppLink (AppLinkReturnToRefererController controller, AppLink url, AppLinkNavigationType type);
	}

	// @interface FBSDKAppLinkReturnToRefererController : NSObject <FBSDKAppLinkReturnToRefererViewDelegate>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		   Name = "FBSDKAppLinkReturnToRefererController",
		   Delegates = new [] { "Delegate" },
	           Events = new [] { typeof (AppLinkReturnToRefererControllerDelegate) })]
	interface AppLinkReturnToRefererController : AppLinkReturnToRefererViewDelegate {
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAppLinkReturnToRefererControllerDelegate Delegate { get; set; }

		// @property (nonatomic, strong) FBSDKAppLinkReturnToRefererView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		AppLinkReturnToRefererView View { get; set; }

		// -(instancetype _Nonnull)initForDisplayAboveNavController:(UINavigationController * _Nonnull)navController;
		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

		// -(instancetype _Nonnull)initForDisplayAboveNavController:(UINavigationController * _Nonnull)navController;
		[Export ("initForDisplayAboveNavController:")]
		IntPtr Constructor (UINavigationController navController);

		// -(void)removeFromNavController;
		[Export ("removeFromNavController")]
		void RemoveFromNavController ();

		// -(void)showViewForRefererAppLink:(FBSDKAppLink * _Nonnull)refererAppLink;
		[Export ("showViewForRefererAppLink:")]
		void ShowView (AppLink refererAppLink);

		// -(void)showViewForRefererURL:(NSURL * _Nonnull)url;
		[Export ("showViewForRefererURL:")]
		void ShowView (NSUrl url);

		// -(void)closeViewAnimated:(BOOL)animated;
		[Export ("closeViewAnimated:")]
		void CloseView (bool animated);
	}

	interface IAppLinkReturnToRefererViewDelegate { }

	// @protocol FBSDKAppLinkReturnToRefererViewDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkReturnToRefererViewDelegate")]
	interface AppLinkReturnToRefererViewDelegate {
		// @required -(void)returnToRefererViewDidTapInsideCloseButton:(FBSDKAppLinkReturnToRefererView * _Nonnull)view;
		[Abstract]
		[EventArgs ("AppLinkReturnToRefererViewInsideCloseButtonTapped")]
		[EventName ("InsideCloseButtonTapped")]
		[Export ("returnToRefererViewDidTapInsideCloseButton:")]
		void DidTapInsideCloseButton (AppLinkReturnToRefererView view);

		// @required -(void)returnToRefererViewDidTapInsideLink:(FBSDKAppLinkReturnToRefererView * _Nonnull)view link:(FBSDKAppLink * _Nonnull)link;
		[Abstract]
		[EventArgs ("AppLinkReturnToRefererViewInsideLinkTapped")]
		[EventName ("InsideLinkTapped")]
		[Export ("returnToRefererViewDidTapInsideLink:link:")]
		void DidTapInsideLink (AppLinkReturnToRefererView view, AppLink link);
	}

	// @interface FBSDKAppLinkReturnToRefererView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKAppLinkReturnToRefererView")]
	interface AppLinkReturnToRefererView {
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAppLinkReturnToRefererViewDelegate Delegate { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic, strong) FBSDKAppLink * _Nonnull refererAppLink;
		[Export ("refererAppLink", ArgumentSemantic.Strong)]
		AppLink RefererAppLink { get; set; }

		// @property (assign, nonatomic) FBSDKIncludeStatusBarInSize includeStatusBarInSize;
		[Export ("includeStatusBarInSize", ArgumentSemantic.Assign)]
		IncludeStatusBarInSize IncludeStatusBarInSize { get; set; }

		// @property (assign, nonatomic) BOOL closed;
		[Export ("closed")]
		bool Closed { [Bind ("isClosed")] get; set; }
	}

	// @interface FBSDKAppLinkTarget : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkTarget")]
	interface AppLinkTarget {
		// +(instancetype _Nonnull)appLinkTargetWithURL:(NSURL * _Nonnull)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName;
		[Static]
		[Export ("appLinkTargetWithURL:appStoreId:appName:")]
		AppLinkTarget Create (NSUrl url, [NullAllowed] string appStoreId, string appName);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull URL;
		[Export ("URL", ArgumentSemantic.Strong)]
		NSUrl URL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable appStoreId;
		[NullAllowed, Export ("appStoreId")]
		string AppStoreId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appName;
		[Export ("appName")]
		string AppName { get; }
	}

	// typedef void (^FBSDKURLBlock)(NSURL * _Nullable, NSError * _Nullable);
	delegate void UrlBlockHandler (NSUrl url, NSError error);

	// @interface FBSDKAppLinkUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkUtility")]
	interface AppLinkUtility {

		// +(void)fetchDeferredAppLink:(FBSDKUrlBlockHandler)handler;
		[Static]
		[Async]
		[Export ("fetchDeferredAppLink:")]
		void FetchDeferredAppLink (UrlBlockHandler handler);

		// + (NSString*)appInvitePromotionCodeFromURL:(NSURL*)url;
		[Static]
		[Export ("appInvitePromotionCodeFromURL:")]
		string AppInvitePromotionCode (NSUrl url);
	}

	// @interface FBSDKBasicUtility : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKBasicUtility")]
	interface BasicUtility { }

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
	}

	[Static]
	interface GraphRequestErrors {
		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorKey;
		[Field ("FBSDKGraphRequestErrorKey", "__Internal")]
		NSString ErrorKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorCodeKey;
		[Field ("FBSDKGraphRequestErrorGraphErrorCodeKey", "__Internal")]
		NSString GraphErrorCodeKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorSubcodeKey;
		[Field ("FBSDKGraphRequestErrorGraphErrorSubcodeKey", "__Internal")]
		NSString GraphErrorSubcodeKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorHTTPStatusCodeKey;
		[Field ("FBSDKGraphRequestErrorHTTPStatusCodeKey", "__Internal")]
		NSString HttpStatusCodeKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorParsedJSONResponseKey;
		[Field ("FBSDKGraphRequestErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJsonResponseKey { get; }
	}

	// typedef void (^FBSDKCodeBlock)();
	delegate void CodeBlockHandler ();

	// typedef void (^FBSDKErrorBlock)(NSError * _Nullable);
	delegate void ErrorBlockHandler ([NullAllowed] NSError error);

	// typedef void (^FBSDKSuccessBlock)(BOOL, NSError * _Nullable);
	delegate void SuccessBlockHandler (bool success, [NullAllowed] NSError error);

	interface IErrorRecoveryAttempting { }

	// @protocol FBSDKErrorRecoveryAttempting <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKErrorRecoveryAttempting")]
	interface ErrorRecoveryAttempting {
		// @required -(void)attemptRecoveryFromError:(NSError *)error optionIndex:(NSUInteger)recoveryOptionIndex delegate:(id)delegate didRecoverSelector:(SEL)didRecoverSelector contextInfo:(void *)contextInfo;
		[Abstract]
		[Export ("attemptRecoveryFromError:optionIndex:delegate:didRecoverSelector:contextInfo:")]
		void AttemptRecovery (NSError error, nuint recoveryOptionIndex, [NullAllowed] NSObject aDelegate, Selector didRecoverSelector, IntPtr contextInfo);
	}

	interface ICopying { }

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

	interface IGraphErrorRecoveryProcessorDelegate { }

	// @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessorDelegate")]
	interface GraphErrorRecoveryProcessorDelegate {

		// @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor *)processor didRecover:(BOOL)didRecover error:(NSError *)error;
		[Abstract]
		[Export ("processorDidAttemptRecovery:didRecover:error:")]
		void DidAttemptRecovery (GraphErrorRecoveryProcessor processor, bool didRecover, [NullAllowed] NSError error);

		// @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor *)processor error:(NSError *)error;
		[Export ("processorWillProcessError:error:")]
		bool WillProcessError (GraphErrorRecoveryProcessor processor, [NullAllowed] NSError error);
	}

	// @interface FBSDKGraphErrorRecoveryProcessor : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessor")]
	interface GraphErrorRecoveryProcessor {

		// @property (readonly, nonatomic, strong) id<FBSDKGraphErrorRecoveryProcessorDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Strong)]
		IGraphErrorRecoveryProcessorDelegate Delegate { get; }

		// -(BOOL)processError:(NSError *)error request:(FBSDKGraphRequest *)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate>)delegate;
		[Export ("processError:request:delegate:")]
		bool ProcessError (NSError error, GraphRequest request, [NullAllowed] IGraphErrorRecoveryProcessorDelegate aDelegate);

		// -(void)didPresentErrorWithRecovery:(BOOL)didRecover contextInfo:(void *)contextInfo;
		[Export ("didPresentErrorWithRecovery:contextInfo:")]
		void ErrorPresentedWithRecovery (bool didRecover, [NullAllowed] NSObject contextInfo);
	}

	// @interface FBSDKGraphRequest : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequest")]
	interface GraphRequest {
		// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath;
		[Export ("initWithGraphPath:")]
		IntPtr Constructor (string graphPath);

		// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
		[Internal]
		[Export ("initWithGraphPath:HTTPMethod:")]
		IntPtr Constructor (string graphPath, NSString method);

		[Wrap ("this (graphPath, method.GetConstant ())")]
		IntPtr Constructor (string graphPath, HttpMethod method);

		[Wrap ("this (graphPath, new NSString (method))")]
		IntPtr Constructor (string graphPath, string method);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters;
		[Export ("initWithGraphPath:parameters:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters HTTPMethod:(NSString *)HTTPMethod;
		[Internal]
		[Export ("initWithGraphPath:parameters:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, NSString method);

		[Wrap ("this (graphPath, parameters, method.GetConstant ())")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, HttpMethod method);

		[Wrap ("this (graphPath, parameters, new NSString (method))")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, string method);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters tokenString:(NSString *)tokenString version:(NSString *)version HTTPMethod:(NSString *)HTTPMethod __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Internal]
		[Export ("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, [NullAllowed] NSString method);

		[Wrap ("this (graphPath, parameters, tokenString, version, method.GetConstant ())")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, HttpMethod method);

		[Wrap ("this (graphPath, parameters, tokenString, version, new NSString (method))")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, string method);

		// @property (readonly, nonatomic, strong) NSMutableDictionary * parameters;
		[Export ("parameters", ArgumentSemantic.Copy)]
		NSDictionary Parameters { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[NullAllowed]
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * graphPath;
		[Export ("graphPath", ArgumentSemantic.Copy)]
		string GraphPath { get; }

		// @property (readonly, copy, nonatomic) NSString * HTTPMethod;
		[BindAs (typeof (HttpMethod))]
		[Export ("HTTPMethod", ArgumentSemantic.Copy)]
		NSString HttpMethod { get; }

		// @property (readonly, copy, nonatomic) NSString * version;
		[Export ("version", ArgumentSemantic.Copy)]
		string Version { get; }

		// -(void)setGraphErrorRecoveryDisabled:(BOOL)disable;
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disable);

		// -(FBSDKGraphRequestConnection *)startWithCompletionHandler:(FBSDKGraphRequestBlockHandler)handler;
		[Export ("startWithCompletionHandler:")]
		GraphRequestConnection Start ([NullAllowed] GraphRequestBlockHandler handler);
	}

	// typedef void (^FBSDKGraphRequestBlockHandler)(FBSDKGraphRequestConnection *id, NSError *);
	delegate void GraphRequestBlockHandler ([NullAllowed] GraphRequestConnection connection, [NullAllowed] NSObject result, [NullAllowed] NSError error);

	interface IGraphRequestConnectionDelegate { }

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

		// @property (assign, nonatomic, class) NSTimeInterval defaultConnectionTimeout;
		[Static]
		[Export ("defaultConnectionTimeout")]
		double DefaultConnectionTimeout { get; set; }

		// @property (assign, nonatomic) id<FBSDKGraphRequestConnectionDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGraphRequestConnectionDelegate Delegate { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeout;
		[Export ("timeout", ArgumentSemantic.Assign)]
		double Timeout { get; set; }

		// @property (readonly, retain, nonatomic) NSHTTPURLResponse * URLResponse;
		[Export ("URLResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		// @property (retain, nonatomic) NSOperationQueue * _Nonnull delegateQueue;
		[Export ("delegateQueue", ArgumentSemantic.Retain)]
		NSOperationQueue DelegateQueue { get; set; }

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestBlockHandler)handler;
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("addRequest:completionHandler:")]
		void AddRequest (GraphRequest request, GraphRequestBlockHandler handler);

		// -(void)addRequest:(FBSDKGraphRequest *)request batchEntryName:(NSString *)name completionHandler:(FBSDKGraphRequestBlockHandler)handler;
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("addRequest:batchEntryName:completionHandler:")]
		void AddRequest (GraphRequest request, string name, GraphRequestBlockHandler handler);

		// -(void)addRequest:(FBSDKGraphRequest *)request batchParameters:(NSDictionary<NSString *,id> *)batchParameters completionHandler:(FBSDKGraphRequestBlockHandler)handler;
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("addRequest:batchParameters:completionHandler:")]
		void AddRequest (GraphRequest request, NSDictionary batchParameters, GraphRequestBlockHandler handler);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)overrideGraphAPIVersion:(NSString *)version;
		[Export ("overrideGraphAPIVersion:")]
		void OverrideGraphApiVersion (string version);
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

	interface MeasurementEventArgs {
		[Export ("FBSDKMeasurementEventNameKey")]
		string EventName { get; }

		[Export ("FBSDKMeasurementEventArgsKey")]
		NSDictionary EventArgs { get; }
	}

	// @interface FBSDKMeasurementEvent : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKMeasurementEvent")]
	interface MeasurementEvent {
		// extern const NSNotificationName _Nonnull FBSDKMeasurementEventNotification;
		[Notification (typeof (MeasurementEventArgs))]
		[Field ("FBSDKMeasurementEventNotification", "__Internal")]
		NSString EventNotification { get; }

		// extern NSString *const _Nonnull FBSDKMeasurementEventNameKey;
		[Field ("FBSDKMeasurementEventNameKey", "__Internal")]
		NSString EventNameKey { get; }

		// extern NSString *const _Nonnull FBSDKMeasurementEventArgsKey;
		[Field ("FBSDKMeasurementEventArgsKey", "__Internal")]
		NSString EventArgsKey { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkParseEventName;
		[Notification]
		[Field ("FBSDKAppLinkParseEventName", "__Internal")]
		NSString AppLinkParseEventName { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkNavigateInEventName;
		[Notification]
		[Field ("FBSDKAppLinkNavigateInEventName", "__Internal")]
		NSString AppLinkNavigateInEventName { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkNavigateOutEventName;
		[Notification]
		[Field ("FBSDKAppLinkNavigateOutEventName", "__Internal")]
		NSString AppLinkNavigateOutEventName { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkNavigateBackToReferrerEventName;
		[Notification]
		[Field ("FBSDKAppLinkNavigateBackToReferrerEventName", "__Internal")]
		NSString AppLinkNavigateBackToReferrerEventName { get; }
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

	// typedef void (^FBSDKProfileBlock)(FBSDKProfile * _Nullable, NSError * _Nullable);
	delegate void ProfileBlockHandler ([NullAllowed] Profile profile, [NullAllowed] NSError error);

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
		IntPtr Constructor (string userId, [NullAllowed] string firstName,[NullAllowed] string middleName,[NullAllowed] string lastName,[NullAllowed] string name, [NullAllowed] NSUrl linkUrl, [NullAllowed] NSDate refreshDate);

		// @property (nonatomic, strong, class) FBSDKProfile * _Nullable currentProfile;
		[Static]
		[NullAllowed]
		[Export ("currentProfile", ArgumentSemantic.Strong)]
		Profile CurrentProfile { get; set; }

		// @property (readonly, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserId { get; }

		// @property (readonly, nonatomic) NSString * firstName;
		[NullAllowed]
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * middleName;
		[NullAllowed]
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, nonatomic) NSString * lastName;
		[NullAllowed]
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * name;
		[NullAllowed]
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSURL * linkURL;
		[NullAllowed]
		[Export ("linkURL")]
		NSUrl LinkUrl { get; }

		// @property (readonly, nonatomic) NSDate * refreshDate;
		[NullAllowed]
		[Export ("refreshDate")]
		NSDate RefreshDate { get; }

		// +(void)enableUpdatesOnAccessTokenChange:(BOOL)enable;
		[Static]
		[Export ("enableUpdatesOnAccessTokenChange:")]
		void EnableUpdatesOnAccessTokenChange (bool enable);

		// + (void)loadCurrentProfileWithCompletion:(void(^)(FBSDKProfile *profile, NSError *error))completion;
		[Async]
		[Static]
		[Export ("loadCurrentProfileWithCompletion:")]
		void LoadCurrentProfile ([NullAllowed] ProfileBlockHandler completion);

		// - (NSURL *)imageURLForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[return: NullAllowed]
		[Export ("imageURLForPictureMode:size:")]
		NSUrl ImageUrl (ProfilePictureMode mode, CGSize size);

		// -(BOOL)isEqualToProfile:(FBSDKProfile *)profile;
		[Export ("isEqualToProfile:")]
		bool Equals (Profile profile);
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

	// @interface FBSDKSettings : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKSettings")]
	interface Settings {
		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull defaultGraphAPIVersion;
		[Static]
		[Export ("defaultGraphAPIVersion")]
		string DefaultGraphApiVersion { get; }

		// @property (assign, nonatomic, class) CGFloat JPEGCompressionQuality;
		[Static]
		[Export ("JPEGCompressionQuality")]
		nfloat JpegCompressionQuality { get; set; }

		// @property (getter = isAutoInitEnabled, assign, nonatomic, class) BOOL autoInitEnabled;
		[Static]
		[Export ("autoInitEnabled")]
		bool AutoInitEnabled { [Bind ("isAutoInitEnabled")] get; set; }

		// @property (getter = isAutoLogAppEventsEnabled, assign, nonatomic, class) BOOL autoLogAppEventsEnabled;
		[Static]
		[Export ("autoLogAppEventsEnabled")]
		bool AutoLogAppEventsEnabled { [Bind ("isAutoLogAppEventsEnabled")] get; set; }

		// @property (getter = isCodelessDebugLogEnabled, assign, nonatomic, class) BOOL codelessDebugLogEnabled;
		[Static]
		[Export ("codelessDebugLogEnabled")]
		bool CodelessDebugLogEnabled { [Bind ("isCodelessDebugLogEnabled")] get; set; }

		// @property (getter = isAdvertiserIDCollectionEnabled, assign, nonatomic, class) BOOL advertiserIDCollectionEnabled;
		[Static]
		[Export ("advertiserIDCollectionEnabled")]
		bool AdvertiserIdCollectionEnabled { [Bind ("isAdvertiserIDCollectionEnabled")] get; set; }

		// @property (getter = shouldLimitEventAndDataUsage, assign, nonatomic, class) BOOL limitEventAndDataUsage;
		[Static]
		[Export ("limitEventAndDataUsage")]
		bool LimitEventAndDataUsage { [Bind ("shouldLimitEventAndDataUsage")] get; set; }

		// @property (getter = isGraphErrorRecoveryEnabled, assign, nonatomic, class) BOOL graphErrorRecoveryEnabled;
		[Static]
		[Export ("graphErrorRecoveryEnabled")]
		bool GraphErrorRecoveryEnabled { [Bind ("isGraphErrorRecoveryEnabled")] get; set; }

		// @property (copy, nonatomic, class) NSString * _Null_unspecified appID;
		[Static]
		[Export ("appID")]
		string AppId { get; set; }

		// @property (copy, nonatomic, class) NSString * _Null_unspecified appURLSchemeSuffix;
		[Static]
		[Export ("appURLSchemeSuffix")]
		string AppUrlSchemeSuffix { get; set; }

		// @property (copy, nonatomic, class) NSString * _Null_unspecified clientToken;
		[Static]
		[Export ("clientToken")]
		string ClientToken { get; set; }

		// @property (copy, nonatomic, class) NSString * _Null_unspecified displayName;
		[Static]
		[Export ("displayName")]
		string DisplayName { get; set; }

		// @property (copy, nonatomic, class) NSString * _Null_unspecified facebookDomainPart;
		[Static]
		[Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		// @property (copy, nonatomic, class) NSSet<NSString *> * _Nonnull loggingBehaviors;
		[Internal]
		[Static]
		[Export ("loggingBehaviors", ArgumentSemantic.Copy)]
		NSSet _LoggingBehaviors { get; set; }

		// @property (copy, nonatomic, class) NSString * _Null_unspecified graphAPIVersion;
		[Static]
		[Export ("graphAPIVersion")]
		string GraphApiVersion { get; set; }

		// +(void)enableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
		[Static]
		[Export ("enableLoggingBehavior:")]
		void EnableLoggingBehavior ([BindAs (typeof (LoggingBehavior))] NSString loggingBehavior);

		// +(void)disableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
		[Static]
		[Export ("disableLoggingBehavior:")]
		void DisableLoggingBehavior ([BindAs (typeof (LoggingBehavior))] NSString loggingBehavior);
	}

	// typedef void (^FBSDKAccessTokensBlock)(NSArray<FBSDKAccessToken *> * _Nonnull, NSError * _Nullable);
	delegate void AccessTokensBlockHandler (AccessToken [] tokens, [NullAllowed] NSError error);

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKTestUsersManager")]
	interface TestUsersManager {

		// +(instancetype)sharedInstanceForAppID:(NSString *)appID appSecret:(NSString *)appSecret;
		[Static]
		[Export ("sharedInstanceForAppID:appSecret:")]
		TestUsersManager SharedInstance (string appId, string appSecret);

		// -(void)requestTestAccountTokensWithArraysOfPermissions:(NSArray *)arraysOfPermissions createIfNotFound:(BOOL)createIfNotFound completionHandler:(FBSDKAccessTokensBlockHandler)handler;
		[Async]
		[Export ("requestTestAccountTokensWithArraysOfPermissions:createIfNotFound:completionHandler:")]
		void RequestTestAccount (NSSet [] arraysOfPermissions, bool createIfNotFound, [NullAllowed] AccessTokensBlockHandler handler);

		// -(void)addTestAccountWithPermissions:(NSSet *)permissions completionHandler:(FBSDKAccessTokensBlockHandler)handler;
		[Async]
		[Export ("addTestAccountWithPermissions:completionHandler:")]
		void AddTestAccount (NSSet permissions, [NullAllowed] AccessTokensBlockHandler handler);

		// -(void)removeTestAccount:(NSString * _Nonnull)userId completionHandler:(FBSDKErrorBlock _Nullable)handler;
		[Async]
		[Export ("removeTestAccount:completionHandler:")]
		void RemoveTestAccount (string userId, [NullAllowed] ErrorBlockHandler handler);

		// -(void)makeFriendsWithFirst:(FBSDKAccessToken *)first second:(FBSDKAccessToken *)second callback:(void (^)(NSError *))callback;
		[Async]
		[Export ("makeFriendsWithFirst:second:callback:")]
		void MakeFriends (AccessToken first, AccessToken second, [NullAllowed] ErrorBlockHandler handler);
	}

	// @interface FBSDKURL : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKURL")]
	interface Url {
		// +(FBSDKURL * _Nonnull)URLWithURL:(NSURL * _Nonnull)url;
		[Static]
		[Export ("URLWithURL:")]
		Url Create (NSUrl url);

		// +(FBSDKURL * _Nonnull)URLWithInboundURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication;
		[Static]
		[Export ("URLWithInboundURL:sourceApplication:")]
		Url Create (NSUrl url, string sourceApplication);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull targetURL;
		[Export ("targetURL", ArgumentSemantic.Strong)]
		NSUrl TargetUrl { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull targetQueryParameters;
		[Export ("targetQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> TargetQueryParameters { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull appLinkData;
		[Export ("appLinkData", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull appLinkExtras;
		[Export ("appLinkExtras", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkExtras { get; }

		// @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLinkReferer;
		[Export ("appLinkReferer", ArgumentSemantic.Strong)]
		AppLink AppLinkReferer { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull inputURL;
		[Export ("inputURL", ArgumentSemantic.Strong)]
		NSUrl InputUrl { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull inputQueryParameters;
		[Export ("inputQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> InputQueryParameters { get; }
	}

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKUtility")]
	interface Utility {

		// +(NSDictionary *)dictionaryWithQueryString:(NSString *)queryString;
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary CreateDictionary (string queryString);

		[Obsolete ("Use CreateDictionary method instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("CreateDictionary (queryString)")]
		NSDictionary DictionaryWithQueryString (string queryString);

		// +(NSString *)queryStringWithDictionary:(NSDictionary *)dictionary error:(NSError **)errorRef;
		[Static]
		[Export ("queryStringWithDictionary:error:")]
		string CreateQueryString ([NullAllowed] NSDictionary dictionary, out NSError errorRef);

		[Obsolete ("Use CreateQueryString method instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("CreateQueryString (dictionary, out errorRef)")]
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

		// +(NSString * _Nullable)SHA256Hash:(NSObject * _Nullable)input;
		[Static]
		[return: NullAllowed]
		[Export ("SHA256Hash:")]
		string SHA256Hash ([NullAllowed] NSObject input);
	}

	// @interface FBSDKWebViewAppLinkResolver : NSObject <FBSDKAppLinkResolving>
	[BaseType (typeof (NSObject), Name = "FBSDKWebViewAppLinkResolver")]
	interface WebViewAppLinkResolver : AppLinkResolving {
		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance", ArgumentSemantic.Strong)]
		WebViewAppLinkResolver SharedInstance { get; }
	}
}
