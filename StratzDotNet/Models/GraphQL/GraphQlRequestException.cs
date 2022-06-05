using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StratzDotNet.Models.GraphQl
{
    public class GraphQlRequestException : Exception
    {
        public GraphQlRequestException()
        {
        }

        public GraphQlRequestException(string message) : base(message)
        {
        }

        public GraphQlRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GraphQlRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}