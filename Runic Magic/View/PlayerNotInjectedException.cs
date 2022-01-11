using System;
using System.Runtime.Serialization;

namespace Runic_Magic.View
{
    [Serializable]
    internal class PlayerNotInjectedException : Exception
    {
        public PlayerNotInjectedException()
        {
        }

        public PlayerNotInjectedException(string? message) : base(message)
        {
        }

        public PlayerNotInjectedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlayerNotInjectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}