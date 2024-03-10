namespace Ribbons.Users.Definitions
{
    public static class LengthConstraints
    {
        public const int UserNameLength = 320;
        public const int FirstNameLength = 255;
        public const int LastNameLength = 255;
        public const int EmailAddressLength = 320;
        public const int PasswordSaltLength = 128;
        public const int PasswordHashLength = 128;
        public const int PhoneNumberLength = 50;
        public const int UserSessionIdLength = 128;
        public const int UserTokenIdLength = 128;
        public const int TokenSecretSaltLength = 128;
        public const int TokenSecretHashLength = 128;
        public const int CodeLength = 64;
        public const int NameLength = 255;
        public const int DescriptionLength = 500;
    }
}