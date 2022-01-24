using System;
using System.Runtime.Serialization;

namespace World.Magic
{
    [Serializable]
    internal class SpellParsingException : Exception
    {
        public SpellParsingException()
        {
        }

        public SpellParsingException(string? message) : base(message)
        {
        }

        public SpellParsingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SpellParsingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}