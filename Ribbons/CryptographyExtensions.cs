using System.Linq;
using System.Security.Cryptography;

namespace Ribbons
{
    public static class CryptographyExtensions
    {
        public const int DefaultPbkdf2SaltSize = 128;
        public const int DefaultPbkdf2HashSize = 128;
        public const int DefaultPbkdf2Iterations = 10000;
        
        public static void ComputePbkdf2(
            this string str, 
            out byte[] salt, 
            out byte[] hash, 
            int saltSize = DefaultPbkdf2SaltSize, 
            int hashSize = DefaultPbkdf2HashSize, 
            int iterations = DefaultPbkdf2Iterations)
        {
            salt = RandomNumberGenerator.GetBytes(saltSize);
            hash = Rfc2898DeriveBytes.Pbkdf2(str, salt, iterations, HashAlgorithmName.SHA1, hashSize);
        }

        public static bool VerifyPbkdf2(
            this string str,
            byte[] salt,
            byte[] targetHash,
            int hashSize = DefaultPbkdf2HashSize,
            int iterations = DefaultPbkdf2Iterations)
        {
            byte[] computeddHash = Rfc2898DeriveBytes.Pbkdf2(str, salt, iterations, HashAlgorithmName.SHA1, hashSize);
            return targetHash.SequenceEqual(computeddHash);
        }

        public static byte[] ComputeSHA512(this string str)
        {
            return SHA512.HashData(str.UTF8Bytes());
        }
    }
}