using System;
using System.Runtime.Serialization;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class IdNotSetException: Exception
    {
        public IdNotSetException(string entityName, string verb)
            : base(GetMessage(entityName, verb))
        {
        }


        public IdNotSetException(string entityName, string verb, Exception innerException)
            : base(GetMessage(entityName, verb), innerException)
        {
        }

        protected IdNotSetException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }


        private static string GetMessage(string entityName, string verb)
        {
            return string.Format("Unable to {0} the {1} as the id has not been set", verb, entityName);
        }
    }
}