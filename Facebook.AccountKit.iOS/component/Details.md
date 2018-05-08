# Facebook Account Kit for iOS

Account Kit helps people quickly and easily register and log into your app using their phone number or email address as passwordless credentials. Account Kit is powered by Facebook's email and SMS sending infrastructure for reliable scalable performance with global reach. Because it uses email and phone number authentication, Account Kit doesn't require a Facebook account and is the ideal alternative to a social login.

Account Kit is built for the mobile world, providing long-lived sessions, easy account management, and no passwords to remember. When a person initiates a login with their email address, Account Kit sends a one-time link to the person's email address. The SDK will detect when an email address is verified. When a person initiates a login with their phone number, Account Kit either sends an SMS confirmation code to that number for validation or verifies the number directly (see [instant verification](#instant-verification)).

The login flows for Account Kit combine account registration and account login. There is no need to check if an account exists already or to create a separate flow to register new users. After a successful login or registration, Account Kit provides your app with authentication credentials for the person logging in.

The user interface for the login is provided by the SDK. Provides customizable view controllers to manage the login flow for you. Simply present the view controller to get started.

Account Kit supports SMS-based authentication for hundreds of country codes. For a list of the country codes that Account Kit supports for SMS-based authentication, see [Supported SMS Country Codes][1]. There is no charge for SMS messaging through August 2018. After that, apps that exceed 100,000 SMS messages per month may be charged at standard SMS rates. For more information see ["Is there a charge for using SMS with Account Kit"][2] in the FAQ.

Account Kit also supports localization of the interface, SMS messages, and authentication emails into dozens of languages. For languages supported for localization, see [Supported Languages][3].

## How Account Kit Works

Account Kit creates a database just for your app. You can access the data at any time through a REST API. As people log into your app, this database is populated with a list of phone numbers or email addresses and Account IDs that can be used within your app. These Account IDs are unique to your app. If you also use Facebook Login for your app, you can be sure that there will never be a conflict with Facebook's app-scoped IDs.

Account Kit has two login flows, depending on whether people choose phone number verification or email verification.

### Phone Number Verification Flow

1. Call the Account Kit API with a phone number to initiate a login or registration.
2. Account Kit servers send an SMS with a confirmation code to continue the login. If people fail to receive the SMS code, Account Kit offers two backups that people can choose from:
	* Phone call — People can choose to receive a phone call with the SMS code. For a list of the languages into which the call can be localized, see the [Supported Langages for Phone Calls][4] section of Supported Languages.
	* Facebook notification — If the phone number is linked to a Facebook account, people can choose to have a notification containing the SMS sent to that account.

	Account Kit may also verify the number directly without sending an SMS code. See Instant Verification.
3. The SDK verifies the SMS confirmation code.
4. If your app has enabled Client Access Token Flow, your app will receive an access token containing an account ID in response to a successful login. If your app has not enabled Client Access Token Flow, your client app will receive an authentication code that the application's server may use to securely request an access token.

For more information on Client Access Token Flow, see [Access Tokens and Authorization Codes][5].

### Email Verification Flow

1. Call the Account Kit API with an email address to initiate a login or registration.
2. Account Kit servers send a confirmation email to the email address.
3. The SDK monitors the status of the confirmation email.
4. If your app has enabled Client Access Token Flow, your app will receive an access token containing an account ID in response to a successful login. If your app has not enabled Client Access Token Flow, your client app will receive an authentication code that the application's server may use to securely request an access token.

For more information on Client Access Token Flow, see [Access Tokens and Authorization Codes][5].

## Account Kit Settings Page

People using Account Kit to log into apps have access to a settings page where they can block notifications and delete their accounts from apps. This is important for developers because if someone deletes their account from your app and then later uses Account Kit with the same credentials to log into your app, their account ID will be different.

[1]: https://developers.facebook.com/docs/accountkit/countrycodes
[2]: https://developers.facebook.com/docs/accountkit/faq/#faq_184327531988271
[3]: https://developers.facebook.com/docs/accountkit/languages
[4]: https://developers.facebook.com/docs/accountkit/languages/#call
[5]: https://developers.facebook.com/docs/accountkit/accesstokens
