using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.DTOs.Response;

namespace FundooNotesApp.Business.Interface
{
    public interface INoteService
    {
        Task<ApiResponseDto<NoteResponseDto>> CreateNoteAsync(CreateNoteRequestDto createNoteDto, int userId);
        Task<ApiResponseDto<string>> DeleteNoteAsync(int noteId, int userId);
    }
}