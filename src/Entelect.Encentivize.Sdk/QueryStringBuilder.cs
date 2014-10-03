using System;
using System.Collections;
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

        public QueryStringBuilder(string separator = ",")
        {
            _separator = separator;
        }

        public string ToQueryString(object objectToSerialise)
        {
            if (objectToSerialise == null)
            {
                throw new ArgumentNullException("objectToSerialise");
            }

            // Get all properties on the object
            var properties = objectToSerialise.GetType().GetProperties()
                .Where(x => x.CanRead)
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