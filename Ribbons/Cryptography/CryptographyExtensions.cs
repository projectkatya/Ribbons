using System.Security.Cryptography;

namespace Ribbons.Cryptography
{
    public static class CryptographyExtensions
    {
        public static byte[] MD5Hash(this string str)
        {
            return MD5.HashData(str.UTF8Bytes());
        }

        public static byte[] SHA1Hash(this string str)
        {
            return SHA1.HashData(str.UTF8Bytes());
        }

        public static byte[] SHA256Hash(this string str)
        {
            return SHA256.HashData(str.UTF8Bytes());
        }

        public static byte[] SHA512Hash(this string str)
        {
            return SHA512.HashData(str.UTF8Bytes());
        }

        public static Pbkdf2Result Pbkdf2Hash(this string str, Pbkdf2Options options = null)
        {
            options ??= new();

            byte[] salt = RandomNumberGenerator.GetBytes(options.SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(str, salt, options.Iterations, options.HashAlgorithm, options.HashSize);

            return new()
            {
                Salt = salt,
                Hash = hash
            };
        }
    }
}