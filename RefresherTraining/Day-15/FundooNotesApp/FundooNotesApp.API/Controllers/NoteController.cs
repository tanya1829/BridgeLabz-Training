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

        // POST api/notes
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequestDto createNoteDto)
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.CreateNoteAsync(createNoteDto, userId);
            return Ok(result);
        }

        // GET api/notes
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.GetNotesAsync(userId);
            return Ok(result);
        }

        // DELETE api/notes/{id}  -> moves note to trash (soft delete)
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

        // DELETE api/notes/{id}/permanent  -> permanently deletes a trashed note
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

        // GET api/notes/trash  -> list trashed notes
        [HttpGet("trash")]
        public async Task<IActionResult> GetTrash()
        {
            var userId = GetCurrentUserId();
            var result = await _noteService.GetTrashAsync(userId);
            return Ok(result);
        }

        // PATCH api/notes/{id}/restore  -> restore note from trash
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

        // PATCH api/notes/{id}/pin  -> toggle pin status
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
        // GET api/notes/search?query=A
[HttpGet("search")]
public async Task<IActionResult> SearchNotes([FromQuery] string query)
{
    var userId = GetCurrentUserId();
    var result = await _noteService.SearchNotesAsync(userId, query);
    return Ok(result);
}
    }
}