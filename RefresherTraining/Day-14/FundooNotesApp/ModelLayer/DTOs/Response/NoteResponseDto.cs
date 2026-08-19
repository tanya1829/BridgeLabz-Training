using System;

namespace FundooNotesApp.ModelLayer.DTOs.Response
{
    public class NoteResponseDto
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public bool IsPinned { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}