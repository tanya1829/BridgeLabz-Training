using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    public interface INoteRepository
    {
        Task<Note> AddNoteAsync(Note note);
        Task<Note> GetNoteByIdAsync(int noteId);
        Task<bool> DeleteNoteAsync(Note note);
        Task<List<Note>> GetNotesByUserIdAsync(int userId);  // active notes (not trashed)
        Task<List<Note>> GetTrashedNotesByUserIdAsync(int userId);
        Task<Note> UpdateNoteAsync(Note note); 
        Task<List<Note>> SearchNotesAsync(int userId, string searchTerm);
    }
}