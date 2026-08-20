using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    // Thrown during login when email/password don't match
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message) : base(message) { }
    }
}