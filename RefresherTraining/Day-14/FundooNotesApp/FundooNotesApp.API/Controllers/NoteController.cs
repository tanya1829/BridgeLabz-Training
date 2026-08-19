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
    [Authorize]   // saara controller protected - koi bhi note-action bina valid token ke nahi ho sakta
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // Helper method - extracts UserId from the JWT token claims
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

        // DELETE api/notes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var userId = GetCurrentUserId();

            try
            {
                var result = await _noteService.DeleteNoteAsync(id, userId);
                return Ok(result);
            }
            catch (NoteNotFoundException ex)
            {
                return NotFound(new ApiResponseDto<string> { Success = false, Message = ex.Message });
            }
            catch (UnauthorizedNoteAccessException ex)
            {
                return StatusCode(403, new ApiResponseDto<string> { Success = false, Message = ex.Message });   // 403 Forbidden
            }
        }
    }
}