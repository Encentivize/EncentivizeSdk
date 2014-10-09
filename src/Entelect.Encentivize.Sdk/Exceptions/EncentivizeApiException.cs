using System;
using System.Runtime.Serialization;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public abstract class EncentivizeApiException : Exception
    {
        protected EncentivizeApiException(IRestResponse response, string additionalInformation = null)
            : base(GetErrorMessage(response, additionalInformation))
        {
        }

        protected EncentivizeApiException(IRestResponse response, Exception inner, string additionalInformation = null)
            : base(GetErrorMessage(response, additionalInformation), inner)
        {
        }

        protected EncentivizeApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected static string GetErrorMessage(IRestResponse response, string additionalInformation)
        {
            return string.Format("Error response returned ({0} :{1}), Content: {2}", (int)response.StatusCode, response.StatusCode, response.Content);
        }
    }
}
