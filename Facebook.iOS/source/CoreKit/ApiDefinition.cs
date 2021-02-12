using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace Facebook.CoreKit
{
    delegate void NSDispatchHandler();

    interface AccessTokenDidChangeEventArgs
    {
        // extern NS_SWIFT_NAME(AccessTokenDidChangeUserIDKey) NSString *const FBSDKAccessTokenDidChangeUserIDKey __attribute__((swift_name("AccessTokenDidChangeUserIDKey")));
        [Export("FBSDKAccessTokenDidChangeUserIDKey")]
        bool DidChangeUserIdToken { get; }

        // extern NS_SWIFT_NAME(AccessTokenChangeOldKey) NSString *const FBSDKAccessTokenChangeOldKey __attribute__((swift_name("AccessTokenChangeOldKey")));
        [Export("FBSDKAccessTokenChangeOldKey")]
        AccessToken OldToken { get; }

        // extern NS_SWIFT_NAME(AccessTokenChangeNewKey) NSString *const FBSDKAccessTokenChangeNewKey __attribute__((swift_name("AccessTokenChangeNewKey")));
        [Export("FBSDKAccessTokenChangeNewKey")]
        AccessToken NewToken { get; }

        // extern NS_SWIFT_NAME(AccessTokenDidExpireKey) NSString *const FBSDKAccessTokenDidExpireKey __attribute__((swift_name("AccessTokenDidExpireKey")));
        [Export("FBSDKAccessTokenDidExpireKey")]
        bool DidExpire { get; }
    }

    // @interface FBSDKAccessToken : NSObject <FBSDKCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKAccessToken")]
    [DisableDefaultCtor]
    interface AccessToken : Copying, INSSecureCoding
    {
        // extern NS_SWIFT_NAME(AccessTokenDidChange) const NSNotificationName FBSDKAccessTokenDidChangeNotification __attribute__((swift_name("AccessTokenDidChange")));
        [Notification(typeof(AccessTokenDidChangeEventArgs))]
        [Field("FBSDKAccessTokenDidChangeNotification", "__Internal")]
        NSString DidChangeNotification { get; }

        // extern NS_SWIFT_NAME(AccessTokenDidChangeUserIDKey) NSString *const FBSDKAccessTokenDidChangeUserIDKey __attribute__((swift_name("AccessTokenDidChangeUserIDKey")));
        [Field("FBSDKAccessTokenDidChangeUserIDKey", "__Internal")]
        NSString UserIdKey { get; }

        // extern NS_SWIFT_NAME(AccessTokenChangeOldKey) NSString *const FBSDKAccessTokenChangeOldKey __attribute__((swift_name("AccessTokenChangeOldKey")));
        [Field("FBSDKAccessTokenChangeOldKey", "__Internal")]
        NSString OldTokenKey { get; }

        // extern NS_SWIFT_NAME(AccessTokenChangeNewKey) NSString *const FBSDKAccessTokenChangeNewKey __attribute__((swift_name("AccessTokenChangeNewKey")));
        [Field("FBSDKAccessTokenChangeNewKey", "__Internal")]
        NSString NewTokenKey { get; }

        // extern NS_SWIFT_NAME(AccessTokenDidExpireKey) NSString *const FBSDKAccessTokenDidExpireKey __attribute__((swift_name("AccessTokenDidExpireKey")));
        [Field("FBSDKAccessTokenDidExpireKey", "__Internal")]
        NSString DidExpireKey { get; }

        // @property (copy, nonatomic, class) FBSDKAccessToken * _Nullable currentAccessToken;
        [Static]
        [NullAllowed, Export("currentAccessToken", ArgumentSemantic.Copy)]
        AccessToken CurrentAccessToken { get; set; }

        // @property (readonly, getter = isCurrentAccessTokenActive, assign, nonatomic, class) BOOL currentAccessTokenIsActive;
        [Static]
        [Export("currentAccessTokenIsActive")]
        bool CurrentAccessTokenIsActive { [Bind("isCurrentAccessTokenActive")] get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull appID;
        [Export("appID")] string AppID { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nonnull dataAccessExpirationDate;
        [Export("dataAccessExpirationDate", ArgumentSemantic.Copy)]
        NSDate DataAccessExpirationDate { get; }

        // @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * declinedPermissions __attribute__((swift_private));
        [Export("declinedPermissions", ArgumentSemantic.Copy)]
        NSSet<NSString> DeclinedPermissions { get; }

        // @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * expiredPermissions __attribute__((swift_private));
        [Export("expiredPermissions", ArgumentSemantic.Copy)]
        NSSet<NSString> ExpiredPermissions { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nonnull expirationDate;
        [Export("expirationDate", ArgumentSemantic.Copy)]
        NSDate ExpirationDate { get; }

        // @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * permissions __attribute__((swift_private));
        [Export("permissions", ArgumentSemantic.Copy)]
        NSSet<NSString> Permissions { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nonnull refreshDate;
        [Export("refreshDate", ArgumentSemantic.Copy)]
        NSDate RefreshDate { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
        [Export("tokenString")] string TokenString { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
        [Export("userID")] string UserID { get; }

        // @property (readonly, copy, nonatomic) DEPRECATED_MSG_ATTRIBUTE("The graphDomain property will be removed from AccessToken in the next major release. Use the graphDomain property on AuthenticationToken instead.") NSString * graphDomain __attribute__((deprecated("The graphDomain property will be removed from AccessToken in the next major release. Use the graphDomain property on AuthenticationToken instead.")));
        [Export("graphDomain")] string GraphDomain { get; }

        // @property (readonly, getter = isExpired, assign, nonatomic) BOOL expired;
        [Export("expired")] bool Expired { [Bind("isExpired")] get; }

        // @property (readonly, getter = isDataAccessExpired, assign, nonatomic) BOOL dataAccessExpired;
        [Export("dataAccessExpired")] bool DataAccessExpired { [Bind("isDataAccessExpired")] get; }

        // -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString permissions:(NSArray<NSString *> * _Nonnull)permissions declinedPermissions:(NSArray<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSArray<NSString *> * _Nonnull)expiredPermissions appID:(NSString * _Nonnull)appID userID:(NSString * _Nonnull)userID expirationDate:(NSDate * _Nullable)expirationDate refreshDate:(NSDate * _Nullable)refreshDate dataAccessExpirationDate:(NSDate * _Nullable)dataAccessExpirationDate __attribute__((objc_designated_initializer));
        [Export(
            "initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:")]
        [DesignatedInitializer]
        IntPtr Constructor(string tokenString, string[] permissions, string[] declinedPermissions, string[] expiredPermissions, string appID, string userID, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate);

        // -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString permissions:(NSArray<NSString *> * _Nonnull)permissions declinedPermissions:(NSArray<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSArray<NSString *> * _Nonnull)expiredPermissions appID:(NSString * _Nonnull)appID userID:(NSString * _Nonnull)userID expirationDate:(NSDate * _Nullable)expirationDate refreshDate:(NSDate * _Nullable)refreshDate dataAccessExpirationDate:(NSDate * _Nullable)dataAccessExpirationDate graphDomain:(NSString * _Nullable)graphDomain __attribute__((deprecated("The graphDomain property will be removed from AccessToken in the next major release. Use initializers that do not take in graphDomain domain instead.")));
        [Export(
            "initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:graphDomain:")]
        IntPtr Constructor(string tokenString, string[] permissions, string[] declinedPermissions, string[] expiredPermissions, string appID, string userID, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate, [NullAllowed] string graphDomain);

        // -(BOOL)hasGranted:(NSString * _Nonnull)permission __attribute__((swift_name("hasGranted(permission:)")));
        [Export("hasGranted:")]
        bool HasGranted(string permission);

        // -(BOOL)isEqualToAccessToken:(FBSDKAccessToken * _Nonnull)token;
        [Export("isEqualToAccessToken:")]
        bool IsEqualToAccessToken(AccessToken token);

        // +(void)refreshCurrentAccessToken:(FBSDKGraphRequestBlock _Nullable)completionHandler;
        [Static]
        [Export("refreshCurrentAccessToken:")]
        void RefreshCurrentAccessToken([NullAllowed] GraphRequestBlockHandler completionHandler);
    }

    // @interface FBSDKAppEvents : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKAppEvents")]
    [DisableDefaultCtor]
    interface AppEvents
    {
        // extern NS_SWIFT_NAME(AppEventsLoggingResult) const NSNotificationName FBSDKAppEventsLoggingResultNotification __attribute__((swift_name("AppEventsLoggingResult")));
        [Notification]
        [Field("FBSDKAppEventsLoggingResultNotification", "__Internal")]
        NSString LoggingResultNotification { get; }

        // extern NS_SWIFT_NAME(AppEventsOverrideAppIDBundleKey) NSString *const FBSDKAppEventsOverrideAppIDBundleKey __attribute__((swift_name("AppEventsOverrideAppIDBundleKey")));
        [Field("FBSDKAppEventsOverrideAppIDBundleKey", "__Internal")]
        NSString OverrideAppIdBundleKey { get; }

        // @property (assign, nonatomic, class) FBSDKAppEventsFlushBehavior flushBehavior;
        [Static]
        [Export("flushBehavior", ArgumentSemantic.Assign)]
        AppEventsFlushBehavior FlushBehavior { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable loggingOverrideAppID;
        [Static]
        [NullAllowed, Export("loggingOverrideAppID")]
        string LoggingOverrideAppID { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable userID;
        [Static]
        [NullAllowed, Export("userID")]
        string UserID { get; set; }

        // @property (readonly, nonatomic, class) NSString * _Nonnull anonymousID;
        [Static] [Export("anonymousID")] string AnonymousID { get; }

        // +(void)logEvent:(FBSDKAppEventName _Nonnull)eventName;
        [Static]
        [Export("logEvent:")]
        void LogEvent(string eventName);

        // +(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum;
        [Static]
        [Export("logEvent:valueToSum:")]
        void LogEvent(string eventName, double valueToSum);

        // +(void)logEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("logEvent:parameters:")]
        void LogEvent(string eventName, NSDictionary<NSString, NSObject> parameters);

        // +(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("logEvent:valueToSum:parameters:")]
        void LogEvent(string eventName, double valueToSum, NSDictionary<NSString, NSObject> parameters);

        // +(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(NSNumber * _Nullable)valueToSum parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters accessToken:(FBSDKAccessToken * _Nullable)accessToken;
        [Static]
        [Export("logEvent:valueToSum:parameters:accessToken:")]
        void LogEvent(string eventName, [NullAllowed] NSNumber valueToSum, NSDictionary<NSString, NSObject> parameters, [NullAllowed] AccessToken accessToken);

        // +(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency;
        [Static]
        [Export("logPurchase:currency:")]
        void LogPurchase(double purchaseAmount, string currency);

        // +(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("logPurchase:currency:parameters:")]
        void LogPurchase(double purchaseAmount, string currency, NSDictionary<NSString, NSObject> parameters);

        // +(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters accessToken:(FBSDKAccessToken * _Nullable)accessToken;
        [Static]
        [Export("logPurchase:currency:parameters:accessToken:")]
        void LogPurchase(double purchaseAmount, string currency, NSDictionary<NSString, NSObject> parameters, [NullAllowed] AccessToken accessToken);

        // +(void)logPushNotificationOpen:(NSDictionary * _Nonnull)payload;
        [Static]
        [Export("logPushNotificationOpen:")]
        void LogPushNotificationOpen(NSDictionary payload);

        // +(void)logPushNotificationOpen:(NSDictionary * _Nonnull)payload action:(NSString * _Nonnull)action;
        [Static]
        [Export("logPushNotificationOpen:action:")]
        void LogPushNotificationOpen(NSDictionary payload, string action);

        // +(void)logProductItem:(NSString * _Nonnull)itemID availability:(FBSDKProductAvailability)availability condition:(FBSDKProductCondition)condition description:(NSString * _Nonnull)description imageLink:(NSString * _Nonnull)imageLink link:(NSString * _Nonnull)link title:(NSString * _Nonnull)title priceAmount:(double)priceAmount currency:(NSString * _Nonnull)currency gtin:(NSString * _Nullable)gtin mpn:(NSString * _Nullable)mpn brand:(NSString * _Nullable)brand parameters:(NSDictionary<NSString *,id> * _Nullable)parameters;
        [Static]
        [Export(
            "logProductItem:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:")]
        void LogProductItem(string itemID, ProductAvailability availability, ProductCondition condition, string description, string imageLink, string link, string title, double priceAmount, string currency, [NullAllowed] string gtin, [NullAllowed] string mpn, [NullAllowed] string brand, [NullAllowed] NSDictionary<NSString, NSObject> parameters);

        // +(void)activateApp;
        [Static]
        [Export("activateApp")]
        void ActivateApp();

        // +(void)setPushNotificationsDeviceToken:(NSData * _Nonnull)deviceToken;
        [Static]
        [Export("setPushNotificationsDeviceToken:")]
        void SetPushNotificationsDeviceToken(NSData deviceToken);

        // +(void)setPushNotificationsDeviceTokenString:(NSString * _Nonnull)deviceTokenString __attribute__((swift_name("setPushNotificationsDeviceToken(_:)")));
        [Static]
        [Export("setPushNotificationsDeviceTokenString:")]
        void SetPushNotificationsDeviceTokenString(string deviceTokenString);

        // +(void)flush;
        [Static]
        [Export("flush")]
        void Flush();

        // +(FBSDKGraphRequest * _Nullable)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken * _Nullable)accessToken;
        [Static]
        [Export("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
        [return: NullAllowed]
        GraphRequest RequestForCustomAudienceThirdPartyIDWithAccessToken([NullAllowed] AccessToken accessToken);

        // +(void)clearUserID;
        [Static]
        [Export("clearUserID")]
        void ClearUserID();

        // +(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country __attribute__((swift_name("setUser(email:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:)")));
        [Static]
        [Export("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:")]
        void SetUserEmail([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country);

        // +(NSString * _Nullable)getUserData;
        [Static]
        [NullAllowed, Export("getUserData")]
        string GetUserData { get; }

        // +(void)clearUserData;
        [Static]
        [Export("clearUserData")]
        void ClearUserData();

        // +(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
        [Static]
        [Export("setUserData:forType:")]
        void SetUserData([NullAllowed] string data, string type);

        // +(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
        [Static]
        [Export("clearUserDataForType:")]
        void ClearUserDataForType(string type);

        // +(void)updateUserProperties:(NSDictionary<NSString *,id> * _Nonnull)properties handler:(FBSDKGraphRequestBlock _Nullable)handler __attribute__((deprecated("updateUserProperties is deprecated")));
        [Static]
        [Export("updateUserProperties:handler:")]
        void UpdateUserProperties(NSDictionary<NSString, NSObject> properties, [NullAllowed] GraphRequestBlockHandler handler);

        // +(void)augmentHybridWKWebView:(WKWebView * _Nonnull)webView;
        [Static]
        [Export("augmentHybridWKWebView:")]
        void AugmentHybridWKWebView(WKWebView webView);

        // +(void)setIsUnityInit:(BOOL)isUnityInit;
        [Static]
        [Export("setIsUnityInit:")]
        void SetIsUnityInit(bool isUnityInit);

        // +(void)sendEventBindingsToUnity;
        [Static]
        [Export("sendEventBindingsToUnity")]
        void SendEventBindingsToUnity();
    }

    // @interface FBSDKApplicationDelegate : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKApplicationDelegate")]
    [DisableDefaultCtor]
    interface ApplicationDelegate
    {
        // @property (readonly, nonatomic, strong, class) NS_SWIFT_NAME(shared) FBSDKApplicationDelegate * sharedInstance __attribute__((swift_name("shared")));
        [Static]
        [Export("sharedInstance", ArgumentSemantic.Strong)]
        ApplicationDelegate SharedInstance { get; }

        // -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
        [Export("application:openURL:sourceApplication:annotation:")]
        bool OpenUrl(UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

        // -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
        [Export("application:openURL:options:")]
        bool OpenUrl(UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);

        // -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
        [Export("application:didFinishLaunchingWithOptions:")]
        bool FinishedLaunching(UIApplication application, [NullAllowed] NSDictionary<NSString, NSObject> launchOptions);

        // +(void)initializeSDK:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
        [Static]
        [Export("initializeSDK:")]
        void InitializeSDK([NullAllowed] NSDictionary<NSString, NSObject> launchOptions);
    }

    // @interface FBSDKAppLink : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKAppLink")]
    [DisableDefaultCtor]
    interface AppLink : INativeObject
    {
        // extern NS_SWIFT_NAME(AppLinkVersion) NSString *const FBSDKAppLinkVersion __attribute__((swift_name("AppLinkVersion")));
        [Field("FBSDKAppLinkVersion", "__Internal")]
        NSString Version { get; }

        // +(instancetype _Nonnull)appLinkWithSourceURL:(NSURL * _Nullable)sourceURL targets:(NSArray<FBSDKAppLinkTarget *> * _Nonnull)targets webURL:(NSURL * _Nullable)webURL __attribute__((swift_name("init(sourceURL:targets:webURL:)")));
        [Static]
        [Export("appLinkWithSourceURL:targets:webURL:")]
        AppLink AppLinkWithSourceUrl([NullAllowed] NSUrl sourceUrl, AppLinkTarget[] targets, [NullAllowed] NSUrl webUrl);

        // @property (readonly, nonatomic, strong) NSURL * _Nullable sourceURL;
        [NullAllowed, Export("sourceURL", ArgumentSemantic.Strong)]
        NSUrl SourceUrl { get; }

        // @property (readonly, copy, nonatomic) NSArray<FBSDKAppLinkTarget *> * _Nonnull targets;
        [Export("targets", ArgumentSemantic.Copy)]
        AppLinkTarget[] Targets { get; }

        // @property (readonly, nonatomic, strong) NSURL * _Nullable webURL;
        [NullAllowed, Export("webURL", ArgumentSemantic.Strong)]
        NSUrl WebUrl { get; }
    }

    // typedef void (^FBSDKAppLinkNavigationBlock)(FBSDKAppLinkNavigationType, NSError * _Nullable);
    delegate void AppLinkNavigationBlockHandler(AppLinkNavigationType arg0, [NullAllowed] NSError arg1);

    // @interface FBSDKAppLinkNavigation : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkNavigation")]
    [DisableDefaultCtor]
    interface AppLinkNavigation
    {
        // @property (nonatomic, strong, class) NS_SWIFT_NAME(default) id<FBSDKAppLinkResolving> defaultResolver __attribute__((swift_name("default")));
        [Static]
        [Export("defaultResolver", ArgumentSemantic.Strong)]
        AppLinkResolving DefaultResolver { get; set; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull extras;
        [Export("extras", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Extras { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull appLinkData;
        [Export("appLinkData", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> AppLinkData { get; }

        // @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLink;
        [Export("appLink", ArgumentSemantic.Strong)]
        AppLink AppLink { get; }

        // @property (readonly, nonatomic) FBSDKAppLinkNavigationType navigationType;
        [Export("navigationType")] AppLinkNavigationType NavigationType { get; }

        // +(instancetype _Nonnull)navigationWithAppLink:(FBSDKAppLink * _Nonnull)appLink extras:(NSDictionary<NSString *,id> * _Nonnull)extras appLinkData:(NSDictionary<NSString *,id> * _Nonnull)appLinkData __attribute__((swift_name("init(appLink:extras:appLinkData:)")));
        [Static]
        [Export("navigationWithAppLink:extras:appLinkData:")]
        AppLinkNavigation NavigationWithAppLink(AppLink appLink, NSDictionary<NSString, NSObject> extras, NSDictionary<NSString, NSObject> appLinkData);

        // +(NSDictionary<NSString *,NSDictionary<NSString *,NSString *> *> * _Nonnull)callbackAppLinkDataForAppWithName:(NSString * _Nonnull)appName url:(NSString * _Nonnull)url __attribute__((swift_name("callbackAppLinkData(forApp:url:)")));
        [Static]
        [Export("callbackAppLinkDataForAppWithName:url:")]
        NSDictionary<NSString, NSDictionary<NSString, NSString>> CallbackAppLinkDataForAppWithName(string appName, string url);

        // -(FBSDKAppLinkNavigationType)navigate:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error")));
        [Export("navigate:")]
        AppLinkNavigationType Navigate([NullAllowed] out NSError error);

        // +(void)resolveAppLink:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkBlock _Nonnull)handler;
        [Static]
        [Export("resolveAppLink:handler:")]
        void ResolveAppLink(NSUrl destination, AppLinkBlockHandler handler);

        // +(void)resolveAppLink:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkBlock _Nonnull)handler;
        [Static]
        [Export("resolveAppLink:resolver:handler:")]
        void ResolveAppLink(NSUrl destination, AppLinkResolving resolver, AppLinkBlockHandler handler);

        // +(FBSDKAppLinkNavigationType)navigateToAppLink:(FBSDKAppLink * _Nonnull)link error:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error")));
        [Static]
        [Export("navigateToAppLink:error:")]
        AppLinkNavigationType NavigateToAppLink(AppLink link, [NullAllowed] out NSError error);

        // +(FBSDKAppLinkNavigationType)navigationTypeForLink:(FBSDKAppLink * _Nonnull)link;
        [Static]
        [Export("navigationTypeForLink:")]
        AppLinkNavigationType NavigationTypeForLink(AppLink link);

        // +(void)navigateToURL:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkNavigationBlock _Nonnull)handler;
        [Static]
        [Export("navigateToURL:handler:")]
        void NavigateToUrl(NSUrl destination, AppLinkNavigationBlockHandler handler);

        // +(void)navigateToURL:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkNavigationBlock _Nonnull)handler;
        [Static]
        [Export("navigateToURL:resolver:handler:")]
        void NavigateToUrl(NSUrl destination, AppLinkResolving resolver, AppLinkNavigationBlockHandler handler);
    }

    // typedef void (^FBSDKAppLinksBlock)(NSDictionary<NSURL *,FBSDKAppLink *> * _Nonnull, NSError * _Nullable);
    delegate void AppLinksBlockHandler(NSDictionary<NSUrl, AppLink> arg0, [NullAllowed] NSError arg1);

    // @interface FBSDKAppLinkResolver : NSObject <FBSDKAppLinkResolving>
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkResolver")]
    [DisableDefaultCtor]
    interface AppLinkResolver : AppLinkResolving
    {
        // -(void)appLinksFromURLs:(NSArray<NSURL *> * _Nonnull)urls handler:(FBSDKAppLinksBlock _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)));
        [Export("appLinksFromURLs:handler:")]
        void AppLinksFromUrls(NSUrl[] urls, AppLinksBlockHandler handler);

        // +(instancetype _Nonnull)resolver __attribute__((swift_name("init()")));
        [Static]
        [Export("resolver")]
        AppLinkResolver Resolver();
    }

    // typedef void (^FBSDKAppLinkBlock)(FBSDKAppLink * _Nullable, NSError * _Nullable);
    delegate void AppLinkBlockHandler([NullAllowed] AppLink arg0, [NullAllowed] NSError arg1);

    // @protocol FBSDKAppLinkResolving <NSObject>
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
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkResolving")]
    interface AppLinkResolving
    {
        // @required -(void)appLinkFromURL:(NSURL * _Nonnull)url handler:(FBSDKAppLinkBlock _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)));
        [Abstract]
        [Export("appLinkFromURL:handler:")]
        void Handler(NSUrl url, AppLinkBlockHandler handler);
    }

    // @interface FBSDKAppLinkReturnToRefererController : NSObject <FBSDKAppLinkReturnToRefererViewDelegate>
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkReturnToRefererController")]
    interface AppLinkReturnToRefererController : AppLinkReturnToRefererViewDelegate
    {
        [Wrap("WeakDelegate")] [NullAllowed] AppLinkReturnToRefererControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FBSDKAppLinkReturnToRefererControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) FBSDKAppLinkReturnToRefererView * _Nonnull view;
        [Export("view", ArgumentSemantic.Strong)]
        AppLinkReturnToRefererView View { get; set; }

        // -(instancetype _Nonnull)initForDisplayAboveNavController:(UINavigationController * _Nonnull)navController __attribute__((swift_name("init(navController:)")));
        [Export("initForDisplayAboveNavController:")]
        IntPtr Constructor(UINavigationController navController);

        // -(void)removeFromNavController;
        [Export("removeFromNavController")]
        void RemoveFromNavController();

        // -(void)showViewForRefererAppLink:(FBSDKAppLink * _Nonnull)refererAppLink __attribute__((swift_name("showView(forReferer:)")));
        [Export("showViewForRefererAppLink:")]
        void ShowViewForRefererAppLink(AppLink refererAppLink);

        // -(void)showViewForRefererURL:(NSURL * _Nonnull)url __attribute__((swift_name("showView(forReferer:)")));
        [Export("showViewForRefererURL:")]
        void ShowViewForRefererUrl(NSUrl url);

        // -(void)closeViewAnimated:(BOOL)animated;
        [Export("closeViewAnimated:")]
        void CloseViewAnimated(bool animated);
    }

    // @protocol FBSDKAppLinkReturnToRefererControllerDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkReturnToRefererControllerDelegate")]
    interface AppLinkReturnToRefererControllerDelegate
    {
        // @optional -(void)returnToRefererController:(FBSDKAppLinkReturnToRefererController * _Nonnull)controller willNavigateToAppLink:(FBSDKAppLink * _Nonnull)appLink __attribute__((swift_name("return(to:willNavigateTo:)")));
        [Export("returnToRefererController:willNavigateToAppLink:")]
        void WillNavigateToAppLink(AppLinkReturnToRefererController controller, AppLink appLink);

        // @optional -(void)returnToRefererController:(FBSDKAppLinkReturnToRefererController * _Nonnull)controller didNavigateToAppLink:(FBSDKAppLink * _Nonnull)url type:(FBSDKAppLinkNavigationType)type __attribute__((swift_name("return(to:didNavigateTo:type:)")));
        [Export("returnToRefererController:didNavigateToAppLink:type:")]
        void DidNavigateToAppLink(AppLinkReturnToRefererController controller, AppLink url, AppLinkNavigationType type);
    }

    // @protocol FBSDKAppLinkReturnToRefererViewDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkReturnToRefererViewDelegate")]
    interface AppLinkReturnToRefererViewDelegate
    {
        // @required -(void)returnToRefererViewDidTapInsideCloseButton:(FBSDKAppLinkReturnToRefererView * _Nonnull)view __attribute__((swift_name("returnToRefererViewDidTapInsideCloseButton(_:)")));
        [Abstract]
        [Export("returnToRefererViewDidTapInsideCloseButton:")]
        void ReturnToRefererViewDidTapInsideCloseButton(AppLinkReturnToRefererView view);

        // @required -(void)returnToRefererViewDidTapInsideLink:(FBSDKAppLinkReturnToRefererView * _Nonnull)view link:(FBSDKAppLink * _Nonnull)link __attribute__((swift_name("returnToRefererView(_:didTapInside:)")));
        [Abstract]
        [Export("returnToRefererViewDidTapInsideLink:link:")]
        void ReturnToRefererViewDidTapInsideLink(AppLinkReturnToRefererView view, AppLink link);
    }

    // @interface FBSDKAppLinkReturnToRefererView : UIView
    [BaseType(typeof(UIView), Name = "FBSDKAppLinkReturnToRefererView")]
    interface AppLinkReturnToRefererView
    {
        [Wrap("WeakDelegate")] [NullAllowed] AppLinkReturnToRefererViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FBSDKAppLinkReturnToRefererViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic, strong) FBSDKAppLink * _Nonnull refererAppLink;
        [Export("refererAppLink", ArgumentSemantic.Strong)]
        AppLink RefererAppLink { get; set; }

        // @property (assign, nonatomic) FBSDKIncludeStatusBarInSize includeStatusBarInSize __attribute__((swift_name("statusBarSizeInclude")));
        [Export("includeStatusBarInSize", ArgumentSemantic.Assign)]
        IncludeStatusBarInSize IncludeStatusBarInSize { get; set; }

        // @property (getter = isClosed, assign, nonatomic) BOOL closed;
        [Export("closed")] bool Closed { [Bind("isClosed")] get; set; }
    }

    // @interface FBSDKAppLinkTarget : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkTarget")]
    [DisableDefaultCtor]
    interface AppLinkTarget
    {
        // +(instancetype _Nonnull)appLinkTargetWithURL:(NSURL * _Nullable)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName __attribute__((swift_name("init(url:appStoreId:appName:)")));
        [Static]
        [Export("appLinkTargetWithURL:appStoreId:appName:")]
        AppLinkTarget AppLinkTargetWithUrl([NullAllowed] NSUrl url, [NullAllowed] string appStoreId, string appName);

        // @property (readonly, nonatomic, strong) NSURL * _Nullable URL;
        [NullAllowed, Export("URL", ArgumentSemantic.Strong)]
        NSUrl Url { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable appStoreId;
        [NullAllowed, Export("appStoreId")] string AppStoreId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull appName;
        [Export("appName")] string AppName { get; }
    }

    // typedef void (^FBSDKURLBlock)(NSURL * _Nullable, NSError * _Nullable);
    delegate void UrlBlockHandler([NullAllowed] NSUrl arg0, [NullAllowed] NSError arg1);

    // @interface FBSDKAppLinkUtility : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkUtility")]
    [DisableDefaultCtor]
    interface AppLinkUtility
    {
        // +(void)fetchDeferredAppLink:(FBSDKURLBlock _Nullable)handler;
        [Static]
        [Export("fetchDeferredAppLink:")]
        void FetchDeferredAppLink([NullAllowed] UrlBlockHandler handler);

        // +(NSString * _Nullable)appInvitePromotionCodeFromURL:(NSURL * _Nonnull)url;
        [Static]
        [Export("appInvitePromotionCodeFromURL:")]
        [return: NullAllowed]
        string AppInvitePromotionCodeFromUrl(NSUrl url);

        // +(BOOL)isMatchURLScheme:(NSString * _Nonnull)scheme;
        [Static]
        [Export("isMatchURLScheme:")]
        bool IsMatchUrlScheme(string scheme);
    }

    // @interface FBSDKButton : UIButton
    [BaseType(typeof(UIButton), Name = "FBSDKButton")]
    interface Button
    {
    }

    [Static]
    interface Errors
    {
        // extern NS_SWIFT_NAME(ErrorDomain) const NSErrorDomain FBSDKErrorDomain __attribute__((swift_name("ErrorDomain")));
        [Field("FBSDKErrorDomain", "__Internal")]
        NSString DomainKey { get; }

        // extern NS_SWIFT_NAME(ErrorArgumentCollectionKey) const NSErrorUserInfoKey FBSDKErrorArgumentCollectionKey __attribute__((swift_name("ErrorArgumentCollectionKey")));
        [Field("FBSDKErrorArgumentCollectionKey", "__Internal")]
        NSString ArgumentCollectionKey { get; }

        // extern NS_SWIFT_NAME(ErrorArgumentNameKey) const NSErrorUserInfoKey FBSDKErrorArgumentNameKey __attribute__((swift_name("ErrorArgumentNameKey")));
        [Field("FBSDKErrorArgumentNameKey", "__Internal")]
        NSString ArgumentNameKey { get; }

        // extern NS_SWIFT_NAME(ErrorArgumentValueKey) const NSErrorUserInfoKey FBSDKErrorArgumentValueKey __attribute__((swift_name("ErrorArgumentValueKey")));
        [Field("FBSDKErrorArgumentValueKey", "__Internal")]
        NSString ArgumentValueKey { get; }

        // extern NS_SWIFT_NAME(ErrorDeveloperMessageKey) const NSErrorUserInfoKey FBSDKErrorDeveloperMessageKey __attribute__((swift_name("ErrorDeveloperMessageKey")));
        [Field("FBSDKErrorDeveloperMessageKey", "__Internal")]
        NSString DeveloperMessageKey { get; }

        // extern NS_SWIFT_NAME(ErrorLocalizedDescriptionKey) const NSErrorUserInfoKey FBSDKErrorLocalizedDescriptionKey __attribute__((swift_name("ErrorLocalizedDescriptionKey")));
        [Field("FBSDKErrorLocalizedDescriptionKey", "__Internal")]
        NSString LocalizedDescriptionKey { get; }

        // extern NS_SWIFT_NAME(ErrorLocalizedTitleKey) const NSErrorUserInfoKey FBSDKErrorLocalizedTitleKey __attribute__((swift_name("ErrorLocalizedTitleKey")));
        [Field("FBSDKErrorLocalizedTitleKey", "__Internal")]
        NSString LocalizedTitleKey { get; }
    }

    [Static]
    interface GraphRequestErrors
    {
        // extern NS_SWIFT_NAME(GraphRequestErrorKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorKey __attribute__((swift_name("GraphRequestErrorKey")));
        [Field("FBSDKGraphRequestErrorKey", "__Internal")]
        NSString ErrorKey { get; }

        // extern NS_SWIFT_NAME(GraphRequestErrorGraphErrorCodeKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorCodeKey __attribute__((swift_name("GraphRequestErrorGraphErrorCodeKey")));
        [Field("FBSDKGraphRequestErrorGraphErrorCodeKey", "__Internal")]
        NSString GraphErrorCodeKey { get; }

        // extern NS_SWIFT_NAME(GraphRequestErrorGraphErrorSubcodeKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorSubcodeKey __attribute__((swift_name("GraphRequestErrorGraphErrorSubcodeKey")));
        [Field("FBSDKGraphRequestErrorGraphErrorSubcodeKey", "__Internal")]
        NSString GraphErrorSubcodeKey { get; }

        // extern NS_SWIFT_NAME(GraphRequestErrorHTTPStatusCodeKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorHTTPStatusCodeKey __attribute__((swift_name("GraphRequestErrorHTTPStatusCodeKey")));
        [Field("FBSDKGraphRequestErrorHTTPStatusCodeKey", "__Internal")]
        NSString HttpStatusCodeKey { get; }

        // extern NS_SWIFT_NAME(GraphRequestErrorParsedJSONResponseKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorParsedJSONResponseKey __attribute__((swift_name("GraphRequestErrorParsedJSONResponseKey")));
        [Field("FBSDKGraphRequestErrorParsedJSONResponseKey", "__Internal")]
        NSString ParsedJsonResponseKey { get; }
    }

    // typedef void (^FBSDKCodeBlock)();
    delegate void CodeBlockHandler();

    // typedef void (^FBSDKErrorBlock)(NSError * _Nullable);
    delegate void ErrorBlockHandler([NullAllowed] NSError arg0);

    // typedef void (^FBSDKSuccessBlock)(BOOL, NSError * _Nullable);
    delegate void SuccessBlockHandler(bool arg0, [NullAllowed] NSError arg1);

    // @protocol FBSDKErrorRecoveryAttempting <NSObject>
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
    [BaseType(typeof(NSObject), Name = "FBSDKErrorRecoveryAttempting")]
    interface ErrorRecoveryAttempting
    {
    }

    interface ICopying
    {
    }

    // @protocol FBSDKCopying <NSCopying, NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Model(AutoGeneratedName = true)]
    [Protocol]
    [BaseType(typeof(NSObject), Name = "FBSDKCopying")]
    interface Copying : INSCopying
    {
        // @required -(id _Nonnull)copy;
        [Abstract]
        [Export("copy")]
        NSObject Copy();
    }

    // @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "FBSDKGraphErrorRecoveryProcessorDelegate")]
    interface GraphErrorRecoveryProcessorDelegate
    {
        // @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor * _Nonnull)processor didRecover:(BOOL)didRecover error:(NSError * _Nullable)error;
        [Abstract]
        [Export("processorDidAttemptRecovery:didRecover:error:")]
        void ProcessorDidAttemptRecovery(GraphErrorRecoveryProcessor processor, bool didRecover, [NullAllowed] NSError error);

        // @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor * _Nonnull)processor error:(NSError * _Nullable)error;
        [Export("processorWillProcessError:error:")]
        bool ProcessorWillProcessError(GraphErrorRecoveryProcessor processor, [NullAllowed] NSError error);
    }

    // @interface FBSDKGraphErrorRecoveryProcessor : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGraphErrorRecoveryProcessor")]
    interface GraphErrorRecoveryProcessor
    {
        [Wrap("WeakDelegate")] [NullAllowed] GraphErrorRecoveryProcessorDelegate Delegate { get; }

        // @property (readonly, nonatomic, strong) id<FBSDKGraphErrorRecoveryProcessorDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Strong)]
        NSObject WeakDelegate { get; }

        // -(BOOL)processError:(NSError * _Nonnull)error request:(FBSDKGraphRequest * _Nonnull)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate> _Nullable)delegate;
        [Export("processError:request:delegate:")]
        bool ProcessError(NSError error, GraphRequest request, [NullAllowed] GraphErrorRecoveryProcessorDelegate @delegate);

        // -(void)didPresentErrorWithRecovery:(BOOL)didRecover contextInfo:(void * _Nullable)contextInfo;
        [Export("didPresentErrorWithRecovery:contextInfo:")]
        void ErrorPresentedWithRecovery(bool didRecover, [NullAllowed] NSObject contextInfo);
    }

    // @interface FBSDKGraphRequest : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGraphRequest")]
    [DisableDefaultCtor]
    interface GraphRequest
    {
        // -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath;
        [Export("initWithGraphPath:")]
        IntPtr Constructor(string graphPath);

        // -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
        [Export("initWithGraphPath:HTTPMethod:")]
        IntPtr Constructor(string graphPath, string method);

        // -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Export("initWithGraphPath:parameters:")]
        IntPtr Constructor(string graphPath, NSDictionary<NSString, NSObject> parameters);

        // -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
        [Export("initWithGraphPath:parameters:HTTPMethod:")]
        IntPtr Constructor(string graphPath, NSDictionary<NSString, NSObject> parameters, string method);

        // -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters tokenString:(NSString * _Nullable)tokenString version:(NSString * _Nullable)version HTTPMethod:(FBSDKHTTPMethod _Nonnull)method __attribute__((objc_designated_initializer));
        [Export("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
        [DesignatedInitializer]
        IntPtr Constructor(string graphPath, NSDictionary<NSString, NSObject> parameters, [NullAllowed] string tokenString, [NullAllowed] string version, string method);

        // @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull parameters;
        [Export("parameters", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Parameters { get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable tokenString;
        [NullAllowed, Export("tokenString")] string TokenString { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull graphPath;
        [Export("graphPath")] string GraphPath { get; }

        // @property (readonly, copy, nonatomic) FBSDKHTTPMethod _Nonnull HTTPMethod;
        [Export("HTTPMethod")] string HTTPMethod { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull version;
        [Export("version")] string Version { get; }

        // -(void)setGraphErrorRecoveryDisabled:(BOOL)disable __attribute__((swift_name("setGraphErrorRecovery(disabled:)")));
        [Export("setGraphErrorRecoveryDisabled:")]
        void SetGraphErrorRecoveryDisabled(bool disable);

        // -(FBSDKGraphRequestConnection * _Nonnull)startWithCompletionHandler:(FBSDKGraphRequestBlock _Nullable)handler;
        [Export("startWithCompletionHandler:")]
        GraphRequestConnection StartWithCompletionHandler([NullAllowed] GraphRequestBlockHandler handler);
    }

    // typedef void (^FBSDKGraphRequestBlock)(FBSDKGraphRequestConnection * _Nullable, id _Nullable, NSError * _Nullable);
    delegate void GraphRequestBlockHandler([NullAllowed] GraphRequestConnection arg0, [NullAllowed] NSObject arg1, [NullAllowed] NSError arg2);

    // @protocol FBSDKGraphRequestConnectionDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "FBSDKGraphRequestConnectionDelegate")]
    interface GraphRequestConnectionDelegate
    {
        // extern NS_SWIFT_NAME(NonJSONResponseProperty) NSString *const FBSDKNonJSONResponseProperty __attribute__((swift_name("NonJSONResponseProperty")));
        [Field("FBSDKNonJSONResponseProperty", "__Internal")]
        NSString NonJSONResponseProperty { get; }

        // @optional -(void)requestConnectionWillBeginLoading:(FBSDKGraphRequestConnection * _Nonnull)connection;
        [Export("requestConnectionWillBeginLoading:")]
        void RequestConnectionWillBeginLoading(GraphRequestConnection connection);

        // @optional -(void)requestConnectionDidFinishLoading:(FBSDKGraphRequestConnection * _Nonnull)connection;
        [Export("requestConnectionDidFinishLoading:")]
        void RequestConnectionDidFinishLoading(GraphRequestConnection connection);

        // @optional -(void)requestConnection:(FBSDKGraphRequestConnection * _Nonnull)connection didFailWithError:(NSError * _Nonnull)error;
        [Export("requestConnection:didFailWithError:")]
        void RequestConnection(GraphRequestConnection connection, NSError error);

        // @optional -(void)requestConnection:(FBSDKGraphRequestConnection * _Nonnull)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
        [Export("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
        void RequestConnection(GraphRequestConnection connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
    }

    // @interface FBSDKGraphRequestConnection : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGraphRequestConnection")]
    interface GraphRequestConnection
    {
        // @property (assign, nonatomic, class) NSTimeInterval defaultConnectionTimeout;
        [Static]
        [Export("defaultConnectionTimeout")]
        double DefaultConnectionTimeout { get; set; }

        [Wrap("WeakDelegate")] [NullAllowed] GraphRequestConnectionDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<FBSDKGraphRequestConnectionDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) NSTimeInterval timeout;
        [Export("timeout")] double Timeout { get; set; }

        // @property (readonly, retain, nonatomic) NSHTTPURLResponse * _Nullable urlResponse;
        [NullAllowed, Export("urlResponse", ArgumentSemantic.Retain)]
        NSHttpUrlResponse UrlResponse { get; }

        // @property (retain, nonatomic) NSOperationQueue * _Nonnull delegateQueue;
        [Export("delegateQueue", ArgumentSemantic.Retain)]
        NSOperationQueue DelegateQueue { get; set; }

        // -(void)addRequest:(FBSDKGraphRequest * _Nonnull)request completionHandler:(FBSDKGraphRequestBlock _Nonnull)handler;
        [Export("addRequest:completionHandler:")]
        void AddRequest(GraphRequest request, GraphRequestBlockHandler handler);

        // -(void)addRequest:(FBSDKGraphRequest * _Nonnull)request batchEntryName:(NSString * _Nonnull)name completionHandler:(FBSDKGraphRequestBlock _Nonnull)handler;
        [Export("addRequest:batchEntryName:completionHandler:")]
        void AddRequest(GraphRequest request, string name, GraphRequestBlockHandler handler);

        // -(void)addRequest:(FBSDKGraphRequest * _Nonnull)request batchParameters:(NSDictionary<NSString *,id> * _Nullable)batchParameters completionHandler:(FBSDKGraphRequestBlock _Nonnull)handler;
        [Export("addRequest:batchParameters:completionHandler:")]
        void AddRequest(GraphRequest request, [NullAllowed] NSDictionary<NSString, NSObject> batchParameters, GraphRequestBlockHandler handler);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)overrideGraphAPIVersion:(NSString * _Nonnull)version;
        [Export("overrideGraphAPIVersion:")]
        void OverrideGraphAPIVersion(string version);
    }

    // @interface FBSDKGraphRequestDataAttachment : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKGraphRequestDataAttachment")]
    [DisableDefaultCtor]
    interface GraphRequestDataAttachment
    {
        // -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data filename:(NSString * _Nonnull)filename contentType:(NSString * _Nonnull)contentType __attribute__((objc_designated_initializer));
        [Export("initWithData:filename:contentType:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSData data, string filename, string contentType);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull contentType;
        [Export("contentType")] string ContentType { get; }

        // @property (readonly, nonatomic, strong) NSData * _Nonnull data;
        [Export("data", ArgumentSemantic.Strong)]
        NSData Data { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull filename;
        [Export("filename")] string Filename { get; }
    }

    interface MeasurementEventArgs
    {
        [Export("FBSDKMeasurementEventNameKey")]
        string EventName { get; }

        [Export("FBSDKMeasurementEventArgsKey")]
        NSDictionary EventArgs { get; }
    }

    // @interface FBSDKMeasurementEvent : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKMeasurementEvent")]
    interface MeasurementEvent
    {
        // extern NS_SWIFT_NAME(MeasurementEvent) const NSNotificationName FBSDKMeasurementEventNotification __attribute__((swift_name("MeasurementEvent")));
        [Notification(typeof(MeasurementEventArgs))]
        [Field("FBSDKMeasurementEventNotification", "__Internal")]
        NSString EventNotification { get; }

        // extern NS_SWIFT_NAME(MeasurementEventNameKey) NSString *const FBSDKMeasurementEventNameKey __attribute__((swift_name("MeasurementEventNameKey")));
        [Field("FBSDKMeasurementEventNameKey", "__Internal")]
        NSString EventNameKey { get; }

        // extern NS_SWIFT_NAME(MeasurementEventArgsKey) NSString *const FBSDKMeasurementEventArgsKey __attribute__((swift_name("MeasurementEventArgsKey")));
        [Field("FBSDKMeasurementEventArgsKey", "__Internal")]
        NSString EventArgsKey { get; }

        // extern NS_SWIFT_NAME(AppLinkParseEventName) NSString *const FBSDKAppLinkParseEventName __attribute__((swift_name("AppLinkParseEventName")));
        [Notification]
        [Field("FBSDKAppLinkParseEventName", "__Internal")]
        NSString AppLinkParseEventName { get; }

        // extern NS_SWIFT_NAME(AppLinkNavigateInEventName) NSString *const FBSDKAppLinkNavigateInEventName __attribute__((swift_name("AppLinkNavigateInEventName")));
        [Notification]
        [Field("FBSDKAppLinkNavigateInEventName", "__Internal")]
        NSString AppLinkNavigateInEventName { get; }

        // extern NS_SWIFT_NAME(AppLinkNavigateOutEventName) NSString *const FBSDKAppLinkNavigateOutEventName __attribute__((swift_name("AppLinkNavigateOutEventName")));
        [Notification]
        [Field("FBSDKAppLinkNavigateOutEventName", "__Internal")]
        NSString AppLinkNavigateOutEventName { get; }

        // extern NS_SWIFT_NAME(AppLinkNavigateBackToReferrerEventName) NSString *const FBSDKAppLinkNavigateBackToReferrerEventName __attribute__((swift_name("AppLinkNavigateBackToReferrerEventName")));
        [Notification]
        [Field("FBSDKAppLinkNavigateBackToReferrerEventName", "__Internal")]
        NSString AppLinkNavigateBackToReferrerEventName { get; }
    }

    // @protocol FBSDKMutableCopying <FBSDKCopying, NSMutableCopying>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "FBSDKMutableCopying")]
    interface MutableCopying : Copying, INSMutableCopying
    {
        // @required -(id _Nonnull)mutableCopy;
        [Abstract]
        [Export("mutableCopy")]
        NSObject MutableCopy();
    }

    interface ProfileDidChangeEventArgs
    {
        [Export("FBSDKProfileChangeOldKey")] Profile OldProfile { get; }

        [Export("FBSDKProfileChangeNewKey")] Profile NewProfile { get; }
    }

    // typedef void (^FBSDKProfileBlock)(FBSDKProfile * _Nullable, NSError * _Nullable);
    delegate void ProfileBlockHandler([NullAllowed] Profile arg0, [NullAllowed] NSError arg1);

    // @interface FBSDKProfile : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKProfile")]
    [DisableDefaultCtor]
    interface Profile : INSCopying, INSSecureCoding
    {
        // extern NS_SWIFT_NAME(ProfileDidChange) const NSNotificationName FBSDKProfileDidChangeNotification __attribute__((swift_name("ProfileDidChange")));
        [Notification(typeof(ProfileDidChangeEventArgs))]
        [Field("FBSDKProfileDidChangeNotification", "__Internal")]
        NSString DidChangeNotification { get; }

        // extern NS_SWIFT_NAME(ProfileChangeOldKey) NSString *const FBSDKProfileChangeOldKey __attribute__((swift_name("ProfileChangeOldKey")));
        [Field("FBSDKProfileChangeOldKey", "__Internal")]
        NSString OldKey { get; }

        // extern NS_SWIFT_NAME(ProfileChangeNewKey) NSString *const FBSDKProfileChangeNewKey __attribute__((swift_name("ProfileChangeNewKey")));
        [Field("FBSDKProfileChangeNewKey", "__Internal")]
        NSString NewKey { get; }

        // -(instancetype _Nonnull)initWithUserID:(NSString * _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate;
        [Export("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:")]
        IntPtr Constructor(string userID, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkUrl, [NullAllowed] NSDate refreshDate);

        // -(instancetype _Nonnull)initWithUserID:(NSString * _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate imageURL:(NSURL * _Nullable)imageURL email:(NSString * _Nullable)email __attribute__((objc_designated_initializer));
        [Export("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:imageURL:email:")]
        [DesignatedInitializer]
        IntPtr Constructor(string userID, [NullAllowed] string firstName, [NullAllowed] string middleName,
            [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkUrl,
            [NullAllowed] NSDate refreshDate, [NullAllowed] NSUrl imageUrl, [NullAllowed] string email);

        // @property (nonatomic, strong, class) NS_SWIFT_NAME(current) FBSDKProfile * currentProfile __attribute__((swift_name("current")));
        [Static]
        [Export("currentProfile", ArgumentSemantic.Strong)]
        Profile CurrentProfile { get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
        [Export("userID")] string UserID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable firstName;
        [NullAllowed, Export("firstName")] string FirstName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable middleName;
        [NullAllowed, Export("middleName")] string MiddleName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable lastName;
        [NullAllowed, Export("lastName")] string LastName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")] string Name { get; }

        // @property (readonly, nonatomic) NSURL * _Nullable linkURL;
        [NullAllowed, Export("linkURL")] NSUrl LinkUrl { get; }

        // @property (readonly, nonatomic) NSDate * _Nonnull refreshDate;
        [Export("refreshDate")] NSDate RefreshDate { get; }

        // @property (readonly, nonatomic) NSURL * _Nullable imageURL;
        [NullAllowed, Export("imageURL")] NSUrl ImageUrl { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable email;
        [NullAllowed, Export("email")] string Email { get; }

        // +(void)enableUpdatesOnAccessTokenChange:(BOOL)enable __attribute__((swift_name("enableUpdatesOnAccessTokenChange(_:)")));
        [Static]
        [Export("enableUpdatesOnAccessTokenChange:")]
        void EnableUpdatesOnAccessTokenChange(bool enable);

        // +(void)loadCurrentProfileWithCompletion:(FBSDKProfileBlock _Nullable)completion;
        [Static]
        [Export("loadCurrentProfileWithCompletion:")]
        void LoadCurrentProfileWithCompletion([NullAllowed] ProfileBlockHandler completion);

        // -(NSURL * _Nullable)imageURLForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size __attribute__((swift_name("imageURL(forMode:size:)")));
        [Export("imageURLForPictureMode:size:")]
        [return: NullAllowed]
        NSUrl ImageUrlForPictureMode(ProfilePictureMode mode, CGSize size);

        // -(BOOL)isEqualToProfile:(FBSDKProfile * _Nonnull)profile;
        [Export("isEqualToProfile:")]
        bool IsEqualToProfile(Profile profile);
    }

    // @interface FBSDKProfilePictureView : UIView
    [BaseType(typeof(UIView), Name = "FBSDKProfilePictureView")]
    interface ProfilePictureView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame profile:(FBSDKProfile * _Nullable)profile;
        [Export("initWithFrame:profile:")]
        IntPtr Constructor(CGRect frame, [NullAllowed] Profile profile);

        // -(instancetype _Nonnull)initWithProfile:(FBSDKProfile * _Nullable)profile;
        [Export("initWithProfile:")]
        IntPtr Constructor([NullAllowed] Profile profile);

        // @property (assign, nonatomic) FBSDKProfilePictureMode pictureMode;
        [Export("pictureMode", ArgumentSemantic.Assign)]
        ProfilePictureMode PictureMode { get; set; }

        // @property (copy, nonatomic) NSString * _Nonnull profileID;
        [Export("profileID")] string ProfileID { get; set; }

        // -(void)setNeedsImageUpdate;
        [Export("setNeedsImageUpdate")]
        void SetNeedsImageUpdate();
    }

    // @interface FBSDKSettings : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKSettings")]
    [DisableDefaultCtor]
    interface Settings
    {
        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull sdkVersion;
        [Static] [Export("sdkVersion")] string SdkVersion { get; }

        // @property (readonly, copy, nonatomic, class) NSString * _Nonnull defaultGraphAPIVersion;
        [Static]
        [Export("defaultGraphAPIVersion")]
        string DefaultGraphAPIVersion { get; }

        // @property (assign, nonatomic, class) CGFloat JPEGCompressionQuality __attribute__((swift_name("jpegCompressionQuality")));
        [Static]
        [Export("JPEGCompressionQuality")]
        nfloat JPEGCompressionQuality { get; set; }

        // @property (getter = isAutoLogAppEventsEnabled, assign, nonatomic, class) BOOL autoLogAppEventsEnabled;
        [Static]
        [Export("autoLogAppEventsEnabled")]
        bool AutoLogAppEventsEnabled { [Bind("isAutoLogAppEventsEnabled")] get; set; }

        // @property (getter = isCodelessDebugLogEnabled, assign, nonatomic, class) BOOL codelessDebugLogEnabled;
        [Static]
        [Export("codelessDebugLogEnabled")]
        bool CodelessDebugLogEnabled { [Bind("isCodelessDebugLogEnabled")] get; set; }

        // @property (getter = isAdvertiserIDCollectionEnabled, assign, nonatomic, class) BOOL advertiserIDCollectionEnabled;
        [Static]
        [Export("advertiserIDCollectionEnabled")]
        bool AdvertiserIDCollectionEnabled
        {
            [Bind("isAdvertiserIDCollectionEnabled")]
            get;
            set;
        }

        // @property (getter = isSKAdNetworkReportEnabled, assign, nonatomic, class) BOOL SKAdNetworkReportEnabled;
        [Static]
        [Export("SKAdNetworkReportEnabled")]
        bool SKAdNetworkReportEnabled { [Bind("isSKAdNetworkReportEnabled")] get; set; }

        // @property (getter = shouldLimitEventAndDataUsage, assign, nonatomic, class) BOOL limitEventAndDataUsage;
        [Static]
        [Export("limitEventAndDataUsage")]
        bool LimitEventAndDataUsage { [Bind("shouldLimitEventAndDataUsage")] get; set; }

        // @property (getter = isGraphErrorRecoveryEnabled, assign, nonatomic, class) BOOL graphErrorRecoveryEnabled;
        [Static]
        [Export("graphErrorRecoveryEnabled")]
        bool GraphErrorRecoveryEnabled { [Bind("isGraphErrorRecoveryEnabled")] get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable appID;
        [Static]
        [NullAllowed, Export("appID")]
        string AppID { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable appURLSchemeSuffix;
        [Static]
        [NullAllowed, Export("appURLSchemeSuffix")]
        string AppUrlSchemeSuffix { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable clientToken;
        [Static]
        [NullAllowed, Export("clientToken")]
        string ClientToken { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable displayName;
        [Static]
        [NullAllowed, Export("displayName")]
        string DisplayName { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nullable facebookDomainPart;
        [Static]
        [NullAllowed, Export("facebookDomainPart")]
        string FacebookDomainPart { get; set; }

        // @property (copy, nonatomic, class) NS_REFINED_FOR_SWIFT NSSet<NSString *> * loggingBehaviors __attribute__((swift_private));
        [Static]
        [Export("loggingBehaviors", ArgumentSemantic.Copy)]
        NSSet<NSString> LoggingBehaviors { get; set; }

        // @property (copy, nonatomic, class, null_resettable) NSString * _Null_unspecified graphAPIVersion;
        [Static]
        [NullAllowed, Export("graphAPIVersion")]
        string GraphAPIVersion { get; set; }

        // +(BOOL)isAdvertiserTrackingEnabled;
        [Static]
        [Export("isAdvertiserTrackingEnabled")]
        bool IsAdvertiserTrackingEnabled { get; }

        // +(BOOL)setAdvertiserTrackingEnabled:(BOOL)advertiserTrackingEnabled;
        [Static]
        [Export("setAdvertiserTrackingEnabled:")]
        bool SetAdvertiserTrackingEnabled(bool advertiserTrackingEnabled);

        // +(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options;
        [Static]
        [Export("setDataProcessingOptions:")]
        void SetDataProcessingOptions([NullAllowed] string[] options);

        // +(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options country:(int)country state:(int)state;
        [Static]
        [Export("setDataProcessingOptions:country:state:")]
        void SetDataProcessingOptions([NullAllowed] string[] options, int country, int state);

        // +(void)enableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
        [Static]
        [Export("enableLoggingBehavior:")]
        void EnableLoggingBehavior(string loggingBehavior);

        // +(void)disableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
        [Static]
        [Export("disableLoggingBehavior:")]
        void DisableLoggingBehavior(string loggingBehavior);
    }

    // typedef void (^FBSDKAccessTokensBlock)(NSArray<FBSDKAccessToken *> * _Nonnull, NSError * _Nullable);
    delegate void AccessTokensBlockHandler(AccessToken[] arg0, [NullAllowed] NSError arg1);

    // @interface FBSDKTestUsersManager : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKTestUsersManager")]
    [DisableDefaultCtor]
    interface TestUsersManager
    {
        // +(instancetype _Nonnull)sharedInstanceForAppID:(NSString * _Nonnull)appID appSecret:(NSString * _Nonnull)appSecret __attribute__((swift_name("shared(forAppID:appSecret:)")));
        [Static]
        [Export("sharedInstanceForAppID:appSecret:")]
        TestUsersManager SharedInstanceForAppID(string appID, string appSecret);

        // -(void)requestTestAccountTokensWithArraysOfPermissions:(NSArray<NSSet<NSString *> *> * _Nonnull)arraysOfPermissions createIfNotFound:(BOOL)createIfNotFound completionHandler:(FBSDKAccessTokensBlock _Nullable)handler __attribute__((swift_name("requestTestAccountTokens(withPermissions:createIfNotFound:completionHandler:)")));
        [Export("requestTestAccountTokensWithArraysOfPermissions:createIfNotFound:completionHandler:")]
        void RequestTestAccountTokensWithArraysOfPermissions(NSSet<NSString>[] arraysOfPermissions, bool createIfNotFound, [NullAllowed] AccessTokensBlockHandler handler);

        // -(void)addTestAccountWithPermissions:(NSSet<NSString *> * _Nonnull)permissions completionHandler:(FBSDKAccessTokensBlock _Nullable)handler;
        [Export("addTestAccountWithPermissions:completionHandler:")]
        void AddTestAccountWithPermissions(NSSet<NSString> permissions, [NullAllowed] AccessTokensBlockHandler handler);

        // -(void)removeTestAccount:(NSString * _Nonnull)userId completionHandler:(FBSDKErrorBlock _Nullable)handler;
        [Export("removeTestAccount:completionHandler:")]
        void RemoveTestAccount(string userId, [NullAllowed] ErrorBlockHandler handler);

        // -(void)makeFriendsWithFirst:(FBSDKAccessToken * _Nonnull)first second:(FBSDKAccessToken * _Nonnull)second callback:(FBSDKErrorBlock _Nullable)callback __attribute__((swift_name("makeFriends(first:second:callback:)")));
        [Export("makeFriendsWithFirst:second:callback:")]
        void MakeFriendsWithFirst(AccessToken first, AccessToken second, [NullAllowed] ErrorBlockHandler callback);
    }

    // @interface FBSDKURL : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKURL")]
    [DisableDefaultCtor]
    interface Url
    {
        // +(instancetype _Nonnull)URLWithURL:(NSURL * _Nonnull)url __attribute__((swift_name("init(url:)")));
        [Static]
        [Export("URLWithURL:")]
        Url Create(NSUrl url);

        // +(instancetype _Nonnull)URLWithInboundURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication __attribute__((swift_name("init(inboundURL:sourceApplication:)")));
        [Static]
        [Export("URLWithInboundURL:sourceApplication:")]
        Url Create(NSUrl url, string sourceApplication);

        // @property (readonly, nonatomic, strong) NSURL * _Nonnull targetURL;
        [Export("targetURL", ArgumentSemantic.Strong)]
        NSUrl TargetUrl { get; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull targetQueryParameters;
        [Export("targetQueryParameters", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> TargetQueryParameters { get; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nullable appLinkData;
        [NullAllowed, Export("appLinkData", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> AppLinkData { get; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nullable appLinkExtras;
        [NullAllowed, Export("appLinkExtras", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> AppLinkExtras { get; }

        // @property (readonly, nonatomic, strong) FBSDKAppLink * _Nullable appLinkReferer;
        [NullAllowed, Export("appLinkReferer", ArgumentSemantic.Strong)]
        AppLink AppLinkReferer { get; }

        // @property (readonly, nonatomic, strong) NSURL * _Nonnull inputURL;
        [Export("inputURL", ArgumentSemantic.Strong)]
        NSUrl InputUrl { get; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull inputQueryParameters;
        [Export("inputQueryParameters", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> InputQueryParameters { get; }

        // @property (readonly, getter = isAutoAppLink, nonatomic) BOOL isAutoAppLink;
        [Export("isAutoAppLink")] bool IsAutoAppLink { [Bind("isAutoAppLink")] get; }
    }

    // @interface FBSDKUtility : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKUtility")]
    [DisableDefaultCtor]
    interface Utility
    {
        // +(NSDictionary<NSString *,NSString *> * _Nonnull)dictionaryWithQueryString:(NSString * _Nonnull)queryString __attribute__((swift_name("dictionary(withQuery:)")));
        [Static]
        [Export("dictionaryWithQueryString:")]
        NSDictionary<NSString, NSString> DictionaryWithQueryString(string queryString);

        // +(NSString * _Nonnull)queryStringWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("query(from:)"))) __attribute__((swift_error("nonnull_error")));
        [Static]
        [Export("queryStringWithDictionary:error:")]
        string CreateQueryString(NSDictionary<NSString, NSObject> dictionary, [NullAllowed] out NSError errorRef);

        // +(NSString * _Nonnull)URLDecode:(NSString * _Nonnull)value __attribute__((swift_name("decode(urlString:)")));
        [Static]
        [Export("URLDecode:")]
        string UrlDecode(string value);

        // +(NSString * _Nonnull)URLEncode:(NSString * _Nonnull)value __attribute__((swift_name("encode(urlString:)")));
        [Static]
        [Export("URLEncode:")]
        string UrlEncode(string value);

        // +(dispatch_source_t)startGCDTimerWithInterval:(double)interval block:(dispatch_block_t)block;
        [Internal]
        [Static]
        [Export("startGCDTimerWithInterval:block:")]
        IntPtr _StartGcdTimer(double interval, Action block);

        [Static]
        [Wrap("new DispatchSource.Timer (_StartGcdTimer (interval, block))")]
        DispatchSource StartGcdTimer(double interval, Action block);

        // +(void)stopGCDTimer:(dispatch_source_t)timer;
        [Internal]
        [Static]
        [Export("stopGCDTimer:")]
        void _StopGcdTimer(IntPtr timer);

        [Static]
        [Wrap("_StopGcdTimer (timer.Handle)")]
        void StopGcdTimer(DispatchSource timer);

        // +(NSString * _Nullable)SHA256Hash:(NSObject * _Nullable)input __attribute__((swift_name("sha256Hash(_:)")));
        [Static]
        [Export("SHA256Hash:")]
        [return: NullAllowed]
        string SHA256Hash([NullAllowed] NSObject input);
    }

    // @interface FBSDKWebViewAppLinkResolver : NSObject <FBSDKAppLinkResolving>
    [BaseType(typeof(NSObject), Name = "FBSDKWebViewAppLinkResolver")]
    interface WebViewAppLinkResolver : AppLinkResolving
    {
        // @property (readonly, nonatomic, strong, class) NS_SWIFT_NAME(shared) FBSDKWebViewAppLinkResolver * sharedInstance __attribute__((swift_name("shared")));
        [Static]
        [Export("sharedInstance", ArgumentSemantic.Strong)]
        WebViewAppLinkResolver SharedInstance { get; }
    }

    // @interface FBSDKBasicUtility : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKBasicUtility")]
    interface BasicUtility
    {
        // +(BOOL)dictionary:(NSMutableDictionary<id,id> * _Nonnull)dictionary setJSONStringForObject:(id _Nonnull)object forKey:(id<NSCopying> _Nonnull)key error:(NSError * _Nullable * _Nullable)errorRef;
        [Static]
        [Export("dictionary:setJSONStringForObject:forKey:error:")]
        bool Dictionary(NSMutableDictionary<NSObject, NSObject> dictionary, NSObject @object, NSCopying key,
            [NullAllowed] out NSError errorRef);

        // +(id _Nullable)objectForJSONString:(NSString * _Nonnull)string error:(NSError * _Nullable * _Nullable)errorRef;
        [Static]
        [Export("objectForJSONString:error:")]
        [return: NullAllowed]
        NSObject ObjectForJSONString(string @string, [NullAllowed] out NSError errorRef);

        // +(id _Nonnull)convertRequestValue:(id _Nonnull)value;
        [Static]
        [Export("convertRequestValue:")]
        NSObject ConvertRequestValue(NSObject value);

        // +(NSString * _Nonnull)URLEncode:(NSString * _Nonnull)value;
        [Static]
        [Export("URLEncode:")]
        string UrlEncode(string value);

        // +(NSDictionary<NSString *,NSString *> * _Nonnull)dictionaryWithQueryString:(NSString * _Nonnull)queryString;
        [Static]
        [Export("dictionaryWithQueryString:")]
        NSDictionary<NSString, NSString> DictionaryWithQueryString(string queryString);

        // +(NSString * _Nonnull)URLDecode:(NSString * _Nonnull)value;
        [Static]
        [Export("URLDecode:")]
        string UrlDecode(string value);

        // +(NSData * _Nullable)gzip:(NSData * _Nonnull)data;
        [Static]
        [Export("gzip:")]
        [return: NullAllowed]
        NSData Gzip(NSData data);

        // +(NSString * _Nonnull)anonymousID;
        [Static]
        [Export("anonymousID")]
        string AnonymousID { get; }

        // +(NSString * _Nonnull)persistenceFilePath:(NSString * _Nonnull)filename;
        [Static]
        [Export("persistenceFilePath:")]
        string PersistenceFilePath(string filename);

        // +(NSString * _Nullable)SHA256Hash:(NSObject * _Nullable)input;
        [Static]
        [Export("SHA256Hash:")]
        [return: NullAllowed]
        string SHA256Hash([NullAllowed] NSObject input);
    }

    // @protocol FBSDKCrashObserving <NSObject>
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
    [Model]
    [BaseType(typeof(NSObject), Name = "FBSDKCrashObserving")]
    interface CrashObserving
    {
        // @required @property (copy, nonatomic) NSArray<NSString *> * _Nonnull prefixes;
        [Abstract]
        [Export("prefixes", ArgumentSemantic.Copy)]
        string[] Prefixes { get; set; }

        // @required @property (copy, nonatomic) NSArray<NSString *> * _Nullable frameworks;
        [Abstract]
        [NullAllowed, Export("frameworks", ArgumentSemantic.Copy)]
        string[] Frameworks { get; set; }

        // @optional -(void)didReceiveCrashLogs:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)crashLogs;
        [Export("didReceiveCrashLogs:")]
        void DidReceiveCrashLogs(NSArray<NSDictionary<NSString, NSObject>> crashLogs);
    }

    // @interface FBSDKCrashHandler : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKCrashHandler")]
    interface CrashHandler
    {
        // +(void)disable;
        [Static]
        [Export("disable")]
        void Disable();

        // +(void)addObserver:(id<FBSDKCrashObserving> _Nonnull)observer;
        [Static]
        [Export("addObserver:")]
        void AddObserver(CrashObserving observer);

        // +(void)removeObserver:(id<FBSDKCrashObserving> _Nonnull)observer;
        [Static]
        [Export("removeObserver:")]
        void RemoveObserver(CrashObserving observer);

        // +(void)clearCrashReportFiles;
        [Static]
        [Export("clearCrashReportFiles")]
        void ClearCrashReportFiles();

        // +(NSString * _Nonnull)getFBSDKVersion;
        [Static]
        [Export("getFBSDKVersion")]
        string Version { get; }
    }

    // @interface FBSDKJSONField : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKJSONField")]
    [DisableDefaultCtor]
    interface JSONField : INativeObject
    {
        // -(void)matchArray:(void (^ _Nullable)(NSArray<FBSDKJSONField *> * _Nonnull))arrayMatcher dictionary:(void (^ _Nullable)(NSDictionary<NSString *,FBSDKJSONField *> * _Nonnull))dictionaryMatcher string:(void (^ _Nullable)(NSString * _Nonnull))stringMatcher number:(void (^ _Nullable)(NSNumber * _Nonnull))numberMatcher null:(void (^ _Nullable)(void))nullMatcher;
        [Export("matchArray:dictionary:string:number:null:")]
        void MatchArray([NullAllowed] Action<NSArray<JSONField>> arrayMatcher, [NullAllowed] Action<NSDictionary<NSString, JSONField>> dictionaryMatcher, [NullAllowed] Action<NSString> stringMatcher, [NullAllowed] Action<NSNumber> numberMatcher, [NullAllowed] Action nullMatcher);

        // @property (readonly, nonatomic, strong) id _Nonnull rawObject;
        [Export("rawObject", ArgumentSemantic.Strong)]
        NSObject RawObject { get; }

        // -(NSArray<FBSDKJSONField *> * _Nullable)arrayOrNil;
        [NullAllowed, Export("arrayOrNil")]
        JSONField[] GetArrayOrNil();

        // -(NSDictionary<NSString *,FBSDKJSONField *> * _Nullable)dictionaryOrNil;
        [NullAllowed, Export("dictionaryOrNil")]
        NSDictionary<NSString, JSONField> GetDictionaryOrNil();

        // -(NSString * _Nullable)stringOrNil;
        [NullAllowed, Export("stringOrNil")]
        string GetStringOrNil();

        // -(NSNumber * _Nullable)numberOrNil;
        [NullAllowed, Export("numberOrNil")]
        NSNumber GetNumberOrNil();

        // -(NSNull * _Nullable)nullOrNil;
        [NullAllowed, Export("nullOrNil")]
        NSNull GetNullOrNil();
    }

    // @interface FBSDKJSONValue : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKJSONValue")]
    [DisableDefaultCtor]
    interface JSONValue
    {
        // -(instancetype _Nullable)initWithPotentialJSONObject:(id _Nonnull)obj;
        [Export("initWithPotentialJSONObject:")]
        IntPtr Constructor(NSObject obj);

        // @property (readonly, nonatomic, strong) id _Nonnull rawObject;
        [Export("rawObject", ArgumentSemantic.Strong)]
        NSObject RawObject { get; }

        // -(void)matchArray:(void (^ _Nullable)(NSArray<FBSDKJSONField *> * _Nonnull))arrayMatcher dictionary:(void (^ _Nullable)(NSDictionary<NSString *,FBSDKJSONField *> * _Nonnull))dictMatcher;
        [Export("matchArray:dictionary:")]
        void MatchArray([NullAllowed] Action<NSArray<JSONField>> arrayMatcher, [NullAllowed] Action<NSDictionary<NSString, JSONField>> dictMatcher);

        // -(NSDictionary<NSString *,FBSDKJSONField *> * _Nullable)matchDictionaryOrNil;
        [NullAllowed, Export("matchDictionaryOrNil")]
        NSDictionary<NSString, JSONField> GetMatchDictionaryOrNil();

        // -(NSArray<FBSDKJSONField *> * _Nullable)matchArrayOrNil;
        [NullAllowed, Export("matchArrayOrNil")]
        JSONField[] GetMatchArrayOrNil();
    }

    // @interface FBSDKLibAnalyzer : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKLibAnalyzer")]
    interface LibAnalyzer
    {
        // +(NSDictionary<NSString *,NSString *> * _Nonnull)getMethodsTable:(NSArray<NSString *> * _Nonnull)prefixes frameworks:(NSArray<NSString *> * _Nullable)frameworks;
        [Static]
        [Export("getMethodsTable:frameworks:")]
        NSDictionary<NSString, NSString> GetMethodsTable(string[] prefixes, [NullAllowed] string[] frameworks);

        // +(NSArray<NSString *> * _Nullable)symbolicateCallstack:(NSArray<NSString *> * _Nonnull)callstack methodMapping:(NSDictionary<NSString *,id> * _Nonnull)methodMapping;
        [Static]
        [Export("symbolicateCallstack:methodMapping:")]
        [return: NullAllowed]
        string[] SymbolicateCallstack(string[] callstack, NSDictionary<NSString, NSObject> methodMapping);
    }

    // @interface FBSDKTypeUtility : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKTypeUtility")]
    [DisableDefaultCtor]
    interface TypeUtility
    {
        // +(NSArray * _Nullable)arrayValue:(id _Nonnull)object;
        [Static]
        [Export("arrayValue:")]
        [return: NullAllowed]
        NSObject[] ArrayValue(NSObject @object);

        // +(id _Nullable)array:(NSArray * _Nonnull)array objectAtIndex:(NSUInteger)index;
        [Static]
        [Export("array:objectAtIndex:")]
        [return: NullAllowed]
        NSObject Array(NSObject[] array, nuint index);

        // +(void)array:(NSMutableArray * _Nonnull)array addObject:(id _Nullable)object;
        [Static]
        [Export("array:addObject:")]
        void Array(NSMutableArray array, [NullAllowed] NSObject @object);

        // +(void)array:(NSMutableArray * _Nonnull)array addObject:(id _Nullable)object atIndex:(NSUInteger)index;
        [Static]
        [Export("array:addObject:atIndex:")]
        void Array(NSMutableArray array, [NullAllowed] NSObject @object, nuint index);

        // +(BOOL)boolValue:(id _Nonnull)object;
        [Static]
        [Export("boolValue:")]
        bool BoolValue(NSObject @object);

        // +(NSDictionary * _Nullable)dictionaryValue:(id _Nonnull)object;
        [Static]
        [Export("dictionaryValue:")]
        [return: NullAllowed]
        NSDictionary DictionaryValue(NSObject @object);

        // +(id _Nullable)dictionary:(NSDictionary * _Nonnull)dictionary objectForKey:(NSString * _Nonnull)key ofType:(Class _Nonnull)type;
        [Static]
        [Export("dictionary:objectForKey:ofType:")]
        [return: NullAllowed]
        NSObject Dictionary(NSDictionary dictionary, string key, Class type);

        // +(void)dictionary:(NSMutableDictionary * _Nonnull)dictionary setObject:(id _Nullable)object forKey:(id<NSCopying> _Nullable)key;
        [Static]
        [Export("dictionary:setObject:forKey:")]
        void Dictionary(NSMutableDictionary dictionary, [NullAllowed] NSObject @object, [NullAllowed] NSCopying key);

        // +(NSInteger)integerValue:(id _Nonnull)object;
        [Static]
        [Export("integerValue:")]
        nint IntegerValue(NSObject @object);

        // +(NSNumber * _Nonnull)numberValue:(id _Nonnull)object;
        [Static]
        [Export("numberValue:")]
        NSNumber NumberValue(NSObject @object);

        // +(id _Nullable)objectValue:(id _Nonnull)object;
        [Static]
        [Export("objectValue:")]
        [return: NullAllowed]
        NSObject ObjectValue(NSObject @object);

        // +(NSString * _Nullable)stringValue:(id _Nonnull)object;
        [Static]
        [Export("stringValue:")]
        [return: NullAllowed]
        string StringValue(NSObject @object);

        // +(NSTimeInterval)timeIntervalValue:(id _Nonnull)object;
        [Static]
        [Export("timeIntervalValue:")]
        double TimeIntervalValue(NSObject @object);

        // +(NSUInteger)unsignedIntegerValue:(id _Nonnull)object;
        [Static]
        [Export("unsignedIntegerValue:")]
        nuint UnsignedIntegerValue(NSObject @object);

        // +(NSURL * _Nullable)URLValue:(id _Nonnull)object;
        [Static]
        [Export("URLValue:")]
        [return: NullAllowed]
        NSUrl UrlValue(NSObject @object);

        // +(BOOL)isValidJSONObject:(id _Nonnull)obj;
        [Static]
        [Export("isValidJSONObject:")]
        bool IsValidJSONObject(NSObject obj);

        // +(NSData * _Nullable)dataWithJSONObject:(id _Nonnull)obj options:(NSJSONWritingOptions)opt error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("dataWithJSONObject:options:error:")]
        [return: NullAllowed]
        NSData DataWithJSONObject(NSObject obj, NSJsonWritingOptions opt, [NullAllowed] out NSError error);

        // +(id _Nullable)JSONObjectWithData:(NSData * _Nonnull)data options:(NSJSONReadingOptions)opt error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("JSONObjectWithData:options:error:")]
        [return: NullAllowed]
        NSObject JSONObjectWithData(NSData data, NSJsonReadingOptions opt, [NullAllowed] out NSError error);
    }

    // typedef void (^FBSDKURLSessionTaskBlock)(NSData *, NSURLResponse *, NSError *);
    delegate void UrlSessionTaskBlockHandler(NSData arg0, NSUrlResponse arg1, NSError arg2);

    // @interface FBSDKURLSessionTask : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKURLSessionTask")]
    interface UrlSessionTask
    {
        // @property (nonatomic, strong) NSURLSessionTask * task;
        [Export("task", ArgumentSemantic.Strong)]
        NSUrlSessionTask Task { get; set; }

        // @property (readonly, atomic) NSURLSessionTaskState state;
        [Export("state")] NSUrlSessionTaskState State { get; }

        // @property (readonly, nonatomic, strong) NSDate * requestStartDate;
        [Export("requestStartDate", ArgumentSemantic.Strong)]
        NSDate RequestStartDate { get; }

        // @property (copy, nonatomic) FBSDKURLSessionTaskBlock handler;
        [Export("handler", ArgumentSemantic.Copy)]
        UrlSessionTaskBlockHandler Handler { get; set; }

        // @property (assign, nonatomic) uint64_t requestStartTime;
        [Export("requestStartTime")] ulong RequestStartTime { get; set; }

        // @property (assign, nonatomic) NSUInteger loggerSerialNumber;
        [Export("loggerSerialNumber")] nuint LoggerSerialNumber { get; set; }

        // -(instancetype)initWithRequest:(NSURLRequest *)request fromSession:(NSURLSession *)session completionHandler:(FBSDKURLSessionTaskBlock)handler;
        [Export("initWithRequest:fromSession:completionHandler:")]
        IntPtr Constructor(NSUrlRequest request, NSUrlSession session, UrlSessionTaskBlockHandler handler);

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @interface FBSDKURLSession : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKURLSession")]
    interface UrlSession
    {
        // @property (atomic, strong) NSURLSession * _Nullable session;
        [NullAllowed, Export("session", ArgumentSemantic.Strong)]
        NSUrlSession Session { get; set; }

        [Wrap("WeakDelegate")] [NullAllowed] NSUrlSessionDataDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<NSURLSessionDataDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (retain, nonatomic) NSOperationQueue * _Nullable delegateQueue;
        [NullAllowed, Export("delegateQueue", ArgumentSemantic.Retain)]
        NSOperationQueue DelegateQueue { get; set; }

        // -(instancetype _Nonnull)initWithDelegate:(id<NSURLSessionDataDelegate> _Nonnull)delegate delegateQueue:(NSOperationQueue * _Nonnull)delegateQueue;
        [Export("initWithDelegate:delegateQueue:")]
        IntPtr Constructor(NSUrlSessionDataDelegate @delegate, NSOperationQueue delegateQueue);

        // -(void)executeURLRequest:(NSURLRequest * _Nonnull)request completionHandler:(FBSDKURLSessionTaskBlock _Nonnull)handler;
        [Export("executeURLRequest:completionHandler:")]
        void ExecuteUrlRequest(NSUrlRequest request, UrlSessionTaskBlockHandler handler);

        // -(void)updateSessionWithBlock:(dispatch_block_t _Nonnull)block;
        [Export("updateSessionWithBlock:")]
        void UpdateSessionWithBlock(NSDispatchHandler block);

        // -(void)invalidateAndCancel;
        [Export("invalidateAndCancel")]
        void InvalidateAndCancel();

        // -(BOOL)valid;
        [Export("valid")]
        bool IsValid();
    }

    // @interface FBSDKUserDataStore : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKUserDataStore")]
    interface UserDataStore
    {
        // +(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country __attribute__((swift_name("setUser(email:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:)")));
        [Static]
        [Export("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:")]
        void SetUserEmail([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country);

        // +(NSString * _Nullable)getUserData;
        [Static]
        [NullAllowed, Export("getUserData")]
        string GetUserData();

        // +(void)clearUserData;
        [Static]
        [Export("clearUserData")]
        void ClearUserData();

        // +(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
        [Static]
        [Export("setUserData:forType:")]
        void SetUserData([NullAllowed] string data, string type);

        // +(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
        [Static]
        [Export("clearUserDataForType:")]
        void ClearUserDataForType(string type);
    }

    // @interface FBSDKAuthenticationToken : NSObject <FBSDKCopying, NSSecureCoding>
    [BaseType(typeof(NSObject), Name = "FBSDKAuthenticationToken")]
    [DisableDefaultCtor]
    interface AuthenticationToken : Copying, INSSecureCoding
    {
        // @property (copy, nonatomic, class) FBSDKAuthenticationToken * _Nullable currentAuthenticationToken;
        [Static]
        [NullAllowed, Export("currentAuthenticationToken", ArgumentSemantic.Copy)]
        AuthenticationToken CurrentAuthenticationToken { get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
        [Export("tokenString")] string TokenString { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
        [Export("nonce")] string Nonce { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull graphDomain;
        [Export("graphDomain")] string GraphDomain { get; }
    }

    // @interface FBSDKAppLinkResolverRequestBuilder : NSObject
    [BaseType(typeof(NSObject), Name = "FBSDKAppLinkResolverRequestBuilder")]
    interface AppLinkResolverRequestBuilder
    {
        // -(FBSDKGraphRequest * _Nonnull)requestForURLs:(NSArray<NSURL *> * _Nonnull)urls __attribute__((availability(ios_app_extension, unavailable)));
        [Export("requestForURLs:")]
        GraphRequest RequestForUrls(NSUrl[] urls);

        // -(NSString * _Nullable)getIdiomSpecificField __attribute__((availability(ios_app_extension, unavailable)));
        [NullAllowed, Export("getIdiomSpecificField")]
        string IdiomSpecificField { get; }
    }

    [Static]
    interface CoreKitVersionConstants
    {
        // extern double FBSDKCoreKitVersionNumber;
        [Field("FBSDKCoreKitVersionNumber", "__Internal")]
        double VersionNumber { get; }

        // extern const unsigned char [] FBSDKCoreKitVersionString;
        [Field("FBSDKCoreKitVersionString", "__Internal")]
        NSString VersionString { get; }
    }
}
