namespace FundooNotesApp.ModelLayer.Entities
{
    // Join entity - links a Note to a Tag (many-to-many relationship)
    public class NoteTag
    {
        public int NoteId { get; set; }
        public int TagId { get; set; }
    }
}