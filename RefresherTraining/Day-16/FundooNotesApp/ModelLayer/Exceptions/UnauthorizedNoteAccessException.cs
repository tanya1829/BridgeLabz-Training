using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    // Thrown when a user tries to access/delete a note that isn't theirs
    public class UnauthorizedNoteAccessException : Exception
    {
        public UnauthorizedNoteAccessException(string message) : base(message) { }
    }
}