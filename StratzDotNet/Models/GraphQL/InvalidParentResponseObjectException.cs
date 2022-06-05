using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StratzDotNet.Models.GraphQl
{
    public class InvalidParentResponseObjectException : Exception
    {
        public InvalidParentResponseObjectException()
        {
        }

        public InvalidParentResponseObjectException(string message) : base(message)
        {
        }

        public InvalidParentResponseObjectException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidParentResponseObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}