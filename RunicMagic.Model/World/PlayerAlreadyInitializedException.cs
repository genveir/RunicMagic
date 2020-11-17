using System;
using System.Runtime.Serialization;

namespace RunicMagic.Model.World
{
    [Serializable]
    internal class PlayerAlreadyInitializedException : Exception
    {
        public PlayerAlreadyInitializedException()
        {
        }

        public PlayerAlreadyInitializedException(string message) : base(message)
        {
        }

        public PlayerAlreadyInitializedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerAlreadyInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}