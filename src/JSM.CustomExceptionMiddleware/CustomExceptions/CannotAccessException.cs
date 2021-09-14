using System;
using System.Runtime.Serialization;

namespace JSM.CustomExceptionMiddleware.CustomExceptions
{
    [Serializable]
    public class CannotAccessException : Exception
    {
        public CannotAccessException(string message) : base(message)
        { }

        protected CannotAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
