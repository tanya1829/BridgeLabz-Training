using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    // Thrown when a user lookup (by email/id) fails
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}