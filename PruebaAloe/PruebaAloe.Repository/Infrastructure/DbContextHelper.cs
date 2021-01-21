using Microsoft.EntityFrameworkCore;
using PruebaAloe.Core.Attributes;
using PruebaAloe.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PruebaAloe.Repository.Infrastructure
{
    public static class DbContextHelper
    {
        public static Func<IQueryable<T>, IQueryable<T>> GetNavigations<T>() where T : BaseEntity
        {
            var type = typeof(T);
            var navigationProperties = new List<string>();

            GetNavigationProperties(type, type, string.Empty, navigationProperties);

            Func<IQueryable<T>, IQueryable<T>> includes = (query =>
            {
                return navigationProperties.Aggregate(query, (current, inc) => current.Include(inc));
            });

            return includes;
        }

        private static void GetNavigationProperties(Type baseType, Type type, string parentPropertyName, IList<string> accumulator)
        {
            PropertyInfo[] properties = type.GetProperties();
            var navigationPropertyInfoList = properties.Where(prop => prop.IsDefined(typeof(NavigationPropertyAttribute)));

            foreach (PropertyInfo prop in navigationPropertyInfoList)
            {
                Type propertyType = prop.PropertyType;
                Type elementType = propertyType.GetTypeInfo().IsGenericType ? propertyType.GetGenericArguments()[0] : propertyType;

                string properyName = string.Format("{0}{1}{2}", parentPropertyName, string.IsNullOrEmpty(parentPropertyName) ? string.Empty : ".", prop.Name);
                accumulator.Add(properyName);

                bool isJsonIgnored = prop.IsDefined(typeof(JsonIgnoreAttribute));

                if (!isJsonIgnored && elementType != baseType)
                {
                    GetNavigationProperties(baseType, elementType, properyName, accumulator);
                }
            }
        }
    }
}
