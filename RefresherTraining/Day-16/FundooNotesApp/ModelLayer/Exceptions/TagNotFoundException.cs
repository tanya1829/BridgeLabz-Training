using System;

namespace FundooNotesApp.ModelLayer.Exceptions
{
    public class TagNotFoundException : Exception
    {
        public TagNotFoundException(string message) : base(message) { }
    }
}