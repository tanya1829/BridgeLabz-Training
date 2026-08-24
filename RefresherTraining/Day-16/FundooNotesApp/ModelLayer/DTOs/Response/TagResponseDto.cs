using System;

namespace FundooNotesApp.ModelLayer.DTOs.Response
{
    public class TagResponseDto
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}