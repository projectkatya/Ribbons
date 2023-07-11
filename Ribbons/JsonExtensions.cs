using Newtonsoft.Json;

namespace Ribbons
{
    public static class JsonExtensions
    {
        public static string ToJson<TValue>(this TValue obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static TValue FromJson<TValue>(this string str)
        {
            return JsonConvert.DeserializeObject<TValue>(str);
        }
    }
}