using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    // Thrown during registration when email is already taken
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message) : base(message) { }
    }
}