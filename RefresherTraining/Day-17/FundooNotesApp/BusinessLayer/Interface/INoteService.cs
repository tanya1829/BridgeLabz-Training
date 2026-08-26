using System.Collections.Generic;
using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.DTOs.Request;
using System;
using FundooNotesApp.ModelLayer.DTOs.Response;

namespace FundooNotesApp.Business.Interface
{
    public interface INoteService
    {
        Task<ApiResponseDto<NoteResponseDto>> CreateNoteAsync(CreateNoteRequestDto createNoteDto, int userId);
        Task<ApiResponseDto<List<NoteResponseDto>>> GetNotesAsync(int userId);
        Task<ApiResponseDto<string>> MoveToTrashAsync(int noteId, int userId);           // - soft delete
        Task<ApiResponseDto<string>> DeletePermanentAsync(int noteId, int userId);       // - hard delete
        Task<ApiResponseDto<List<NoteResponseDto>>> GetTrashAsync(int userId);           //  - trash list
        Task<ApiResponseDto<string>> RestoreFromTrashAsync(int noteId, int userId);      // - retrive from trash
        Task<ApiResponseDto<NoteResponseDto>> TogglePinAsync(int noteId, int userId);    //  - pin/unpin
        Task<ApiResponseDto<List<NoteResponseDto>>> SearchNotesAsync(int userId, string searchTerm);
        Task<ApiResponseDto<string>> SetReminderAsync(int noteId, DateTime reminderDateTime, int userId);
    }
}