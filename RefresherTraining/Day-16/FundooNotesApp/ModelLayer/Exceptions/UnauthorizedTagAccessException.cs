using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    public class UnauthorizedTagAccessException : Exception
    {
        public UnauthorizedTagAccessException(string message) : base(message) { }
    }
}