using System;

namespace Fire_Emblem
{
    public class DeserializationException : Exception
    {
        public DeserializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}