using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Entelect.Encentivize.Sdk
{
    /// <summary>
    /// Helper to convert objects to a query string, adapted from http://ole.michelsen.dk/blog/serialize-object-into-a-query-string-with-reflection/
    /// Source: http://toquerystring.codeplex.com/
    /// </summary>
    public class QueryStringBuilder
    {
        private readonly string _separator;
        private readonly List<string> _propertiesToExclude;

        public QueryStringBuilder(string separator = ",", IEnumerable<string> propertiesToExclude = null)
        {
            _separator = separator;
            _propertiesToExclude = propertiesToExclude != null ? propertiesToExclude.ToList() : new List<string>();
        }

        public string ToQueryString(object objectToSerialise, IEnumerable<string> propertiesToExclude = null)
        {
            if (objectToSerialise == null)
            {
                throw new ArgumentNullException("objectToSerialise");
            }
            if (propertiesToExclude != null)
            {
                _propertiesToExclude.AddRange(propertiesToExclude);
            }

            // Get all properties on the object
            var properties = objectToSerialise.GetType().GetProperties()
                .Where(x => x.CanRead && !_propertiesToExclude.Contains(x.Name,StringComparison.OrdinalIgnoreCase))
                .Where(x => x.GetValue(objectToSerialise, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(objectToSerialise, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(_separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        } 
    }
}