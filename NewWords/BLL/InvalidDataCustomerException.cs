using System;
using System.Runtime.Serialization;

namespace BLL
{
    [Serializable]
    public class InvalidDataCustomerException : Exception
    {
        public InvalidDataCustomerException() { }

        public InvalidDataCustomerException(string message)
            : base(message) { }

        public InvalidDataCustomerException(string message, Exception innerException)
            : base(message, innerException) { }

        protected InvalidDataCustomerException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}