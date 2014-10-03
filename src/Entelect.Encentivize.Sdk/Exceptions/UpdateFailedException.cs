using System;
using System.Runtime.Serialization;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class UpdateFailedException : EncentivizeApiException
    {
        public UpdateFailedException(IRestResponse response, string additionalInformation = null)
            : base(response, additionalInformation)
        {
        }

        public UpdateFailedException(IRestResponse response, Exception inner, string additionalInformation = null)
            : base(response, inner, additionalInformation)
        {
        }

        protected UpdateFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}