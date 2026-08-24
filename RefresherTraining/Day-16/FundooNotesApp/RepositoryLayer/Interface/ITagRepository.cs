using System.Collections.Generic;
using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    public interface ITagRepository
    {
        Task<Tag> AddTagAsync(Tag tag);
        Task<Tag> GetTagByIdAsync(int tagId);
        Task<List<Tag>> GetTagsByUserIdAsync(int userId);
        Task<bool> DeleteTagAsync(Tag tag);

        // Note-Tag linking operations
        Task AddNoteTagAsync(NoteTag noteTag);
        Task<bool> RemoveNoteTagAsync(int noteId, int tagId);
        Task<bool> NoteTagExistsAsync(int noteId, int tagId);
        Task<List<Note>> GetNotesByTagIdAsync(int tagId, int userId);
    }
}