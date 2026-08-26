using System;

namespace FundooNotesApp.ModelLayer.DTOs.Response
{
    // This is the "message" that gets serialized and sent through RabbitMQ
    public class ReminderMessageDto
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime ReminderDateTime { get; set; }
    }
}