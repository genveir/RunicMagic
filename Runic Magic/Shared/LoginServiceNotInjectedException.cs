using System;
using System.Runtime.Serialization;

namespace Runic_Magic.Shared
{
    [Serializable]
    internal class LoginServiceNotInjectedException : Exception
    {
        public LoginServiceNotInjectedException()
        {
        }

        public LoginServiceNotInjectedException(string? message) : base(message)
        {
        }

        public LoginServiceNotInjectedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LoginServiceNotInjectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}