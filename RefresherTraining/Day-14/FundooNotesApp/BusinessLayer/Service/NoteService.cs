using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.DTOs.Response;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Repository;
using FundooNotesApp.Business.Interface;

namespace FundooNotesApp.Business.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Create a new note for the logged-in user
        public async Task<ApiResponseDto<NoteResponseDto>> CreateNoteAsync(CreateNoteRequestDto createNoteDto, int userId)
        {
            var note = new Note
            {
                Title = createNoteDto.Title,
                Description = createNoteDto.Description,
                UserId = userId   // note ko current logged-in user ke saath link kiya
            };

            await _noteRepository.AddNoteAsync(note);

            return new ApiResponseDto<NoteResponseDto>
            {
                Success = true,
                Message = "Note created successfully",
                Data = new NoteResponseDto
                {
                    NoteId = note.NoteId,
                    Title = note.Title,
                    Description = note.Description,
                    IsArchived = note.IsArchived,
                    IsPinned = note.IsPinned,
                    CreatedAt = note.CreatedAt
                }
            };
        }

        // Delete a note - only if it belongs to the logged-in user
        public async Task<ApiResponseDto<string>> DeleteNoteAsync(int noteId, int userId)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
            {
                throw new NoteNotFoundException("Note not found");
            }

            // Ownership check - prevent deleting someone else's note
            if (note.UserId != userId)
            {
                throw new UnauthorizedNoteAccessException("You are not allowed to delete this note");
            }

            await _noteRepository.DeleteNoteAsync(note);

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Note deleted successfully",
                Data = null
            };
        }
    }
}