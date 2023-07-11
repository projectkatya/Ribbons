using System.Security.Cryptography;

namespace Ribbons
{
    public static class CryptographyExtensions
    {
        public static byte[] HashWithMD5(this string str)
        {
            return str.ComputeHash<MD5>();
        }

        public static byte[] HashWithSHA1(this string str)
        {
            return str.ComputeHash<SHA1>();
        }

        public static byte[] HashWithSHA256(this string str)
        {
            return str.ComputeHash<SHA256>();
        }

        public static byte[] HashWithSHA384(this string str)
        {
            return str.ComputeHash<SHA384>();
        }

        public static byte[] HashWithSHA512(this string str)
        {
            return str.ComputeHash<SHA512>();
        }

        private static byte[] ComputeHash<THashAlgorithm>(this string str) where THashAlgorithm : HashAlgorithm
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(typeof(THashAlgorithm).Name);
            return hashAlgorithm.ComputeHash(str.UTF8Bytes());
        }
    }
}