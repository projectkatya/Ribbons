using System.Security.Cryptography;

namespace Ribbons
{
    public static class HashExtensions
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

        public static Pbkdf2Credentials Pbkdf2Hash(this string str, Pbkdf2Options options = null)
        {
            options ??= new Pbkdf2Options();

            byte[] saltBytes = RandomNumberGenerator.GetBytes(options.SaltSize);
            byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(str, saltBytes, options.Iterations, options.HashAlgorithmName, options.HashSize);

            return new()
            {
                Salt = saltBytes,
                Hash = hashBytes
            };
        }
    }
}
