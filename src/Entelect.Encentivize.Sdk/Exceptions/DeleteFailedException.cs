using System;
using System.Runtime.Serialization;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class DeleteFailedException: EncentivizeApiException
    {
        public DeleteFailedException(IRestResponse response, string additionalInformation = null)
            : base(response, additionalInformation)
        {
        }

        public DeleteFailedException(IRestResponse response, Exception inner, string additionalInformation = null)
            : base(response, inner, additionalInformation)
        {
        }

        protected DeleteFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}