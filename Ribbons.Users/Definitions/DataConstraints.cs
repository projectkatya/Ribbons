namespace Ribbons.Users.Definitions
{
    public static class DataConstraints
    {
        public const int UserNameLength = 320;
        public const int EmailAddressLength = 320;
        public const int PasswordSaltLength = 512;
        public const int PasswordHashLength = 512;
        public const int PhoneNumberLength = 50;
        public const int UserSessionIdLength = 64;
        public const int SessionSecretSaltLength = 512;
        public const int SessionSecretHashLength = 512;
        public const int UserTokenIdLength = 64;
        public const int TokenSecretSaltLength = 512;
        public const int TokenSecretHashLength = 512;
        public const int CodeMinLength = 3;
        public const int CodeMaxLength = 128;
        public const int NameMinLength = 3;
        public const int NameMaxLength = 255;
        public const int DescriptionLength = 500;
    }
}
