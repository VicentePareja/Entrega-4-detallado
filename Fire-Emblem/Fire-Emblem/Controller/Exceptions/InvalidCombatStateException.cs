using System;

namespace Fire_Emblem
{
    public class InvalidCombatStateException : Exception
    {
        public InvalidCombatStateException(string message) : base(message)
        {
        }
    }
}