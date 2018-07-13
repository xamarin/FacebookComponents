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
		[Field ("FBSDKPlacesFieldKeyAbout", "__Internal")]
		NSString About { get; }

		// extern NSString *const FBSDKPlacesFieldKeyAppLinks;
		[Field ("FBSDKPlacesFieldKeyAppLinks", "__Internal")]
		NSString AppLinks { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCategories;
		[Field ("FBSDKPlacesFieldKeyCategories", "__Internal")]
		NSString Categories { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCheckins;
		[Field ("FBSDKPlacesFieldKeyCheckins", "__Internal")]
		NSString Checkins { get; }

		// extern NSString *const FBSDKPlacesFieldKeyContext;
		[Field ("FBSDKPlacesFieldKeyContext", "__Internal")]
		NSString Context { get; }

		// extern NSString *const FBSDKPlacesFieldKeyConfidence;
		[Field ("FBSDKPlacesFieldKeyConfidence", "__Internal")]
		NSString Confidence { get; }

		// extern NSString *const FBSDKPlacesFieldKeyCoverPhoto;
		[Field ("FBSDKPlacesFieldKeyCoverPhoto", "__Internal")]
		NSString CoverPhoto { get; }

		// extern NSString *const FBSDKPlacesFieldKeyDescription;
		[Field ("FBSDKPlacesFieldKeyDescription", "__Internal")]
		NSString Description { get; }

		// extern NSString *const FBSDKPlacesFieldKeyEngagement;
		[Field ("FBSDKPlacesFieldKeyEngagement", "__Internal")]
		NSString Engagement { get; }

		// extern NSString *const FBSDKPlacesFieldKeyHours;
		[Field ("FBSDKPlacesFieldKeyHours", "__Internal")]
		NSString Hours { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsAlwaysOpen;
		[Field ("FBSDKPlacesFieldKeyIsAlwaysOpen", "__Internal")]
		NSString IsAlwaysOpen { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsPermanentlyClosed;
		[Field ("FBSDKPlacesFieldKeyIsPermanentlyClosed", "__Internal")]
		NSString IsPermanentlyClosed { get; }

		// extern NSString *const FBSDKPlacesFieldKeyIsVerified;
		[Field ("FBSDKPlacesFieldKeyIsVerified", "__Internal")]
		NSString IsVerified { get; }

		// extern NSString *const FBSDKPlacesFieldKeyLocation;
		[Field ("FBSDKPlacesFieldKeyLocation", "__Internal")]
		NSString Location { get; }

		// extern NSString *const FBSDKPlacesFieldKeyLink;
		[Field ("FBSDKPlacesFieldKeyLink", "__Internal")]
		NSString Link { get; }

		// extern NSString *const FBSDKPlacesFieldKeyName;
		[Field ("FBSDKPlacesFieldKeyName", "__Internal")]
		NSString Name { get; }

		// extern NSString *const FBSDKPlacesFieldKeyOverallStarRating;
		[Field ("FBSDKPlacesFieldKeyOverallStarRating", "__Internal")]
		NSString OverallStarRating { get; }

		// extern NSString *const FBSDKPlacesFieldKeyParking;
		[Field ("FBSDKPlacesFieldKeyParking", "__Internal")]
		NSString Parking { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPaymentOptions;
		[Field ("FBSDKPlacesFieldKeyPaymentOptions", "__Internal")]
		NSString PaymentOptions { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPlaceID;
		[Field ("FBSDKPlacesFieldKeyPlaceID", "__Internal")]
		NSString PlaceId { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPhone;
		[Field ("FBSDKPlacesFieldKeyPhone", "__Internal")]
		NSString Phone { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPhotos;
		[Field ("FBSDKPlacesFieldKeyPhotos", "__Internal")]
		NSString Photos { get; }

		// extern NSString *const FBSDKPlacesFieldKeyPriceRange;
		[Field ("FBSDKPlacesFieldKeyPriceRange", "__Internal")]
		NSString PriceRange { get; }

		// extern NSString *const FBSDKPlacesFieldKeyProfilePhoto;
		[Field ("FBSDKPlacesFieldKeyProfilePhoto", "__Internal")]
		NSString ProfilePhoto { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRatingCount;
		[Field ("FBSDKPlacesFieldKeyRatingCount", "__Internal")]
		NSString RatingCount { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantServices;
		[Field ("FBSDKPlacesFieldKeyRestaurantServices", "__Internal")]
		NSString RestaurantServices { get; }

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantSpecialties;
		[Field ("FBSDKPlacesFieldKeyRestaurantSpecialties", "__Internal")]
		NSString RestaurantSpecialties { get; }

		// extern NSString *const FBSDKPlacesFieldKeySingleLineAddress;
		[Field ("FBSDKPlacesFieldKeySingleLineAddress", "__Internal")]
		NSString SingleLineAddress { get; }

		// extern NSString *const FBSDKPlacesFieldKeyWebsite;
		[Field ("FBSDKPlacesFieldKeyWebsite", "__Internal")]
		NSString Website { get; }

		// extern NSString *const FBSDKPlacesFieldKeyWorkflows;
		[Field ("FBSDKPlacesFieldKeyWorkflows", "__Internal")]
		NSString Workflows { get; }
	}

	[Static]
	interface ResponseConstants {
		// extern NSString *const FBSDKPlacesResponseKeyCity;
		[Field ("FBSDKPlacesResponseKeyCity", "__Internal")]
		NSString City { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCityID;
		[Field ("FBSDKPlacesResponseKeyCityID", "__Internal")]
		NSString CityId { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCountry;
		[Field ("FBSDKPlacesResponseKeyCountry", "__Internal")]
		NSString Country { get; }

		// extern NSString *const FBSDKPlacesResponseKeyCountryCode;
		[Field ("FBSDKPlacesResponseKeyCountryCode", "__Internal")]
		NSString CountryCode { get; }

		// extern NSString *const FBSDKPlacesResponseKeyLatitude;
		[Field ("FBSDKPlacesResponseKeyLatitude", "__Internal")]
		NSString Latitude { get; }

		// extern NSString *const FBSDKPlacesResponseKeyLongitude;
		[Field ("FBSDKPlacesResponseKeyLongitude", "__Internal")]
		NSString Longitude { get; }

		// extern NSString *const FBSDKPlacesResponseKeyRegion;
		[Field ("FBSDKPlacesResponseKeyRegion", "__Internal")]
		NSString Region { get; }

		// extern NSString *const FBSDKPlacesResponseKeyRegionID;
		[Field ("FBSDKPlacesResponseKeyRegionID", "__Internal")]
		NSString RegionId { get; }

		// extern NSString *const FBSDKPlacesResponseKeyState;
		[Field ("FBSDKPlacesResponseKeyState", "__Internal")]
		NSString State { get; }

		// extern NSString *const FBSDKPlacesResponseKeyStreet;
		[Field ("FBSDKPlacesResponseKeyStreet", "__Internal")]
		NSString Street { get; }

		// extern NSString *const FBSDKPlacesResponseKeyZip;
		[Field ("FBSDKPlacesResponseKeyZip", "__Internal")]
		NSString Zip { get; }

		// extern NSString *const FBSDKPlacesResponseKeyMatchedCategories;
		[Field ("FBSDKPlacesResponseKeyMatchedCategories", "__Internal")]
		NSString MatchedCategories { get; }

		// extern NSString *const FBSDKPlacesResponseKeyPhotoSource;
		[Field ("FBSDKPlacesResponseKeyPhotoSource", "__Internal")]
		NSString PhotoSource { get; }

		// extern NSString *const FBSDKPlacesResponseKeyData;
		[Field ("FBSDKPlacesResponseKeyData", "__Internal")]
		NSString Data { get; }

		// extern NSString *const FBSDKPlacesResponseKeyUrl;
		[Field ("FBSDKPlacesResponseKeyUrl", "__Internal")]
		NSString Url { get; }
	}

	[Static]
	interface ParameterConstants {
		// extern NSString *const FBSDKPlacesParameterKeySummary;
		[Field ("FBSDKPlacesParameterKeySummary", "__Internal")]
		NSString Summary { get; }
	}

	[Static]
	interface SummaryConstants {
		// extern NSString *const FBSDKPlacesSummaryKeyTracking;
		[Field ("FBSDKPlacesSummaryKeyTracking", "__Internal")]
		NSString Tracking { get; }
	}

	// typedef void (^FBSDKPlaceGraphRequestCompletion)(FBSDKGraphRequest * _Nullable, CLLocation * _Nullable, NSError * _Nullable);
	delegate void PlaceGraphRequestCompletionHandler ([NullAllowed] CoreKit.GraphRequest graphRequest, [NullAllowed] CLLocation location, [NullAllowed] NSError error);

	// typedef void (^FBSDKCurrentPlaceGraphRequestCompletion)(FBSDKGraphRequest * _Nullable, NSError * _Nullable);
	delegate void CurrentPlaceGraphRequestCompletionHandler ([NullAllowed] CoreKit.GraphRequest graphRequest, [NullAllowed] NSError error);

	// @interface FBSDKPlacesManager : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKPlacesManager")]
	interface PlacesManager {
		// -(void)generatePlaceSearchRequestForSearchTerm:(NSString * _Nullable)searchTerm categories:(NSArray<NSString *> * _Nullable)categories fields:(NSArray<NSString *> * _Nullable)fields distance:(CLLocationDistance)distance cursor:(NSString * _Nullable)cursor completion:(FBSDKPlaceGraphRequestCompletion _Nonnull)completion;
		[Export ("generatePlaceSearchRequestForSearchTerm:categories:fields:distance:cursor:completion:")]
		void GeneratePlaceSearchRequest ([NullAllowed] string searchTerm, [NullAllowed] string [] categories, [NullAllowed] string [] fields, double distance, [NullAllowed] string cursor, PlaceGraphRequestCompletionHandler completion);

		// -(FBSDKGraphRequest * _Nullable)placeSearchRequestForLocation:(CLLocation * _Nullable)location searchTerm:(NSString * _Nullable)searchTerm categories:(NSArray<NSString *> * _Nullable)categories fields:(NSArray<NSString *> * _Nullable)fields distance:(CLLocationDistance)distance cursor:(NSString * _Nullable)cursor;
		[return: NullAllowed]
		[Export ("placeSearchRequestForLocation:searchTerm:categories:fields:distance:cursor:")]
		CoreKit.GraphRequest GeneratePlaceSearchRequest ([NullAllowed] CLLocation location, [NullAllowed] string searchTerm, [NullAllowed] string [] categories, [NullAllowed] string [] fields, double distance, [NullAllowed] string cursor);

		// -(void)generateCurrentPlaceRequestWithMinimumConfidenceLevel:(FBSDKPlaceLocationConfidence)minimumConfidence fields:(NSArray<NSString *> * _Nullable)fields completion:(FBSDKCurrentPlaceGraphRequestCompletion _Nonnull)completion;
		[Export ("generateCurrentPlaceRequestWithMinimumConfidenceLevel:fields:completion:")]
		void GenerateCurrentPlaceRequest (PlaceLocationConfidence minimumConfidence, [NullAllowed] string [] fields, CurrentPlaceGraphRequestCompletionHandler completion);

		// -(void)generateCurrentPlaceRequestForCurrentLocation:(CLLocation * _Nonnull)currentLocation withMinimumConfidenceLevel:(FBSDKPlaceLocationConfidence)minimumConfidence fields:(NSArray<NSString *> * _Nullable)fields completion:(FBSDKCurrentPlaceGraphRequestCompletion _Nonnull)completion;
		[Export ("generateCurrentPlaceRequestForCurrentLocation:withMinimumConfidenceLevel:fields:completion:")]
		void GenerateCurrentPlaceRequest (CLLocation currentLocation, PlaceLocationConfidence minimumConfidence, [NullAllowed] string [] fields, CurrentPlaceGraphRequestCompletionHandler completion);

		// -(FBSDKGraphRequest * _Nonnull)currentPlaceFeedbackRequestForPlaceID:(NSString * _Nonnull)placeID tracking:(NSString * _Nonnull)tracking wasHere:(BOOL)wasHere;
		[Export ("currentPlaceFeedbackRequestForPlaceID:tracking:wasHere:")]
		CoreKit.GraphRequest GenerateCurrentPlaceFeedbackRequest (string placeId, string tracking, bool wasHere);

		// -(FBSDKGraphRequest * _Nonnull)placeInfoRequestForPlaceID:(NSString * _Nonnull)placeID fields:(NSArray<NSString *> * _Nullable)fields;
		[Export ("placeInfoRequestForPlaceID:fields:")]
		CoreKit.GraphRequest GeneratePlaceInfoRequest (string placeId, [NullAllowed] string [] fields);
	}
}
