using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace VendasApi.Utils
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this T value) where T : class => value == null;
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool IsNullOrEmpty(this IList value) => value == null || value.Count == 0;
        public static int GetId(this Enum value) => Convert.ToInt32(value);
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                DescriptionAttribute attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }
    }
}
