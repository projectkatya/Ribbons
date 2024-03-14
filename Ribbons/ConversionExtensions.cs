using System;
using System.Collections.Generic;

namespace Ribbons
{
    public static class ConversionExtensions
    {
        private static readonly Dictionary<Type, Converter> Converters = new Dictionary<Type, Converter>
        {
            [typeof(short)] = o => Convert.ToInt16(o),
            [typeof(int)] = o => Convert.ToInt32(o),
            [typeof(long)] = o => Convert.ToInt64(o),
            [typeof(ushort)] = o => Convert.ToUInt16(o),
            [typeof(uint)] = o => Convert.ToUInt32(o),
            [typeof(ulong)] = o => Convert.ToUInt64(o),
            [typeof(float)] = o => Convert.ToSingle(o),
            [typeof(double)] = o => Convert.ToDouble(o),
            [typeof(decimal)] = o => Convert.ToDecimal(o),
            [typeof(bool)] = o => Convert.ToBoolean(o),
            [typeof(DateTime)] = o => Convert.ToDateTime(o)
        };

        public static T ConvertTo<T>(this object obj)
        {
            Type targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            bool isNullable = Nullable.GetUnderlyingType(typeof(T)) != null;

            if (isNullable && obj == null)
            {
                return default;
            }

            if (!Converters.TryGetValue(targetType, out Converter converter))
            {
                throw new NotSupportedException($"Conversion to type {targetType.FullName} is not supported at this time.");
            }

            return (T)converter(obj);
        }

        private delegate object Converter(object input);
    }
}