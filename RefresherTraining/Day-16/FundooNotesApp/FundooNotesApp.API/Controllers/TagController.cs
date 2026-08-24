using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundooNotesApp.Business.Interface;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.DTOs.Response;
using FundooNotesApp.ModelLayer.Exceptions;

namespace FundooNotesApp.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdClaim);
        }

        /// <summary>
        /// Creates a new tag for the logged-in user.
        /// </summary>
        /// <param name="createTagDto">Name of the tag (e.g. "Work", "Personal").</param>
        /// <returns>The newly created tag.</returns>
        /// <response code="200">Tag created successfully.</response>
        /// <response code="401">Missing or invalid JWT token.</response>
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagRequestDto createTagDto)
        {
            var userId = GetCurrentUserId();
            var result = await _tagService.CreateTagAsync(createTagDto, userId);
            return Ok(result);
        }

        /// <summary>
        /// Gets all tags created by the logged-in user.
        /// </summary>
        /// <returns>List of the user's tags.</returns>
        /// <response code="200">Tags fetched successfully.</response>
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var userId = GetCurrentUserId();
            var result = await _tagService.GetTagsAsync(userId);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a tag.
        /// </summary>
        /// <param name="id">The tag's ID.</param>
        /// <response code="200">Tag deleted successfully.</response>
        /// <response code="403">Tag belongs to another user.</response>
        /// <response code="404">Tag not found.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _tagService.DeleteTagAsync(id, userId);
                return Ok(result);
            }
            catch (TagNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedTagAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Links a tag to a note.
        /// </summary>
        /// <param name="noteId">The note's ID.</param>
        /// <param name="tagId">The tag's ID.</param>
        /// <response code="200">Tag added to note successfully (or was already linked).</response>
        /// <response code="403">Note or tag belongs to another user.</response>
        /// <response code="404">Note or tag not found.</response>
        [HttpPost("~/api/notes/{noteId}/tags/{tagId}")]
        public async Task<IActionResult> AddTagToNote(int noteId, int tagId)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _tagService.AddTagToNoteAsync(noteId, tagId, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (TagNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedTagAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Removes a tag from a note.
        /// </summary>
        /// <param name="noteId">The note's ID.</param>
        /// <param name="tagId">The tag's ID.</param>
        /// <response code="200">Tag removed from note successfully.</response>
        /// <response code="403">Note or tag belongs to another user.</response>
        /// <response code="404">Note not found, tag not found, or tag was not linked to this note.</response>
        [HttpDelete("~/api/notes/{noteId}/tags/{tagId}")]
        public async Task<IActionResult> RemoveTagFromNote(int noteId, int tagId)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _tagService.RemoveTagFromNoteAsync(noteId, tagId, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (TagNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedTagAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all notes that have a specific tag.
        /// </summary>
        /// <param name="tagId">The tag's ID.</param>
        /// <returns>List of notes linked to this tag.</returns>
        /// <response code="200">Notes fetched successfully.</response>
        /// <response code="403">Tag belongs to another user.</response>
        /// <response code="404">Tag not found.</response>
        [HttpGet("~/api/notes/tag/{tagId}")]
        public async Task<IActionResult> GetNotesByTag(int tagId)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _tagService.GetNotesByTagAsync(tagId, userId);
                return Ok(result);
            }
            catch (TagNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedTagAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }
    }
}