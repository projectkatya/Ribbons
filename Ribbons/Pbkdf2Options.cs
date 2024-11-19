using System.Security.Cryptography;

namespace Ribbons
{
    public sealed class Pbkdf2Options
    {
        public int SaltSize { get; set; } = 128;
        public int HashSize { get; set; } = 128;
        public int Iterations { get; set; } = 10000;
        public HashAlgorithmName HashAlgorithmName { get; set; } = HashAlgorithmName.SHA1;
    }
}