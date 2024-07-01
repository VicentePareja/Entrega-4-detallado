using System;

namespace Fire_Emblem
{
    public class FileReadException : Exception
    {
        public FileReadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}