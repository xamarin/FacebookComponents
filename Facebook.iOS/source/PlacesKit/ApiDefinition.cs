using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreLocation;

namespace Facebook.PlacesKit {
	[Static]
	interface FieldConstants {
		// extern NSString *const FBSDKPlacesFieldKeyAbout;
		[Obsolete ("Use PlacesFieldKey.About enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.About.GetConstant ()")]
		NSString About { get; }

		// extern NSString *const FBSDKPlacesFieldKeyAppLinks;
		[Obsolete ("Use PlacesFieldKey.AppLinks enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.AppLinks.GetConstant ()")]
		NSString AppLinks { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCategories;
		[Obsolete ("Use PlacesFieldKey.Categories enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Categories.GetConstant ()")]
		NSString Categories { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCheckins;
		[Obsolete ("Use PlacesFieldKey.Checkins enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Checkins.GetConstant ()")]
		NSString Checkins { get; }

		// extern NSString *const FBSDKPlacesFieldKeyConfidence;
		[Obsolete ("Use PlacesFieldKey.Confidence enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Confidence.GetConstant ()")]
		NSString Confidence { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCoverPhoto;
		[Obsolete ("Use PlacesFieldKey.CoverPhoto enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.CoverPhoto.GetConstant ()")]
		NSString CoverPhoto { get; }

		// extern NSString *const FBSDKPlacesFieldKeyDescription;
		[Obsolete ("Use PlacesFieldKey.Description enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Description.GetConstant ()")]
		NSString Description { get; }

		// extern NSString *const FBSDKPlacesFieldKeyEngagement;
		[Obsolete ("Use PlacesFieldKey.Engagement enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Engagement.GetConstant ()")]
		NSString Engagement { get; }

		// extern NSString *const FBSDKPlacesFieldKeyHours;
		[Obsolete ("Use PlacesFieldKey.Hours enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Hours.GetConstant ()")]
		NSString Hours { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsAlwaysOpen;
		[Obsolete ("Use PlacesFieldKey.IsAlwaysOpen enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.IsAlwaysOpen.GetConstant ()")]
		NSString IsAlwaysOpen { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsPermanentlyClosed;
		[Obsolete ("Use PlacesFieldKey.IsPermanentlyClosed enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.IsPermanentlyClosed.GetConstant ()")]
		NSString IsPermanentlyClosed { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsVerified;
		[Obsolete ("Use PlacesFieldKey.IsVerified enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.IsVerified.GetConstant ()")]
		NSString IsVerified { get; }

		// extern NSString *const FBSDKPlacesFieldKeyLocation;
		[Obsolete ("Use PlacesFieldKey.Location enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Location.GetConstant ()")]
		NSString Location { get; }

		// extern NSString *const FBSDKPlacesFieldKeyLink;
		[Obsolete ("Use PlacesFieldKey.Link enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Link.GetConstant ()")]
		NSString Link { get; }

		// extern NSString *const FBSDKPlacesFieldKeyName;
		[Obsolete ("Use PlacesFieldKey.Name enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Name.GetConstant ()")]
		NSString Name { get; }

		// extern NSString *const FBSDKPlacesFieldKeyOverallStarRating;
		[Obsolete ("Use PlacesFieldKey.OverallStarRating enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.OverallStarRating.GetConstant ()")]
		NSString OverallStarRating { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPage;
		[Obsolete ("Use PlacesFieldKey.Page enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Page.GetConstant ()")]
		NSString Page { get; }

		// extern NSString *const FBSDKPlacesFieldKeyParking;
		[Obsolete ("Use PlacesFieldKey.Parking enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Parking.GetConstant ()")]
		NSString Parking { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPaymentOptions;
		[Obsolete ("Use PlacesFieldKey.PaymentOptions enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.PaymentOptions.GetConstant ()")]
		NSString PaymentOptions { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPlaceID;
		[Obsolete ("Use PlacesFieldKey.PlaceID enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.PlaceId.GetConstant ()")]
		NSString PlaceId { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPhone;
		[Obsolete ("Use PlacesFieldKey.Phone enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Phone.GetConstant ()")]
		NSString Phone { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPhotos;
		[Obsolete ("Use PlacesFieldKey.Photos enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Photos.GetConstant ()")]
		NSString Photos { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPriceRange;
		[Obsolete ("Use PlacesFieldKey.PriceRange enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.PriceRange.GetConstant ()")]
		NSString PriceRange { get; }

		// extern NSString *const FBSDKPlacesFieldKeyProfilePhoto;
		[Obsolete ("Use PlacesFieldKey.ProfilePhoto enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.ProfilePhoto.GetConstant ()")]
		NSString ProfilePhoto { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRatingCount;
		[Obsolete ("Use PlacesFieldKey.RatingCount enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.RatingCount.GetConstant ()")]
		NSString RatingCount { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantServices;
		[Obsolete ("Use PlacesFieldKey.RestaurantServices enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.RestaurantServices.GetConstant ()")]
		NSString RestaurantServices { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantSpecialties;
		[Obsolete ("Use PlacesFieldKey.RestaurantSpecialties enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.RestaurantSpecialties.GetConstant ()")]
		NSString RestaurantSpecialties { get; }

		// extern NSString *const FBSDKPlacesFieldKeySingleLineAddress;
		[Obsolete ("Use PlacesFieldKey.SingleLineAddress enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.SingleLineAddress.GetConstant ()")]
		NSString SingleLineAddress { get; }

		// extern NSString *const FBSDKPlacesFieldKeyWebsite;
		[Obsolete ("Use PlacesFieldKey.Website enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Website.GetConstant ()")]
		NSString Website { get; }

		// extern NSString *const FBSDKPlacesFieldKeyWorkflows;
		[Obsolete ("Use PlacesFieldKey.Workflows enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesFieldKey.Workflows.GetConstant ()")]
		NSString Workflows { get; }
	}

	[Static]
	interface ResponseConstants {
		// extern NSString *const FBSDKPlacesResponseKeyCity;
		[Obsolete ("Use PlacesResponseKey.City enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.City.GetConstant ()")]
		NSString City { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCityID;
		[Obsolete ("Use PlacesResponseKey.CityID enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.CityId.GetConstant ()")]
		NSString CityId { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCountry;
		[Obsolete ("Use PlacesResponseKey.Country enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Country.GetConstant ()")]
		NSString Country { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCountryCode;
		[Obsolete ("Use PlacesResponseKey.CountryCode enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.CountryCode.GetConstant ()")]
		NSString CountryCode { get; }

		// extern NSString *const FBSDKPlacesResponseKeyLatitude;
		[Obsolete ("Use PlacesResponseKey.Latitude enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Latitude.GetConstant ()")]
		NSString Latitude { get; }

		// extern NSString *const FBSDKPlacesResponseKeyLongitude;
		[Obsolete ("Use PlacesResponseKey.Longitude enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Longitude.GetConstant ()")]
		NSString Longitude { get; }

		// extern NSString *const FBSDKPlacesResponseKeyRegion;
		[Obsolete ("Use PlacesResponseKey.Region enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Region.GetConstant ()")]
		NSString Region { get; }

		// extern NSString *const FBSDKPlacesResponseKeyRegionID;
		[Obsolete ("Use PlacesResponseKey.RegionID enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.RegionId.GetConstant ()")]
		NSString RegionId { get; }

		// extern NSString *const FBSDKPlacesResponseKeyState;
		[Obsolete ("Use PlacesResponseKey.State enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.State.GetConstant ()")]
		NSString State { get; }

		// extern NSString *const FBSDKPlacesResponseKeyStreet;
		[Obsolete ("Use PlacesResponseKey.Street enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Street.GetConstant ()")]
		NSString Street { get; }

		// extern NSString *const FBSDKPlacesResponseKeyZip;
		[Obsolete ("Use PlacesResponseKey.Zip enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Zip.GetConstant ()")]
		NSString Zip { get; }

		// extern NSString *const FBSDKPlacesResponseKeyMatchedCategories;
		[Obsolete ("Use PlacesResponseKey.MatchedCategories enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.MatchedCategories.GetConstant ()")]
		NSString MatchedCategories { get; }

		// extern NSString *const FBSDKPlacesResponseKeyPhotoSource;
		[Obsolete ("Use PlacesResponseKey.PhotoSource enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.PhotoSource.GetConstant ()")]
		NSString PhotoSource { get; }

		// extern NSString *const FBSDKPlacesResponseKeyData;
		[Obsolete ("Use PlacesResponseKey.Data enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Data.GetConstant ()")]
		NSString Data { get; }

		// extern NSString *const FBSDKPlacesResponseKeyUrl;
		[Obsolete ("Use PlacesResponseKey.Url enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesResponseKey.Url.GetConstant ()")]
		NSString Url { get; }
	}

	[Static]
	interface ParameterConstants {
		// extern NSString *const FBSDKPlacesParameterKeySummary;
		[Obsolete ("Use PlacesParameterKey.Summary enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesParameterKey.Summary.GetConstant ()")]
		NSString Summary { get; }
	}

	[Static]
	interface SummaryConstants {
		// extern NSString *const FBSDKPlacesSummaryKeyTracking;
		[Obsolete ("Use PlacesSummaryKey.Tracking enum instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("PlacesSummaryKey.Tracking.GetConstant ()")]
		NSString Tracking { get; }
	}

	// typedef void (^FBSDKPlaceGraphRequestBlock)(FBSDKGraphRequest * _Nullable, CLLocation * _Nullable, NSError * _Nullable);
	delegate void PlaceGraphRequestBlockHandler ([NullAllowed] CoreKit.GraphRequest graphRequest, [NullAllowed] CLLocation location, [NullAllowed] NSError error);

	// typedef void (^FBSDKCurrentPlaceGraphRequestBlock)(FBSDKGraphRequest * _Nullable, NSError * _Nullable);
	delegate void CurrentPlaceGraphRequestBlockHandler ([NullAllowed] CoreKit.GraphRequest graphRequest, [NullAllowed] NSError error);

	// @interface FBSDKPlacesManager : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKPlacesManager")]
	interface PlacesManager {
		// -(void)generatePlaceSearchRequestForSearchTerm:(NSString * _Nullable)searchTerm categories:(NSArray<NSString *> * _Nonnull)categories fields:(NSArray<NSString *> * _Nonnull)fields distance:(CLLocationDistance)distance cursor:(NSString * _Nullable)cursor completion:(FBSDKPlaceGraphRequestBlock _Nonnull)completion __attribute__((swift_name("generatePlaceSearchRequest(for:categories:fields:distance:cursor:completion:)")));
		//[Async (ResultTypeName = "PlaceGraphRequestResult")]
		[Internal]
		[Export ("generatePlaceSearchRequestForSearchTerm:categories:fields:distance:cursor:completion:")]
		void _GeneratePlaceSearchRequest ([NullAllowed] string searchTerm, string [] categories, NSArray fields, double distance, [NullAllowed] string cursor, PlaceGraphRequestBlockHandler completion);

		[Async (ResultTypeName = "PlaceGraphRequestResult")]
		[Wrap ("_GeneratePlaceSearchRequest (searchTerm, categories, NSArray.FromNSObjects (fields), distance, cursor, completion)")]
		void GeneratePlaceSearchRequest ([NullAllowed] string searchTerm, string [] categories, NSString [] fields, double distance, [NullAllowed] string cursor, PlaceGraphRequestBlockHandler completion);

		[Async (ResultTypeName = "PlaceGraphRequestResult")]
		[Wrap ("_GeneratePlaceSearchRequest (searchTerm, categories, NSArray.FromNSObjects<PlacesFieldKey> (f => f.GetConstant (), fields), distance, cursor, completion)")]
		void GeneratePlaceSearchRequest ([NullAllowed] string searchTerm, string [] categories, PlacesFieldKey [] fields, double distance, [NullAllowed] string cursor, PlaceGraphRequestBlockHandler completion);

		[Async (ResultTypeName = "PlaceGraphRequestResult")]
		[Wrap ("_GeneratePlaceSearchRequest (searchTerm, categories, NSArray.FromObjects (fields), distance, cursor, completion)")]
		void GeneratePlaceSearchRequest ([NullAllowed] string searchTerm, string [] categories, string [] fields, double distance, [NullAllowed] string cursor, PlaceGraphRequestBlockHandler completion);

		// -(FBSDKGraphRequest * _Nullable)placeSearchRequestForLocation:(CLLocation * _Nullable)location searchTerm:(NSString * _Nullable)searchTerm categories:(NSArray<NSString *> * _Nullable)categories fields:(NSArray<NSString *> * _Nullable)fields distance:(CLLocationDistance)distance cursor:(NSString * _Nullable)cursor;
		[Internal]
		[return: NullAllowed]
		[Export ("placeSearchRequestForLocation:searchTerm:categories:fields:distance:cursor:")]
		CoreKit.GraphRequest _GeneratePlaceSearchRequest ([NullAllowed] CLLocation location, [NullAllowed] string searchTerm, string [] categories, NSArray fields, double distance, [NullAllowed] string cursor);

		[return: NullAllowed]
		[Wrap ("_GeneratePlaceSearchRequest (location, searchTerm, categories, NSArray.FromNSObjects (fields), distance, cursor)")]
		CoreKit.GraphRequest GeneratePlaceSearchRequest ([NullAllowed] CLLocation location, [NullAllowed] string searchTerm, string [] categories, NSString [] fields, double distance, [NullAllowed] string cursor);

		[return: NullAllowed]
		[Wrap ("_GeneratePlaceSearchRequest (location, searchTerm, categories, NSArray.FromNSObjects<PlacesFieldKey> (f => f.GetConstant (), fields), distance, cursor)")]
		CoreKit.GraphRequest GeneratePlaceSearchRequest ([NullAllowed] CLLocation location, [NullAllowed] string searchTerm, string [] categories, PlacesFieldKey [] fields, double distance, [NullAllowed] string cursor);

		[return: NullAllowed]
		[Wrap ("_GeneratePlaceSearchRequest (location, searchTerm, categories, NSArray.FromObjects (fields), distance, cursor)")]
		CoreKit.GraphRequest GeneratePlaceSearchRequest ([NullAllowed] CLLocation location, [NullAllowed] string searchTerm, string [] categories, string [] fields, double distance, [NullAllowed] string cursor);

		// -(void)generateCurrentPlaceRequestWithMinimumConfidenceLevel:(FBSDKPlaceLocationConfidence)minimumConfidence fields:(NSArray<NSString *> * _Nullable)fields completion:(FBSDKCurrentPlaceGraphRequestCompletion _Nonnull)completion;
		[Internal]
		[Export ("generateCurrentPlaceRequestWithMinimumConfidenceLevel:fields:completion:")]
		void _GenerateCurrentPlaceRequest (PlaceLocationConfidence minimumConfidence, NSArray fields, CurrentPlaceGraphRequestBlockHandler completion);

		[Async]
		[Wrap ("_GenerateCurrentPlaceRequest (minimumConfidence, NSArray.FromNSObjects (fields), completion)")]
		void GenerateCurrentPlaceRequest (PlaceLocationConfidence minimumConfidence, NSString [] fields, CurrentPlaceGraphRequestBlockHandler completion);

		[Async]
		[Wrap ("_GenerateCurrentPlaceRequest (minimumConfidence, NSArray.FromNSObjects<PlacesFieldKey> (f => f.GetConstant (), fields), completion)")]
		void GenerateCurrentPlaceRequest (PlaceLocationConfidence minimumConfidence, PlacesFieldKey [] fields, CurrentPlaceGraphRequestBlockHandler completion);

		[Async]
		[Wrap ("_GenerateCurrentPlaceRequest (minimumConfidence, NSArray.FromObjects (fields), completion)")]
		void GenerateCurrentPlaceRequest (PlaceLocationConfidence minimumConfidence, string [] fields, CurrentPlaceGraphRequestBlockHandler completion);

		// -(void)generateCurrentPlaceRequestForCurrentLocation:(CLLocation * _Nonnull)currentLocation withMinimumConfidenceLevel:(FBSDKPlaceLocationConfidence)minimumConfidence fields:(NSArray<NSString *> * _Nullable)fields completion:(FBSDKCurrentPlaceGraphRequestCompletion _Nonnull)completion;
		[Internal]
		[Export ("generateCurrentPlaceRequestForCurrentLocation:withMinimumConfidenceLevel:fields:completion:")]
		void _GenerateCurrentPlaceRequest (CLLocation currentLocation, PlaceLocationConfidence minimumConfidence, NSArray fields, CurrentPlaceGraphRequestBlockHandler completion);

		[Async]
		[Wrap ("_GenerateCurrentPlaceRequest (currentLocation, minimumConfidence, NSArray.FromNSObjects (fields), completion)")]
		void GenerateCurrentPlaceRequest (CLLocation currentLocation, PlaceLocationConfidence minimumConfidence, NSString [] fields, CurrentPlaceGraphRequestBlockHandler completion);

		[Async]
		[Wrap ("_GenerateCurrentPlaceRequest (currentLocation, minimumConfidence, NSArray.FromNSObjects<PlacesFieldKey> (f => f.GetConstant (), fields), completion)")]
		void GenerateCurrentPlaceRequest (CLLocation currentLocation, PlaceLocationConfidence minimumConfidence, PlacesFieldKey [] fields, CurrentPlaceGraphRequestBlockHandler completion);

		[Async]
		[Wrap ("_GenerateCurrentPlaceRequest (currentLocation, minimumConfidence, NSArray.FromObjects (fields), completion)")]
		void GenerateCurrentPlaceRequest (CLLocation currentLocation, PlaceLocationConfidence minimumConfidence, string [] fields, CurrentPlaceGraphRequestBlockHandler completion);

		// -(FBSDKGraphRequest * _Nonnull)currentPlaceFeedbackRequestForPlaceID:(NSString * _Nonnull)placeID tracking:(NSString * _Nonnull)tracking wasHere:(BOOL)wasHere;
		[Export ("currentPlaceFeedbackRequestForPlaceID:tracking:wasHere:")]
		CoreKit.GraphRequest GenerateCurrentPlaceFeedbackRequest (string placeId, string tracking, bool wasHere);

		// -(FBSDKGraphRequest * _Nonnull)placeInfoRequestForPlaceID:(NSString * _Nonnull)placeID fields:(NSArray<NSString *> * _Nullable)fields;
		[Internal]
		[Export ("placeInfoRequestForPlaceID:fields:")]
		CoreKit.GraphRequest _GeneratePlaceInfoRequest (string placeId, NSArray fields);

		[Wrap ("_GeneratePlaceInfoRequest (placeId, NSArray.FromNSObjects (fields))")]
		CoreKit.GraphRequest GeneratePlaceInfoRequest (string placeId, NSString [] fields);

		[Wrap ("_GeneratePlaceInfoRequest (placeId, NSArray.FromNSObjects<PlacesFieldKey> (f => f.GetConstant (), fields))")]
		CoreKit.GraphRequest GeneratePlaceInfoRequest (string placeId, PlacesFieldKey [] fields);

		[Wrap ("_GeneratePlaceInfoRequest (placeId, NSArray.FromObjects (fields))")]
		CoreKit.GraphRequest GeneratePlaceInfoRequest (string placeId, string [] fields);
	}
}
