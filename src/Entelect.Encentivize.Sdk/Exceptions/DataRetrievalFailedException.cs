using System;
using System.Runtime.Serialization;
using RestSharp;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class DataRetrievalFailedException: EncentivizeApiException
    {
        public DataRetrievalFailedException(IRestResponse response, string additionalInformation = null)
            : base(response, additionalInformation)
        {
        }

        public DataRetrievalFailedException(IRestResponse response, Exception inner, string additionalInformation = null)
            : base(response, inner, additionalInformation)
        {
        }

        protected DataRetrievalFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}