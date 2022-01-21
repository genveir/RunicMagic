using System;
using System.Runtime.Serialization;

namespace World.Magic
{
    [Serializable]
    internal class RuneParseException : Exception
    {
        public RuneParseException()
        {
        }

        public RuneParseException(string? message) : base(message)
        {
        }

        public RuneParseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RuneParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}