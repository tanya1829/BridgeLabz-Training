using System;

namespace FundooNotesApp.ModelLayer.Entities
{
    // Tag entity - represents a label a user can create (e.g. "Work", "Personal")
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }                   // tag belongs to a specific user
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}