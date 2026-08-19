using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    // Thrown when reset token is invalid or expired
    public class InvalidResetTokenException : Exception
    {
        public InvalidResetTokenException(string message) : base(message) { }
    }
}