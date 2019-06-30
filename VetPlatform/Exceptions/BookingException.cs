using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace VetPlatform.Api.Exceptions
{
    public class BookingException : Exception
    {
        public BookingException()
        {
        }

        public BookingException(string message) : base(message)
        {
        }

        public BookingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
