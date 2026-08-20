using System.Collections.Generic;
using System.Linq;
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

        public async Task<Note> AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note> GetNoteByIdAsync(int noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId);
        }

        // Permanent delete - actually removes the row from database
        public async Task<bool> DeleteNoteAsync(Note note)
        {
            _context.Notes.Remove(note);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        // Active notes only - excludes trashed notes
        public async Task<List<Note>> GetNotesByUserIdAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && !n.IsTrashed)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        // Only trashed notes for this user
        public async Task<List<Note>> GetTrashedNotesByUserIdAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && n.IsTrashed)
                .OrderByDescending(n => n.TrashedAt)
                .ToListAsync();
        }

        // Generic update - used for trash/restore/pin toggle
        public async Task<Note> UpdateNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }
        // Search notes by title or description (case-insensitive, partial match)
public async Task<List<Note>> SearchNotesAsync(int userId, string searchTerm)
{
    return await _context.Notes
        .Where(n => n.UserId == userId
                 && !n.IsTrashed
                 && (n.Title.Contains(searchTerm) || n.Description.Contains(searchTerm)))
        .OrderByDescending(n => n.CreatedAt)
        .ToListAsync();
}
    }
}