//
// ApiDefinition.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto 	(alex.soto@xamarin.com)
//		Israel Soto 	(israel.soto@xamarin.com)
//

using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;
using Accounts;
using CoreGraphics;
using System.Reflection;
using System.ComponentModel;
using CoreMedia;
using CoreFoundation;

namespace Facebook.AudienceNetwork
{

	// @interface FBAdChoicesView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBAdChoicesView")]
	interface AdChoicesView
	{

		// @property (readonly, nonatomic, weak) UILabel * label;
		[Export ("label", ArgumentSemantic.Weak)]
		UILabel Label { get; }

		// @property (getter = isBackgroundShown, assign, nonatomic) BOOL backgroundShown;
		[Export ("backgroundShown")]
		bool BackgroundShown { [Bind ("isBackgroundShown")] get; set; }

		// @property (nonatomic, assign, readonly, getter=isExpandable) BOOL expandable;
		[Export ("expandable")]
		bool Expandable { [Bind ("isExpandable")] get; set; }

		// @property (nonatomic, weak, readwrite) FBNativeAd *nativeAd;
		[Export ("nativeAd", ArgumentSemantic.Weak)]
		[NullAllowed]
		NativeAd NativeAd { get; set; }

		// @property (nonatomic, assign, readwrite) UIRectCorner corner;
		[Export ("corner", ArgumentSemantic.Assign)]
		UIRectCorner Corner { get; set; }

		// @property (nonatomic, weak, readwrite, nullable) UIViewController *rootViewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// -(instancetype)initWithNativeAd:(FBNativeAd *)nativeAd;
		[Export ("initWithNativeAd:")]
		IntPtr Constructor (NativeAd nativeAd);

		// - (nonnull instancetype)initWithNativeAd:(nonnull FBNativeAd *)nativeAd expandable:(BOOL)expandable;
		[Export ("initWithNativeAd:expandable:")]
		IntPtr Constructor (NativeAd nativeAd, bool expandable);

		// -(instancetype)initWithViewController:(UIViewController *)viewController adChoicesIcon:(FBAdImage *)adChoicesIcon adChoicesLinkURL:(NSURL *)adChoicesLinkURL attributes:(FBNativeAdViewAttributes *)attributes __attribute__((objc_designated_initializer));
		[Export ("initWithViewController:adChoicesIcon:attributes:")]
		IntPtr Constructor ([NullAllowed] UIViewController viewController, AdImage adChoicesIcon, [NullAllowed] NativeAdViewAttributes attributes);

		// -(void)updateFrameFromSuperview;
		[Export ("updateFrameFromSuperview")]
		void UpdateFrameFromSuperview ();

		// -(void)updateFrameFromSuperview:(UIRectCorner)corner;
		[Export ("updateFrameFromSuperview:")]
		void UpdateFrameFromSuperview (UIRectCorner corner);

		// - (void)updateFrameFromSuperview:(UIRectCorner)corner insets:(UIEdgeInsets)insets;
		[Export ("updateFrameFromSuperview:insets:")]
		void UpdateFrameFromSuperview (UIRectCorner corner, UIEdgeInsets insets);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBAdSettings")]
	interface AdSettings
	{
		[Field ("FBAudienceNetworkErrorDomain", "__Internal")]
		NSString AdsErrorDomain { get; }

		[Field ("FBAudienceNetworkMediaViewErrorDomain", "__Internal")]
		NSString MediaViewErrorDomain { get; }

		// @property (class, nonatomic, assign, getter=isBackgroundVideoPlaybackAllowed) BOOL backgroundVideoPlaybackAllowed;
		[Static]
		[Export ("backgroundVideoPlaybackAllowed")]
		bool IsBackgroundVideoPlaybackAllowed { [Bind ("isBackgroundVideoPlaybackAllowed")] get; set; }

		// @property (class, nonatomic, assign) FBAdTestAdType testAdType;
		[Static]
		[Export ("testAdType", ArgumentSemantic.Assign)]
		AdTestAdType TestAdType { get; set; }

		// @property (class, nonatomic, weak, nullable) id<FBAdLoggingDelegate> loggingDelegate;
		[Static]
		[NullAllowed]
		[Export ("loggingDelegate", ArgumentSemantic.Weak)]
		IAdLoggingDelegate LoggingDelegate { get; set; }

		// @property (class, nonatomic, copy, readonly) NSString *bidderToken;
		[Static]
		[Export ("bidderToken")]
		string BidderToken { get; }

		[Static]
		[Export ("isTestMode")]
		bool IsTestMode { get; }

		[Static]
		[Export ("testDeviceHash")]
		string TestDeviceHash { get; }

		[Static]
		[Export ("addTestDevice:")]
		void AddTestDevice (string deviceHash);

		[Static]
		[Export ("addTestDevices:")]
		void AddTestDevices (string [] devicesHash);

		[Static]
		[Export ("clearTestDevices")]
		void ClearTestDevices ();

		[Static]
		[Export ("clearTestDevice:")]
		void ClearTestDevice (string deviceHash);

		[Static]
		[Export ("setIsChildDirected:")]
		void SetIsChildDirected (bool isChildDirected);

		// + (void)setMediationService:(NSString *)service;
		[Static]
		[Export ("setMediationService:")]
		void SetMediationService (string service);

		// + (NSString *)urlPrefix;
		[Advice ("This method should never be used in production.")]
		[Static]
		[return: NullAllowed]
		[Export ("urlPrefix")]
		string GetUrlPrefix ();

		[Advice ("This method should never be used in production.")]
		[Static]
		[Export ("setUrlPrefix:")]
		void SetUrlPrefix ([NullAllowed] string urlPrefix);

		// +(FBAdLogLevel)getLogLevel;
		// +(void)setLogLevel:(FBAdLogLevel)level;
		[Static]
		[Export ("logLevel")]
		AdLogLevel LogLevel { [Bind ("getLogLevel")] get; set; }

		// + (FBMediaViewRenderingMethod)mediaViewRenderingMethod;
		// + (void)setMediaViewRenderingMethod:(FBMediaViewRenderingMethod)mediaViewRenderingMethod;
		[Static]
		[Export ("mediaViewRenderingMethod")]
		MediaViewRenderingMethod MediaViewRenderingMethod { get; set; }
	}

	interface IAdLoggingDelegate { }

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBAdLoggingDelegate")]
	interface AdLoggingDelegate
	{
		// @required -(void)logAtLevel:(FBAdLogLevel)level withFileName:(NSString * _Nonnull)fileName withLineNumber:(int)lineNumber withThreadId:(long)threadId withBody:(NSString * _Nonnull)body;
		[Abstract]
		[Export ("logAtLevel:withFileName:withLineNumber:withThreadId:withBody:")]
		void Log (AdLogLevel level, string fileName, int lineNumber, nint threadId, string body);
	}

	[Static]
	interface AdSizes
	{
		[Internal]
		[Field ("kFBAdSize320x50", "__Internal")]
		IntPtr _kFBAdSize320x50 { get; }

		[Internal]
		[Field ("kFBAdSizeHeight50Banner", "__Internal")]
		IntPtr _kFBAdSizeHeight50Banner { get; }

		[Internal]
		[Field ("kFBAdSizeHeight90Banner", "__Internal")]
		IntPtr _kFBAdSizeHeight90Banner { get; }

		[Internal]
		[Field ("kFBAdSizeInterstitial", "__Internal")]
		IntPtr _kFBAdSizeInterstitial { get; }

		[Internal]
		[Field ("kFBAdSizeHeight250Rectangle", "__Internal")]
		IntPtr _kFBAdSizeHeight250Rectangle { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBAdView")]
	interface AdView
	{

		[DesignatedInitializer]
		[Export ("initWithPlacementID:adSize:rootViewController:")]
		IntPtr Constructor (string placementId, AdSize adSize, [NullAllowed] UIViewController rootViewController);

		[Export ("loadAd")]
		void LoadAd ();

		// - (void)loadAdWithBidPayload:(NSString *)bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// -(void)disableAutoRefresh;
		[Export ("disableAutoRefresh")]
		void DisableAutoRefresh ();

		[Export ("placementID")]
		string PlacementId { get; }

		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAdViewDelegate Delegate { get; set; }

	}

	interface IAdViewDelegate
	{
	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "FBAdViewDelegate")]
	interface AdViewDelegate
	{

		[Export ("adViewDidClick:")]
		void AdViewDidClick (AdView adView);

		[Export ("adViewDidFinishHandlingClick:")]
		void AdViewDidFinishHandlingClick (AdView adView);

		[Export ("adViewDidLoad:")]
		void AdViewDidLoad (AdView adView);

		[Export ("adView:didFailWithError:")]
		void AdViewDidFail (AdView adView, NSError error);

		// @optional -(void)adViewWillLogImpression:(FBAdView * _Nonnull)adView;
		[Export ("adViewWillLogImpression:")]
		void AdViewWillLogImpression (AdView adView);

		[Export ("viewControllerForPresentingModalView", ArgumentSemantic.Strong)]
		UIViewController GetViewControllerForPresentingModalView ();
	}

	// @interface FBInstreamAdView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBInstreamAdView")]
	interface InstreamAdView
	{
		// @property (readonly, getter = isAdValid, nonatomic) BOOL adValid;
		[Export ("adValid")]
		bool IsAdValid { [Bind ("isAdValid")] get; }

		// @property (nonatomic, weak) id<FBInstreamAdViewDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInstreamAdViewDelegate Delegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull placementID;
		[NullAllowed]
		[Export ("placementID")]
		string PlacementId { get; }

		[Obsolete ("Use PlacementId property instead. This will be removed in future versions.")]
		[Wrap ("PlacementId")]
		string PlacementID { get; }

		// -(instancetype _Nullable)initWithPlacementID:(NSString * _Nonnull)placementID __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		// -(void)loadAd;
		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// -(BOOL)showAdFromRootViewController:(UIViewController * _Nullable)rootViewController;
		[Export ("showAdFromRootViewController:")]
		bool ShowAd ([NullAllowed] UIViewController rootViewController);
	}

	interface IInstreamAdViewDelegate { }

	// @protocol FBInstreamAdViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject), Name = "FBInstreamAdViewDelegate")]
	interface InstreamAdViewDelegate
	{
		// @required -(void)adViewDidLoad:(FBInstreamAdView * _Nonnull)adView;
		[Abstract]
		[Export ("adViewDidLoad:")]
		void AdViewDidLoad ([NullAllowed] InstreamAdView adView);

		// @required -(void)adViewDidEnd:(FBInstreamAdView * _Nonnull)adView;
		[Abstract]
		[Export ("adViewDidEnd:")]
		void AdViewDidEnd ([NullAllowed] InstreamAdView adView);

		// @required -(void)adView:(FBInstreamAdView * _Nonnull)adView didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("adView:didFailWithError:")]
		void AdViewDidFail ([NullAllowed] InstreamAdView adView, [NullAllowed] NSError error);

		// @optional -(void)adViewDidClick:(FBInstreamAdView * _Nonnull)adView;
		[Export ("adViewDidClick:")]
		void AdViewDidClick ([NullAllowed] InstreamAdView adView);

		// @optional -(void)adViewWillLogImpression:(FBInstreamAdView * _Nonnull)adView;
		[Export ("adViewWillLogImpression:")]
		void AdViewWillLogImpression ([NullAllowed] InstreamAdView adView);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBInterstitialAd")]
	interface InterstitialAd
	{
		
		[Export ("placementID")]
		string PlacementId { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInterstitialAdDelegate Delegate { get; set; }

		[Export ("initWithPlacementID:")]
		[DesignatedInitializer]
		IntPtr Constructor (string placementId);

		[Export ("isAdValid")]
		bool IsAdValid { get; }

		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[PostGet ("IsAdValid")]
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		[Export ("showAdFromRootViewController:")]
		bool ShowAd ([NullAllowed] UIViewController rootViewController);

		[Obsolete ("Use ShowAd method instead. This will be removed in future versions.")]
		[Wrap ("ShowAd (rootViewController)")]
		bool ShowAdFromRootViewController (UIViewController rootViewController);
	}

	interface IInterstitialAdDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "FBInterstitialAdDelegate")]
	interface InterstitialAdDelegate
	{

		[Export ("interstitialAdDidClick:")]
		void InterstitialAdDidClick (InterstitialAd interstitialAd);

		[Export ("interstitialAdDidClose:")]
		void InterstitialAdDidClose (InterstitialAd interstitialAd);

		[Export ("interstitialAdWillClose:")]
		void InterstitialAdWillClose (InterstitialAd interstitialAd);

		[Export ("interstitialAdDidLoad:")]
		void InterstitialAdDidLoad (InterstitialAd interstitialAd);

		[Export ("interstitialAd:didFailWithError:")]
		void IntersitialDidFail (InterstitialAd interstitialAd, NSError error);

		// @optional -(void)interstitialAdWillLogImpression:(FBInterstitialAd * _Nonnull)interstitialAd;
		[Export ("interstitialAdWillLogImpression:")]
		void InterstitialAdWillLogImpression (InterstitialAd interstitialAd);
	}

	// @interface FBMediaView : UIView
	[BaseType (typeof (UIView), Name = "FBMediaView")]
	interface MediaView
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, weak) id<FBMediaViewDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IMediaViewDelegate Delegate { get; set; }

		// -(instancetype)initWithNativeAd:(FBNativeAd *)nativeAd;
		[Export ("initWithNativeAd:")]
		IntPtr Constructor (NativeAd nativeAd);

		// @property (nonatomic, strong) FBNativeAd * nativeAd;
		[Export ("nativeAd", ArgumentSemantic.Strong)]
		NativeAd NativeAd { get; set; }

		// @property (nonatomic, strong, nonnull) FBMediaViewVideoRenderer *videoRenderer;
		[Export ("videoRenderer", ArgumentSemantic.Strong)]
		MediaViewVideoRenderer VideoRenderer { get; set; }

		// @property (readonly, assign, nonatomic) float volume;
		[Obsolete]
		[Export ("volume")]
		float Volume { get; }

		// @property (nonatomic, assign, getter=isAutoplayEnabled) BOOL autoplayEnabled;
		[Export ("autoplayEnabled")]
		bool AutoplayEnabled { [Bind ("isAutoplayEnabled")] get; set; }

		// @property (readonly, assign, nonatomic) CGFloat aspectRatio;
		[Export ("aspectRatio")]
		nfloat AspectRatio { get; }

		// -(void)applyNaturalWidth;
		[Export ("applyNaturalWidth")]
		void ApplyNaturalWidth ();

		// -(void)applyNaturalHeight;
		[Export ("applyNaturalHeight")]
		void ApplyNaturalHeight ();
	}

	interface IMediaViewDelegate
	{

	}

	// @protocol FBMediaViewDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBMediaViewDelegate")]
	interface MediaViewDelegate
	{
		// @optional -(void)mediaViewDidLoad:(FBMediaView *)mediaView;
		[Export ("mediaViewDidLoad:")]
		void MediaViewDidLoad (MediaView mediaView);

		// @optional -(void)mediaViewWillEnterFullscreen:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewWillEnterFullscreen:")]
		void MediaViewWillEnterFullscreen (MediaView mediaView);

		// @optional -(void)mediaViewDidExitFullscreen:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewDidExitFullscreen:")]
		void MediaViewDidExitFullscreen (MediaView mediaView);

		// @optional -(void)mediaView:(FBMediaView * _Nonnull)mediaView videoVolumeDidChange:(float)volume;
		[Export ("mediaView:videoVolumeDidChange:")]
		void MediaViewVideoVolumeDidChange (MediaView mediaView, float volume);

		// @optional -(void)mediaViewVideoDidPause:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewVideoDidPause:")]
		void MediaViewVideoDidPause (MediaView mediaView);

		// @optional -(void)mediaViewVideoDidPlay:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewVideoDidPlay:")]
		void MediaViewVideoDidPlay (MediaView mediaView);

		// @optional -(void)mediaViewVideoDidComplete:(MediaView * _Nonnull)mediaView;
		[Export ("mediaViewVideoDidComplete:")]
		void MediaViewVideoDidComplete (MediaView mediaView);
	}

	// @interface FBMediaViewVideoRenderer : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBMediaViewVideoRenderer")]
	interface MediaViewVideoRenderer
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, assign, readonly) CGFloat aspectRatio;
		[Export ("aspectRatio", ArgumentSemantic.Assign)]
		nfloat AspectRatio { get; }

		// @property (nonatomic, assign, readonly) CMTime currentTime;
		[Export ("currentTime", ArgumentSemantic.Assign)]
		CMTime CurrentTime { get; }

		// @property (nonatomic, assign, readonly) CMTime duration;
		[Export ("duration", ArgumentSemantic.Assign)]
		CMTime Duration { get; }

		// @property (nonatomic, assign, readonly, getter=isPlaying) BOOL playing;
		[Export ("isPlaying", ArgumentSemantic.Assign)]
		bool IsPlaying { get; }

		// @property (nonatomic, assign) float volume;
		[Export ("volume", ArgumentSemantic.Assign)]
		float Volume { get; set; }

		// - (void)playVideo;
		[Export ("playVideo")]
		void PlayVideo ();

		// - (void)pauseVideo;
		[Export ("pauseVideo")]
		void PauseVideo ();

		// - (void)engageVideoSeek;
		[Export ("engageVideoSeek")]
		void EngageVideoSeek ();

		// - (void)disengageVideoSeek;
		[Export ("disengageVideoSeek")]
		void DisengageVideoSeek ();

		// - (void)seekVideoToTime:(CMTime)time;
		[Export ("seekVideoToTime:")]
		void SeekVideoToTime (CMTime time);

		// - (nullable id)addPeriodicTimeObserverForInterval:(CMTime)interval queue:(dispatch_queue_t) queue usingBlock:(void (^)(CMTime time))block;
		[return: NullAllowed]
		[Export ("addPeriodicTimeObserverForInterval:queue:usingBlock:")]
		NSObject AddPeriodicTimeObserver (CMTime interval, DispatchQueue queue, Action<CMTime> block);

		// - (void)removeTimeObserver:(id)observer;
		[Export ("removeTimeObserver:")]
		void RemoveTimeObserver (NSObject observer);

		// - (void)videoDidChangeVolume;
		[Export ("videoDidChangeVolume")]
		void VideoDidChangeVolume ();

		// - (void)videoDidLoad;
		[Export ("videoDidLoad")]
		void VideoDidLoad ();

		// - (void)videoDidPause;
		[Export ("videoDidPause")]
		void VideoDidPause ();

		// - (void)videoDidPlay;
		[Export ("videoDidPlay")]
		void VideoDidPlay ();

		// - (void)videoDidEngageSeek;
		[Export ("videoDidEngageSeek")]
		void VideoDidEngageSeek ();

		// - (void)videoDidSeek;
		[Export ("videoDidSeek")]
		void VideoDidSeek ();

		// - (void)videoDidDisengageSeek;
		[Export ("videoDidDisengageSeek")]
		void VideoDidDisengageSeek ();

		// - (void)videoDidEnd;
		[Export ("videoDidEnd")]
		void VideoDidEnd ();

		// - (void)videoDidFailWithError:(NSError *)error;
		[Export ("videoDidFailWithError:")]
		void VideoDidFail (NSError error);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNativeAd")]
	interface NativeAd
	{

		[Export ("placementID")]
		string PlacementId { get; }

		[Obsolete]
		[Export ("starRating", ArgumentSemantic.Assign)]
		AdStarRating StarRating { get; }

		[Export ("title")]
		string Title { get; }

		[Export ("subtitle")]
		string Subtitle { get; }

		[Export ("socialContext")]
		string SocialContext { get; }

		[Export ("callToAction")]
		string CallToAction { get; }

		[Export ("icon", ArgumentSemantic.Retain)]
		AdImage Icon { get; }

		[Export ("coverImage", ArgumentSemantic.Retain)]
		AdImage CoverImage { get; }

		// @property (nonatomic, copy, readonly, nullable) NSString *rawBody;
		[NullAllowed]
		[Export ("rawBody")]
		string RawBody { get; }

		[Export ("body")]
		string Body { get; }

		// @property (nonatomic, strong, readonly, nullable) FBAdImage *adChoicesIcon;
		[Export ("adChoicesIcon", ArgumentSemantic.Strong)]
		AdImage AdChoicesIcon { get; }

		// @property (nonatomic, copy, readonly, nullable) NSURL *adChoicesLinkURL;
		[Export ("adChoicesLinkURL", ArgumentSemantic.Copy)]
		NSUrl AdChoicesLinkUrl { get; }

		// @property (nonatomic, copy, readonly, nullable) NSString *adChoicesText;
		[Export ("adChoicesText", ArgumentSemantic.Copy)]
		string AdChoicesText { get; }

		[Export ("mediaCachePolicy", ArgumentSemantic.Assign)]
		NativeAdsCachePolicy MediaCachePolicy { get; set; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		[DesignatedInitializer]
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		[Export ("registerViewForInteraction:withViewController:")]
		void RegisterView (UIView view, [NullAllowed] UIViewController viewController);

		[Export ("registerViewForInteraction:withViewController:withClickableViews:")]
		void RegisterView (UIView view, [NullAllowed] UIViewController viewController, UIView [] clickableViews);

		[Export ("unregisterView")]
		void UnregisterView ();

		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[PostGet ("IsAdValid")]
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		[Export ("isAdValid")]
		bool IsAdValid { get; }

		[Export ("getAdNetwork", ArgumentSemantic.Copy)]
		[NullAllowed]
		string AdNetwork { get; }
	}

	interface INativeAdDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "FBNativeAdDelegate")]
	interface NativeAdDelegate
	{
		[Export ("nativeAdDidLoad:")]
		void NativeAdDidLoad (NativeAd nativeAd);

		[Export ("nativeAd:didFailWithError:")]
		void NativeAdDidFail (NativeAd nativeAd, NSError error);

		[Export ("nativeAdDidClick:")]
		void NativeAdDidClick (NativeAd nativeAd);

		[Export ("nativeAdDidFinishHandlingClick:")]
		void NativeAdDidFinishHandlingClick (NativeAd nativeAd);

		[Export("nativeAdWillLogImpression:")]
		void NativeAdWillLogImpression(NativeAd nativeAd);
	}

	delegate void AdImageCompletionHandler ([NullAllowed] UIImage imageLoaded);

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBAdImage")]
	interface AdImage
	{

		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		[Export ("width", ArgumentSemantic.Assign)]
		nint Width { get; }

		[Export ("height", ArgumentSemantic.Assign)]
		nint Height { get; }

		[Export ("initWithURL:width:height:")]
		IntPtr Constructor (NSUrl url, nint width, nint height);

		// -(void)loadImageAsyncWithBlock:(void (^)(UIImage *))block;
		[Export ("loadImageAsyncWithBlock:")]
		void LoadImageAsync (AdImageCompletionHandler completionHandler);
	}

	// @interface FBAdStarRatingView : UIView
	[Obsolete]
	[BaseType (typeof (UIView), Name = "FBAdStarRatingView")]
	interface AdStarRatingView
	{

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic) struct FBAdStarRating rating;
		[Export ("rating", ArgumentSemantic.Assign)]
		AdStarRating Rating { get; set; }

		// @property (nonatomic, strong) UIColor * primaryColor;
		[Export ("primaryColor", ArgumentSemantic.Strong)]
		UIColor PrimaryColor { get; set; }

		// @property (nonatomic, strong) UIColor * secondaryColor;
		[Export ("secondaryColor", ArgumentSemantic.Strong)]
		UIColor SecondaryColor { get; set; }

		// -(instancetype)initWithFrame:(CGRect)frame withStarRating:(struct FBAdStarRating)starRating __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:withStarRating:")]
		IntPtr Constructor (CGRect frame, AdStarRating starRating);
	}

	delegate UIView NativeAdScrollViewViewProviderHandler (NativeAd nativeAd, nuint position);

	// @interface FBNativeAdScrollView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBNativeAdScrollView")]
	interface NativeAdScrollView
	{
		// @property (readonly, assign, nonatomic) NSUInteger maximumNativeAdCount;
		[Export ("maximumNativeAdCount", ArgumentSemantic.Assign)]
		nuint MaximumNativeAdCount { get; }

		// @property (getter = isAnimationEnabled, assign, nonatomic) BOOL animationEnabled;
		[Export ("animationEnabled")]
		bool AnimationEnabled { [Bind ("isAnimationEnabled")] get; set; }

		// @property (assign, nonatomic) CGFloat xInset;
		[Export ("xInset", ArgumentSemantic.Assign)]
		nfloat XInset { get; set; }

		// @property (getter = isAdPersistenceEnabled, assign, nonatomic) BOOL adPersistenceEnabled;
		[Export ("adPersistenceEnabled")]
		bool AdPersistenceEnabled { [Bind ("isAdPersistenceEnabled")] get; set; }

		// @property (nonatomic, weak) UIViewController * viewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (nonatomic, weak) id<FBNativeAdDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withType:(FBNativeAdViewType)type;
		[Export ("initWithNativeAdsManager:withType:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withType:(FBNativeAdViewType)type withAttributes:(FBNativeAdViewAttributes *)attributes;
		[Export ("initWithNativeAdsManager:withType:withAttributes:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withType:(FBNativeAdViewType)type withAttributes:(FBNativeAdViewAttributes *)attributes withMaximum:(NSUInteger)maximumNativeAdCount;
		[Export ("initWithNativeAdsManager:withType:withAttributes:withMaximum:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes, nuint maximumNativeAdCount);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withViewProvider:(UIView *(^)(FBNativeAd *, NSUInteger))childViewProvider;
		[Export ("initWithNativeAdsManager:withViewProvider:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdScrollViewViewProviderHandler childViewProviderHandler);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withViewProvider:(UIView *(^)(FBNativeAd *, NSUInteger))childViewProvider withMaximum:(NSUInteger)maximumNativeAdCount;
		[DesignatedInitializer]
		[Export ("initWithNativeAdsManager:withViewProvider:withMaximum:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdScrollViewViewProviderHandler childViewProviderHandler, nuint maximumNativeAdCount);
	}

	interface INativeAdsManagerDelegate
	{

	}

	// @protocol FBNativeAdsManagerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBNativeAdsManagerDelegate")]
	interface NativeAdsManagerDelegate
	{
		// @required -(void)nativeAdsLoaded;
		[Abstract]
		[Export ("nativeAdsLoaded")]
		void NativeAdsLoaded ();

		// @required -(void)nativeAdsFailedToLoadWithError:(NSError *)error;
		[Abstract]
		[Export ("nativeAdsFailedToLoadWithError:")]
		void NativeAdsFailedToLoad (NSError error);
	}

	// @interface FBNativeAdsManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNativeAdsManager")]
	interface NativeAdsManager
	{
		// @property (nonatomic, weak) id<FBNativeAdsManagerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdsManagerDelegate Delegate { get; set; }

		// @property (assign, nonatomic) FBNativeAdsCachePolicy mediaCachePolicy;
		[Export ("mediaCachePolicy", ArgumentSemantic.Assign)]
		NativeAdsCachePolicy MediaCachePolicy { get; set; }

		// @property (readonly, assign, nonatomic) NSUInteger uniqueNativeAdCount;
		[Export ("uniqueNativeAdCount", ArgumentSemantic.Assign)]
		nuint UniqueNativeAdCount { get; }

		// @property (readonly, getter = isValid, assign, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; }

		// -(instancetype)initWithPlacementID:(NSString *)placementID forNumAdsRequested:(NSUInteger)numAdsRequested;
		[DesignatedInitializer]
		[Export ("initWithPlacementID:forNumAdsRequested:")]
		IntPtr Constructor (string placementId, nuint numAdsRequested);

		// -(void)loadAds;
		[Export ("loadAds")]
		void LoadAds ();

		// -(void)disableAutoRefresh;
		[Export ("disableAutoRefresh")]
		void DisableAutoRefresh ();

		// -(FBNativeAd *)nextNativeAd;
		[Export ("nextNativeAd", ArgumentSemantic.Strong)]
		[NullAllowed]
		NativeAd NextNativeAd { get; }
	}

	// @interface FBNativeAdTableViewAdProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNativeAdTableViewAdProvider")]
	interface NativeAdTableViewAdProvider
	{
		// @property (nonatomic, weak) id<FBNativeAdDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// -(instancetype)initWithManager:(FBNativeAdsManager *)manager;
		[DesignatedInitializer]
		[Export ("initWithManager:")]
		IntPtr Constructor (NativeAdsManager manager);

		// -(FBNativeAd *)tableView:(UITableView *)tableView nativeAdForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:nativeAdForRowAtIndexPath:")]
		NativeAd GetNativeAd (UITableView tableView, NSIndexPath indexPath);

		// -(BOOL)isAdCellAtIndexPath:(NSIndexPath *)indexPath forStride:(NSUInteger)stride;
		[Export ("isAdCellAtIndexPath:forStride:")]
		bool IsAdCell (NSIndexPath indexPath, nuint stride);

		// -(NSIndexPath *)adjustNonAdCellIndexPath:(NSIndexPath *)indexPath forStride:(NSUInteger)stride;
		[Export ("adjustNonAdCellIndexPath:forStride:")]
		NSIndexPath AdjustNonAdCell (NSIndexPath indexPath, nuint stride);

		// -(NSUInteger)adjustCount:(NSUInteger)count forStride:(NSUInteger)stride;
		[Export ("adjustCount:forStride:")]
		nuint AdjustCount (nuint count, nuint stride);
	}

	// @interface FBNativeAdTableViewCellProvider : FBNativeAdTableViewAdProvider
	[DisableDefaultCtor]
	[BaseType (typeof (NativeAdTableViewAdProvider), Name = "FBNativeAdTableViewCellProvider")]
	interface NativeAdTableViewCellProvider : IUITableViewDataSource
	{

		// -(instancetype)initWithManager:(FBNativeAdsManager *)manager forType:(FBNativeAdViewType)type;
		[Export ("initWithManager:forType:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type);

		// -(instancetype)initWithManager:(FBNativeAdsManager *)manager forType:(FBNativeAdViewType)type forAttributes:(FBNativeAdViewAttributes *)attributes;
		[DesignatedInitializer]
		[Export ("initWithManager:forType:forAttributes:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes);

		// -(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:cellForRowAtIndexPath:")]
		new UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath);

		// -(CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:heightForRowAtIndexPath:")]
		nfloat GetHeight (UITableView tableView, NSIndexPath indexPath);

		// -(CGFloat)tableView:(UITableView *)tableView estimatedHeightForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:estimatedHeightForRowAtIndexPath:")]
		nfloat GetEstimateHeight (UITableView tableView, NSIndexPath indexPath);
	}

	// @interface FBNativeAdView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBNativeAdView")]
	interface NativeAdView
	{
		// @property (readonly, assign, nonatomic) FBNativeAdViewType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NativeAdViewType Type { get; }

		// +(instancetype)nativeAdViewWithNativeAd:(FBNativeAd *)nativeAd withType:(FBNativeAdViewType)type;
		[Static]
		[Export ("nativeAdViewWithNativeAd:withType:")]
		NativeAdView From (NativeAd nativeAd, NativeAdViewType type);

		// @property (nonatomic, weak) UIViewController * viewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// +(instancetype)nativeAdViewWithNativeAd:(FBNativeAd *)nativeAd withType:(FBNativeAdViewType)type withAttributes:(FBNativeAdViewAttributes *)attributes;
		[Static]
		[Export ("nativeAdViewWithNativeAd:withType:withAttributes:")]
		NativeAdView From (NativeAd nativeAd, NativeAdViewType type, NativeAdViewAttributes attributes);
	}

	// @interface FBNativeAdViewAttributes : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "FBNativeAdViewAttributes")]
	interface NativeAdViewAttributes : INSCopying
	{
		// - (nonnull instancetype)initWithDictionary:(nonnull NSDictionary *) dict;
		[Export ("initWithDictionary:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (copy, nonatomic) UIColor * backgroundColor;
		[NullAllowed]
		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		UIColor BackgroundColor { get; set; }

		// @property (copy, nonatomic) UIColor * titleColor;
		[NullAllowed]
		[Export ("titleColor", ArgumentSemantic.Copy)]
		UIColor TitleColor { get; set; }

		// @property (copy, nonatomic) UIFont * titleFont;
		[NullAllowed]
		[Export ("titleFont", ArgumentSemantic.Copy)]
		UIFont TitleFont { get; set; }

		// @property (copy, nonatomic) UIColor * descriptionColor;
		[NullAllowed]
		[Export ("descriptionColor", ArgumentSemantic.Copy)]
		UIColor DescriptionColor { get; set; }

		// @property (copy, nonatomic) UIFont * descriptionFont;
		[NullAllowed]
		[Export ("descriptionFont", ArgumentSemantic.Copy)]
		UIFont DescriptionFont { get; set; }

		// @property (copy, nonatomic) UIColor * buttonColor;
		[NullAllowed]
		[Export ("buttonColor", ArgumentSemantic.Copy)]
		UIColor ButtonColor { get; set; }

		// @property (copy, nonatomic) UIColor * buttonTitleColor;
		[NullAllowed]
		[Export ("buttonTitleColor", ArgumentSemantic.Copy)]
		UIColor ButtonTitleColor { get; set; }

		// @property (copy, nonatomic) UIFont * buttonTitleFont;
		[NullAllowed]
		[Export ("buttonTitleFont", ArgumentSemantic.Copy)]
		UIFont ButtonTitleFont { get; set; }

		// @property (copy, nonatomic) UIColor * buttonBorderColor;
		[Export ("buttonBorderColor", ArgumentSemantic.Copy)]
		UIColor ButtonBorderColor { get; set; }

		// @property (nonatomic, assign, getter=isAutoplayEnabled) BOOL autoplayEnabled;
		[Export ("autoplayEnabled")]
		bool AutoplayEnabled { [Bind ("isAutoplayEnabled")] get; set; }

		// +(instancetype)defaultAttributesForType:(FBNativeAdViewType)type;
		[Static]
		[Export ("defaultAttributesForType:")]
		NativeAdViewAttributes DefaultAttributes (NativeAdViewType type);
	}

	// @interface FBNativeAdCollectionViewAdProvider : NSObject
	[BaseType (typeof (NSObject), Name = "FBNativeAdCollectionViewAdProvider")]
	interface NativeAdCollectionViewAdProvider
	{
		// @property (nonatomic, weak) id<FBNativeAdDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// -(instancetype _Nonnull)initWithManager:(FBNativeAdsManager * _Nonnull)manager __attribute__((objc_designated_initializer));
		[Export ("initWithManager:")]
		[DesignatedInitializer]
		IntPtr Constructor (NativeAdsManager manager);

		// -(FBNativeAd * _Nonnull)collectionView:(UICollectionView * _Nonnull)collectionView nativeAdForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("collectionView:nativeAdForRowAtIndexPath:")]
		NativeAd GetNativeAdForRow (UICollectionView collectionView, NSIndexPath indexPath);

		// -(BOOL)isAdCellAtIndexPath:(NSIndexPath * _Nonnull)indexPath forStride:(NSUInteger)stride;
		[Export ("isAdCellAtIndexPath:forStride:")]
		bool IsAdCellAtIndexPath (NSIndexPath indexPath, nuint stride);

		// -(NSIndexPath * _Nonnull)adjustNonAdCellIndexPath:(NSIndexPath * _Nonnull)indexPath forStride:(NSUInteger)stride;
		[Export ("adjustNonAdCellIndexPath:forStride:")]
		NSIndexPath AdjustNonAdCellIndexPath (NSIndexPath indexPath, nuint stride);

		// -(NSUInteger)adjustCount:(NSUInteger)count forStride:(NSUInteger)stride;
		[Export ("adjustCount:forStride:")]
		nuint AdjustCount (nuint count, nuint stride);
	}

	// @interface FBNativeAdCollectionViewCellProvider : FBNativeAdCollectionViewAdProvider
	[BaseType (typeof (NativeAdCollectionViewAdProvider), Name = "FBNativeAdCollectionViewCellProvider")]
	interface NativeAdCollectionViewCellProvider
	{
		// -(instancetype _Nonnull)initWithManager:(FBNativeAdsManager * _Nonnull)manager forType:(FBNativeAdViewType)type;
		[Export ("initWithManager:forType:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type);

		// -(instancetype _Nonnull)initWithManager:(FBNativeAdsManager * _Nonnull)manager forType:(FBNativeAdViewType)type forAttributes:(FBNativeAdViewAttributes * _Nonnull)attributes __attribute__((objc_designated_initializer));
		[Export ("initWithManager:forType:forAttributes:")]
		[DesignatedInitializer]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes);

		// -(UICollectionViewCell * _Nonnull)collectionView:(UICollectionView * _Nonnull)collectionView cellForItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("collectionView:cellForItemAtIndexPath:")]
		UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath);

		// -(CGFloat)collectionView:(UICollectionView * _Nonnull)collectionView heightForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("collectionView:heightForRowAtIndexPath:")]
		nfloat GetHeightForRow (UICollectionView collectionView, NSIndexPath indexPath);
	}

	// @interface FBRewardedVideoAd : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBRewardedVideoAd")]
	interface RewardedVideoAd
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull placementID;
		[Export ("placementID")]
		string PlacementId { get; }

		[Obsolete ("Use PlacementId property instead. This will be removed in future versions.")]
		[Wrap ("PlacementId")]
		string PlacementID { get; }

		// @property (readonly, assign, nonatomic) CMTime duration;
		[Export ("duration", ArgumentSemantic.Assign)]
		CMTime Duration { get; }

		// @property (nonatomic, weak) id<FBRewardedVideoAdDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IRewardedVideoAdDelegate Delegate { get; set; }

		// @property (readonly, getter = isAdValid, nonatomic) BOOL adValid;
		[Export ("adValid")]
		bool AdValid { [Bind ("isAdValid")] get; }

		// -(instancetype _Nonnull)initWithPlacementID:(NSString * _Nonnull)placementID;
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		// -(instancetype _Nonnull)initWithPlacementID:(NSString * _Nonnull)placementID withUserID:(NSString * _Nullable)userID withCurrency:(NSString * _Nullable)currency;
		[Export ("initWithPlacementID:withUserID:withCurrency:")]
		IntPtr Constructor (string placementId, [NullAllowed] string userId, [NullAllowed] string currency);

		// -(void)loadAd;
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// - (BOOL)setRewardDataWithUserID:(NSString *)userID withCurrency:(NSString*) currency;
		[Export ("setRewardDataWithUserID:withCurrency:")]
		bool SetRewardData (string userId, string currency);

		// -(BOOL)showAdFromRootViewController:(UIViewController * _Nonnull)rootViewController;
		[Export ("showAdFromRootViewController:")]
		bool ShowAd (UIViewController rootViewController);

		// -(BOOL)showAdFromRootViewController:(UIViewController * _Nonnull)rootViewController animated:(BOOL)flag;
		[Export ("showAdFromRootViewController:animated:")]
		bool ShowAd (UIViewController rootViewController, bool flag);
	}

	interface IRewardedVideoAdDelegate { }

	// @protocol FBRewardedVideoAdDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject), Name = "FBRewardedVideoAdDelegate")]
	interface RewardedVideoAdDelegate
	{
		// @optional -(void)rewardedVideoAdDidClick:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdDidClick:")]
		void RewardedVideoAdDidClick (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdDidLoad:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdDidLoad:")]
		void RewardedVideoAdDidLoad (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdDidClose:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdDidClose:")]
		void RewardedVideoAdDidClose (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdWillClose:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdWillClose:")]
		void RewardedVideoAdWillClose (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAd:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd didFailWithError:(NSError * _Nonnull)error;
		[Export ("rewardedVideoAd:didFailWithError:")]
		void RewardedVideoAdDidFail (RewardedVideoAd rewardedVideoAd, NSError error);

		// @optional -(void)rewardedVideoAdVideoComplete:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdVideoComplete:")]
		void RewardedVideoAdVideoComplete (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdWillLogImpression:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdWillLogImpression:")]
		void RewardedVideoAdWillLogImpression (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdServerSuccess:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdServerRewardDidSucceed:")]
		void RewardedVideoAdServerRewardDidSuccess (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdServerFailed:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdServerRewardDidFail:")]
		void RewardedVideoAdServerRewardDidFail (RewardedVideoAd rewardedVideoAd);
	}
}
