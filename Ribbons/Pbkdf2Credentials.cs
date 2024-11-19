namespace Ribbons
{
    public sealed class Pbkdf2Credentials
    {
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}