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
    [Route("api/notes")]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userIdClaim);
        }

        /// <summary>
        /// Creates a new note for the logged-in user.
        /// </summary>
        /// <param name="createNoteDto">Title and description of the note.</param>
        /// <returns>The newly created note.</returns>
        /// <response code="200">Note created successfully.</response>
        /// <response code="401">Missing or invalid JWT token.</response>
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequestDto createNoteDto)
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.CreateNoteAsync(createNoteDto, userId);
            return Ok(result);
        }

        /// <summary>
        /// Gets all active (non-trashed) notes for the logged-in user.
        /// </summary>
        /// <returns>List of active notes.</returns>
        /// <response code="200">Notes fetched successfully.</response>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.GetNotesAsync(userId);
            return Ok(result);
        }

        /// <summary>
        /// Moves a note to trash (soft delete).
        /// </summary>
        /// <param name="id">The note's ID.</param>
        /// <response code="200">Note moved to trash.</response>
        /// <response code="403">Note belongs to another user.</response>
        /// <response code="404">Note not found.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> MoveToTrash(int id)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _noteService.MoveToTrashAsync(id, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Permanently deletes a note. The note must already be in trash.
        /// </summary>
        /// <param name="id">The note's ID.</param>
        /// <response code="200">Note permanently deleted.</response>
        /// <response code="400">Note is not in trash yet.</response>
        /// <response code="403">Note belongs to another user.</response>
        /// <response code="404">Note not found.</response>
        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> DeletePermanent(int id)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _noteService.DeletePermanentAsync(id, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (InvalidNoteOperationException ex)
            {
                return BadRequest(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all trashed notes for the logged-in user.
        /// </summary>
        /// <returns>List of trashed notes.</returns>
        /// <response code="200">Trashed notes fetched successfully.</response>
        [HttpGet("trash")]
        public async Task<IActionResult> GetTrash()
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.GetTrashAsync(userId);
            return Ok(result);
        }

        /// <summary>
        /// Restores a note from trash back to active notes.
        /// </summary>
        /// <param name="id">The note's ID.</param>
        /// <response code="200">Note restored from trash.</response>
        /// <response code="403">Note belongs to another user.</response>
        /// <response code="404">Note not found.</response>
        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> RestoreFromTrash(int id)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _noteService.RestoreFromTrashAsync(id, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Toggles the pin status of a note (pinned becomes unpinned, and vice versa).
        /// </summary>
        /// <param name="id">The note's ID.</param>
        /// <returns>The updated note with its new pin status.</returns>
        /// <response code="200">Pin status toggled successfully.</response>
        /// <response code="403">Note belongs to another user.</response>
        /// <response code="404">Note not found.</response>
        [HttpPatch("{id}/pin")]
        public async Task<IActionResult> TogglePin(int id)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _noteService.TogglePinAsync(id, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Searches active notes by title or description (partial, case-insensitive match).
        /// </summary>
        /// <param name="query">The search term.</param>
        /// <returns>List of matching notes. Returns all active notes if query is empty.</returns>
        /// <response code="200">Search completed successfully.</response>
        [HttpGet("search")]
        public async Task<IActionResult> SearchNotes([FromQuery] string query)
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.SearchNotesAsync(userId, query);
            return Ok(result);
        }

        /// <summary>
        /// Sets a reminder for a note. A background worker will process it when the time arrives.
        /// </summary>
        /// <param name="id">The note's ID.</param>
        /// <param name="reminderDto">The date/time the reminder should trigger.</param>
        /// <response code="200">Reminder set successfully.</response>
        /// <response code="403">Note belongs to another user.</response>
        /// <response code="404">Note not found.</response>
        [HttpPost("{id}/reminder")]
        public async Task<IActionResult> SetReminder(int id, [FromBody] SetReminderRequestDto reminderDto)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _noteService.SetReminderAsync(id, reminderDto.ReminderDateTime, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
        }
    }
}