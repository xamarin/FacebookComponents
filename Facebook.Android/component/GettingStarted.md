# Getting Started



### Install the Facebook application

To take advantage of the native Facebook dialogs, the Facebook application must be installed on the device.  If the Facebook application is not installed on the device, fallbacks to Web based dialogs can instead be used.  If you are testing on an emulator which does not have the ability to install Facebook from the Play store, you can install `FBAndroid.apk` which is included in the SDK which can be downloaded from: https://developers.facebook.com/docs/android/downloads

### Facebook Developers site - Create an app
In order to integrate with Facebook's login, you must have a Facebook app setup on your Facebook Developer site.  More information on how to create an app can be found at
https://developers.facebook.com/docs/android/getting-started/#create-app

**Creating your Key Hashes**

As part of creating your app, you will need to provide a hash of your app's keystore's key.  Keep in mind that you will be signing your app with a different keystore when you are publishing to the Play Store.  You must add the key hashes of any keystores you use to build/test/publish your app to your Facebook app.

The default keystore that Xamarin.Android uses (which has an alias of *androiddebugkey*) can be found at:

```
Windows:
C:\Users\[USERNAME]\AppData\Local\Xamarin\Mono for Android\debug.keystore

Mac OSX:
/Users/[USERNAME]/.local/share/Xamarin/Mono for Android/debug.keystore
```

To generate a Key Hash, we need to execute the following commands (if you're not using the default Xamarin.Android debug.keystore, make sure you specify the correct alias for the keystore you created):

```
Windows:
keytool -exportcert -alias androiddebugkey -keystore debug.keystore | openssl sha1 -binary | openssl base64

Mac OSX:
keytool -exportcert -alias androiddebugkey -keystore debug.keystore | openssl sha1 -binary | openssl base64
```
The output from the command above is the hash you need to add to your Facebook app.





### Adding MetaData and Permissions
To integrate with Facebook SDK, your app must declare the ***App ID*** of the app you created on the Facebook Developer site (this should be on your App's dashboard).  This App ID must be specified in your `AndroidManifest.xml` file.  The easiest way to do this is with an attribute:

```
// NOTE: Facebook SDK rquires that the 'Value' point to a string resource
//       in your values/ folder (eg: strings.xml file).
//       It will not allow you to use the app_id value directly here!
[assembly:MetaData ("com.facebook.sdk.ApplicationId", Value ="@string/app_id")]
```

Your app_id should be defined in your /Resources/values/strings.xml file like this:

```
<?xml version="1.0" encoding="utf-8"?>
<resources>
	<string name="app_id">YOUR-APP-ID</string>
</resources>
```

You must also declare permissions for *INTERNET* and *WRITE_EXTERNAL_STORAGE* which can be done with these attributes:

```
[assembly:Permission (Name = Android.Manifest.Permission.Internet)]
[assembly:Permission (Name = Android.Manifest.Permission.WriteExternalStorage)]
```

### Add Facebook Activity to your Manifest
If you plan on using Facebook's Login or Share (if you are unsure, you should add this), you should declare the activity within your own Application's `AndroidManifest.xml`, inside of the `<application></application>` tag:

```
<activity android:name="com.facebook.FacebookActivity"
          android:configChanges=
            "keyboard|keyboardHidden|screenLayout|screenSize|orientation"
          android:theme="@android:style/Theme.Translucent.NoTitleBar"
          android:label="@string/app_name" />
```


### Facebook Login in your App
To have your app log a user into Facebook, you will want to create and open a new `Session`.  The Facebook SDK by default will manage caching your access token and login state for you, all you need to do is ensure you ask to open the session at some point in your app before trying to use the `Session.ActiveSession`.  The sample below shows how to open a session, listen for the status result of that request, and then make a request to the Graph API to get the name of the currently logged in user.  Note that you must pass the `OnActivityResult` calls over to the `ActiveSession` so Facebook can join in the lifecycle of activity results.  Once you have an open and active session, you can access the `Session.ActiveSession.AccessToken` for use in your Graph API library of choice (it does not have to be the one in this SDK).

### Sending images or videos
If you're sharing links, images, or video via the Facebook for Android app, you also need to declare the `FacebookContentProvider` in your manifest inside the `<application>` element.  

Append your app id to the end of the `authorities` value.  For example if your Facebook app id is `1234`, the declaration looks like this:

```xml
<provider android:authorities="com.facebook.app.FacebookContentProvider1234"
          android:name="com.facebook.FacebookContentProvider"
          android:exported="true" />
```

### Samples

The sample apps included in the component demonstrate how to do basic login and sharing, as well as sharing through Messenger.

You must have Messenger installed on the device you want to test the Messenger Send Sample on.  



 
## Learn More
You can learn more by visiting the official Facebook Android SDK Documentation site here: https://developers.facebook.com/docs/android/           