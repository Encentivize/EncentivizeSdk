using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace Entelect.Encentivize.Sdk
{
    public class DynamicJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            if (typeof(T).Name.Equals("Objet",StringComparison.OrdinalIgnoreCase))
            {
                return JsonConvert.DeserializeObject<dynamic>(response.Content);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
