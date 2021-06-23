using System;
using System.Runtime.Serialization;

namespace BR.ITAU.TRANSFER.API.Domain.Exceptions
{
    [Serializable]
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string message)
            : base(message)
        {
        }

        public ValidacaoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ValidacaoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
