using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    // Thrown when an operation is attempted in an invalid state (e.g. permanent-delete on a non-trashed note)
    public class InvalidNoteOperationException : Exception
    {
        public InvalidNoteOperationException(string message) : base(message) { }
    }
}