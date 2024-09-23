using Newtonsoft.Json;

namespace Ribbons
{
    public static class SerializationExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}