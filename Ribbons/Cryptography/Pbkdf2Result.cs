namespace Ribbons.Cryptography
{
    public class Pbkdf2Result
    {
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}