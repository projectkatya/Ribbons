using System;
using System.Linq;
using System.Text;
using System.Web;

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

        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        public static string HtmlDecode(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        public static string HtmlAttributeEncode(this string str)
        {
            return HttpUtility.HtmlAttributeEncode(str);
        }

        public static byte[] ASCIIBytes(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static byte[] UTF8Bytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlDecode(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string ToHexString(this byte[] bytes)
        {
            return string.Join("", bytes.Select(x => x.ToString("X2")));
        }
    }
}