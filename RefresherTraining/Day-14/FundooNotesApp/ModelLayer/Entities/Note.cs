using System;

namespace FundooNotesApp.ModelLayer.Entities
{
    // Note entity - maps to Notes table in database
    public class Note
    {
        public int NoteId { get; set; }                  // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; } = false;     // future use - archive feature
        public bool IsPinned { get; set; } = false;       // future use - pin feature
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Foreign Key - links this note to the user who created it
        public int UserId { get; set; }
    }
}