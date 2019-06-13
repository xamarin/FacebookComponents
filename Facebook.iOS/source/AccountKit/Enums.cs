using System;
using ObjCRuntime;

namespace Facebook.AccountKit {
	[Native]
	public enum ResponseType : ulong {
		AccessToken = 0,
		AuthorizationCode
	}

	[Native]
	public enum LoginType : ulong {
		Email = 0,
		Phone
	}

	[Native]
	public enum ButtonType : ulong {
		Default = 0,
		Begin,
		Confirm,
		Continue,
		LogIn,
		Next,
		Ok,
		Send,
		Start,
		Submit
	}

	[Native]
	public enum LoginFlowState : ulong {
		None = 0,
		PhoneNumberInput,
		EmailInput,
		EmailVerify,
		SendingCode,
		SentCode,
		CodeInput,
		VerifyingCode,
		Verified,
		Error,
		ResendCode,
		CountryCode
	}

	[Native]
	public enum TextPosition : ulong {
		Default = 0,
		AboveBody,
		BelowBody
	}

	[Native]
	public enum HeaderTextType : ulong {
		Login = 0,
		AppName
	}

	[Native]
	public enum InputStyle : long {
		Default,
		Underline,
		BlurLight,
		BlurDark
	}

	[Native]
	public enum ButtonTranslucentStyle : long {
		Default,
		BlurLight,
		BlurDark
	}

	[Native]
	public enum Error : long {
		NetworkConnection = 100,
		Server = 200,
		LoginRequestInvalidated = 300,
		InvalidParameterValue = 400
	}

	[Native]
	public enum ServerError : long {
		InvalidServerParameterValueError = 201
	}

	[Native]
	public enum LoginRequestError : long {
		Expired = 301
	}

	[Native]
	public enum ParameterError : long {
		EmailAddress = 401,
		PhoneNumber = 402,
		CodingValue = 403,
		AccessToken = 404,
		AccountPreferenceKey = 405,
		AccountPreferenceValue = 406,
		OperationNotSuccessful = 407,
		UIManager = 408
	}

	[Native]
	public enum ServerResponseError : long {
		InvalidConfirmationCode = 15003
	}

	[Native]
	public enum SkinType : ulong {
		Classic = 0,
		Contemporary,
		Translucent
	}

	[Native]
	public enum BackgroundTint : ulong {
		White = 0,
		Black
	}

}

