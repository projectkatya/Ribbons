namespace Ribbons.Users.Definitions
{
    public static class ColumnConstraints
    {
        public const int UserNameMaxLength = 320;
        public const int EmailAddressMaxLength = 320;
        public const int CodeMaxLength = 128;
        public const int NameMaxLength = 255;
        public const int DescriptionMaxLength = 500;
        public const int PasswordSaltMaxLength = 128;
        public const int PasswordHashMaxLength = 128;
        public const int PhoneNumberMaxLength = 50;
        public const int UserSessionIdMaxLength = 128;
        public const int SessionTokenSaltMaxLength = 128;
        public const int SessionTokenHashMaxLength = 128;
        public const int UserTokenIdMaxLength = 128;
        public const int TokenSecretSaltMaxLength = 128;
        public const int TokenSecretHashMaxLength = 128;
    }
}