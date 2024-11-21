using System.Security.Cryptography;

namespace Ribbons
{
    public static class Randomizer
    {
        public const string CharacterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string GetString(int length)
        {
            return RandomNumberGenerator.GetString(CharacterSet, length);
        }
    }
}