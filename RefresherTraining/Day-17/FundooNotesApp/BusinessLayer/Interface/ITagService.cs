using System.Collections.Generic;
using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.DTOs.Response;

namespace FundooNotesApp.Business.Interface
{
    public interface ITagService
    {
        Task<ApiResponseDto<TagResponseDto>> CreateTagAsync(CreateTagRequestDto createTagDto, int userId);
        Task<ApiResponseDto<List<TagResponseDto>>> GetTagsAsync(int userId);
        Task<ApiResponseDto<string>> DeleteTagAsync(int tagId, int userId);

        Task<ApiResponseDto<string>> AddTagToNoteAsync(int noteId, int tagId, int userId);
        Task<ApiResponseDto<string>> RemoveTagFromNoteAsync(int noteId, int tagId, int userId);
        Task<ApiResponseDto<List<NoteResponseDto>>> GetNotesByTagAsync(int tagId, int userId);
    }
}