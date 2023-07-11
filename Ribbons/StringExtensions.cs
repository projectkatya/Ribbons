using System.Text;

namespace Ribbons
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static byte[] UTF7Bytes(this string str)
        {
            return Encoding.UTF7.GetBytes(str);
        }

        public static byte[] UTF8Bytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static byte[] UTF32Bytes(this string str)
        {
            return Encoding.UTF32.GetBytes(str);
        }

        public static byte[] ASCIIBytes(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
