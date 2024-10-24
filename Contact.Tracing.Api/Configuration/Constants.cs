namespace Contact.Tracing.Api.Configuration;

public static class Constants
{
    public static class PhoneVerification
    {
        public const string PhoneVerificationRegex = "^[\\\\+]?[(]?[0-9]{3}[)]?[-\\\\s\\\\.]?[0-9]{3}[-\\\\s\\\\.]?[0-9]{4,6}$";

        public const string PhoneNumberMinLength = "Phone Number must not be less than 10 characters.";

        public const string PhoneNumberMaxLength = "Phone Number must not exceed 50 characters.";

        public const string PhoneNumberRequired = "Phone Number is required.";

        public const string PhoneNumberErrorMsg = "Phone Number not valid";
    }

}