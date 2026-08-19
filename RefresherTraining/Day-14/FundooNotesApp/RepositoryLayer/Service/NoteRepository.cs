using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly FundooDbContext _context;

        public NoteRepository(FundooDbContext context)
        {
            _context = context;
        }

        // Add new note to database
        public async Task<Note> AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        // Fetch note by id - used to check ownership before delete
        public async Task<Note> GetNoteByIdAsync(int noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId);
        }

        // Delete note from database
        public async Task<bool> DeleteNoteAsync(Note note)
        {
            _context.Notes.Remove(note);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}