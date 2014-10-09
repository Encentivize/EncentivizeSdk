using System;
using System.Runtime.Serialization;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class CreationFailedException: EncentivizeApiException
    {
        public CreationFailedException(IRestResponse response, string additionalInformation = null)
            : base(response, additionalInformation)
        {
        }

        public CreationFailedException(IRestResponse response, Exception inner, string additionalInformation = null)
            : base(response, inner, additionalInformation)
        {
        }

        protected CreationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}