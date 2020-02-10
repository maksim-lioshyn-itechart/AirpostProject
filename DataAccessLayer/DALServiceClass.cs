using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ORM.Attributes;

namespace DataAccessLayer
{
    internal static class DalServiceClass
    {
        public static TValue GetTableAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            if (type.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault() is TAttribute att)
            {
                return valueSelector(att);
            }
            return default;
        }

        public static IEnumerable<PropertyInfo> GetColumnAttributeValue(this Type type)
        {
            return type.GetProperties().Where(pi => pi.CustomAttributes.Count() != 0);
        }
    }
}
