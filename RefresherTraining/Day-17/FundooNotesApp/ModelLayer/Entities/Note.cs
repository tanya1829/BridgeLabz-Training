using System;

namespace FundooNotesApp.ModelLayer.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; } = false;
        public bool IsPinned { get; set; } = false;
        public bool IsTrashed { get; set; } = false;
        public DateTime? TrashedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // New fields for reminder feature
        public DateTime? ReminderDateTime { get; set; }     // when the reminder should trigger
        public bool IsReminderSent { get; set; } = false;   // tracks whether notification has been sent

        public int UserId { get; set; }
    }
}