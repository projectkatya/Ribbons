﻿using System.Security.Cryptography;

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
    }
}
