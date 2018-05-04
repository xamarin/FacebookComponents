using System;
using ObjCRuntime;

namespace Facebook.AccountKit
{
    [Native]
    public enum ResponseType : ulong
    {
        AccessToken = 0,
        AuthorizationCode
    }

    [Native]
    public enum LoginType : ulong
    {
        Email = 0,
        Phone
    }

    [Native]
    public enum ButtonType : ulong
    {
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
    public enum LoginFlowState : ulong
    {
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
    public enum TextPosition : ulong
    {
        Default = 0,
        AboveBody,
        BelowBody
    }

    [Native]
    public enum HeaderTextType : ulong
    {
        Login = 0,
        AppName
    }

    [Native]
    public enum InputStyle : long
    {
        Default,
        Underline,
        BlurLight,
        BlurDark
    }

    [Native]
    public enum ButtonTranslucentStyle : long
    {
        Default,
        BlurLight,
        BlurDark
    }

    [Native]
    public enum ErrorCode : long
    {
        NetworkConnectionError = 100,
        ServerError = 200,
        LoginRequestInvalidatedError = 300,
        InvalidParameterValueError = 400
    }

    [Native]
    public enum ServerErrorCode : long
    {
        InvalidServerParameterValueError = 201
    }

    [Native]
    public enum LoginRequestInvalidatedErrorCode : long
    {
        LoginRequestExpiredError = 301
    }

    [Native]
    public enum InvalidParameterValueErrorCode : long
    {
        InvalidEmailAddressError = 401,
        InvalidPhoneNumberError = 402,
        InvalidCodingValueError = 403,
        InvalidAccessTokenError = 404,
        InvalidAccountPreferenceKeyError = 405,
        InvalidAccountPreferenceValueError = 406,
        OperationNotSuccessful = 407,
        InvalidUIManager = 408
    }

    [Native]
    public enum ServerResponseErrorCode : long
    {
        ServerResponseErrorCodeInvalidConfirmationCode = 15003
    }

    [Native]
    public enum SkinType : ulong
    {
        Classic = 0,
        Contemporary,
        Translucent
    }

    [Native]
    public enum BackgroundTint : ulong
    {
        White = 0,
        Black
    }

}

