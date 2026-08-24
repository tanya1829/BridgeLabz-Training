using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly FundooDbContext _context;

        public TagRepository(FundooDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> GetTagByIdAsync(int tagId)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.TagId == tagId);
        }

        public async Task<List<Tag>> GetTagsByUserIdAsync(int userId)
        {
            return await _context.Tags
                .Where(t => t.UserId == userId)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<bool> DeleteTagAsync(Tag tag)
        {
            _context.Tags.Remove(tag);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        // Link a tag to a note
        public async Task AddNoteTagAsync(NoteTag noteTag)
        {
            _context.NoteTags.Add(noteTag);
            await _context.SaveChangesAsync();
        }

        // Unlink a tag from a note
        public async Task<bool> RemoveNoteTagAsync(int noteId, int tagId)
        {
            var noteTag = await _context.NoteTags
                .FirstOrDefaultAsync(nt => nt.NoteId == noteId && nt.TagId == tagId);

            if (noteTag == null)
                return false;

            _context.NoteTags.Remove(noteTag);
            await _context.SaveChangesAsync();
            return true;
        }

        // Check if a note already has this tag (avoid duplicate linking)
        public async Task<bool> NoteTagExistsAsync(int noteId, int tagId)
        {
            return await _context.NoteTags
                .AnyAsync(nt => nt.NoteId == noteId && nt.TagId == tagId);
        }

        // Get all notes that have a specific tag, for a specific user
        public async Task<List<Note>> GetNotesByTagIdAsync(int tagId, int userId)
        {
            return await (
                from note in _context.Notes
                join noteTag in _context.NoteTags on note.NoteId equals noteTag.NoteId
                where noteTag.TagId == tagId && note.UserId == userId && !note.IsTrashed
                select note
            ).ToListAsync();
        }
    }
}