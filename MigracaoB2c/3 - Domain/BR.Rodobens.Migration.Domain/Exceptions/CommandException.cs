using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BR.Rodobens.Migration.Domain.Exceptions
{
    [Serializable]
    public class CommandException : Exception
    {
        public CommandException(string message)
           : base(message)
        {
        }

        public CommandException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
