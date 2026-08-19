using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    public interface INoteRepository
    {
        Task<Note> AddNoteAsync(Note note);
        Task<Note> GetNoteByIdAsync(int noteId);
        Task<bool> DeleteNoteAsync(Note note);
    }
}