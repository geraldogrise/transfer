using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BR.Rodobens.Migration.Domain.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException(string message)
           : base(message)
        {
        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
