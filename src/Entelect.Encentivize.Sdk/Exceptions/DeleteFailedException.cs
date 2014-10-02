using System;
using System.Runtime.Serialization;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class DeleteFailedException: EncentivizeApiException
    {
         public DeleteFailedException(string message)
            : base(message)
        {
        }

        public DeleteFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DeleteFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}