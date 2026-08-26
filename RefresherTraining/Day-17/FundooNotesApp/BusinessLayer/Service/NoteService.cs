using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRabbitMqProducerService _rabbitMqProducer;

        public NoteService(INoteRepository noteRepository, IRabbitMqProducerService rabbitMqProducer)
        {
            _noteRepository = noteRepository;
            _rabbitMqProducer = rabbitMqProducer;
        }

        // Helper - converts entity to response DTO (avoids repeating this mapping everywhere)
        private static NoteResponseDto MapToDto(Note note)
        {
            return new NoteResponseDto
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Description = note.Description,
                IsArchived = note.IsArchived,
                IsPinned = note.IsPinned,
                CreatedAt = note.CreatedAt
            };
        }

        // Helper - fetches note and verifies ownership, throws if not found/not owned
        private async Task<Note> GetOwnedNoteAsync(int noteId, int userId)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
                throw new NoteNotFoundException("Note not found");

            if (note.UserId != userId)
                throw new UnauthorizedNoteAccessException("You are not allowed to access this note");

            return note;
        }

        public async Task<ApiResponseDto<NoteResponseDto>> CreateNoteAsync(CreateNoteRequestDto createNoteDto, int userId)
        {
            var note = new Note
            {
                Title = createNoteDto.Title,
                Description = createNoteDto.Description,
                UserId = userId
            };

            await _noteRepository.AddNoteAsync(note);

            return new ApiResponseDto<NoteResponseDto>
            {
                Success = true,
                Message = "Note created successfully",
                Data = MapToDto(note)
            };
        }

        public async Task<ApiResponseDto<List<NoteResponseDto>>> GetNotesAsync(int userId)
        {
            var notes = await _noteRepository.GetNotesByUserIdAsync(userId);

            return new ApiResponseDto<List<NoteResponseDto>>
            {
                Success = true,
                Message = "Notes fetched successfully",
                Data = notes.Select(MapToDto).ToList()
            };
        }

        // Soft delete - moves note to trash instead of removing it
        public async Task<ApiResponseDto<string>> MoveToTrashAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteAsync(noteId, userId);

            note.IsTrashed = true;
            note.TrashedAt = DateTime.Now;

            await _noteRepository.UpdateNoteAsync(note);

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Note moved to trash",
                Data = null
            };
        }

        // Hard delete - removes note permanently (only allowed from trash)
        public async Task<ApiResponseDto<string>> DeletePermanentAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteAsync(noteId, userId);

            if (!note.IsTrashed)
                throw new InvalidNoteOperationException("Note must be in trash before it can be permanently deleted");

            await _noteRepository.DeleteNoteAsync(note);

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Note permanently deleted",
                Data = null
            };
        }

        // List all trashed notes for the logged-in user
        public async Task<ApiResponseDto<List<NoteResponseDto>>> GetTrashAsync(int userId)
        {
            var notes = await _noteRepository.GetTrashedNotesByUserIdAsync(userId);

            return new ApiResponseDto<List<NoteResponseDto>>
            {
                Success = true,
                Message = "Trashed notes fetched successfully",
                Data = notes.Select(MapToDto).ToList()
            };
        }

        // Restore a note from trash back to active notes
        public async Task<ApiResponseDto<string>> RestoreFromTrashAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteAsync(noteId, userId);

            note.IsTrashed = false;
            note.TrashedAt = null;

            await _noteRepository.UpdateNoteAsync(note);

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Note restored from trash",
                Data = null
            };
        }

        // Search active notes by title/description
        public async Task<ApiResponseDto<List<NoteResponseDto>>> SearchNotesAsync(int userId, string searchTerm)
        {
            // If search box is empty, just return all active notes
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetNotesAsync(userId);
            }

            var notes = await _noteRepository.SearchNotesAsync(userId, searchTerm);

            return new ApiResponseDto<List<NoteResponseDto>>
            {
                Success = true,
                Message = $"Found {notes.Count} note(s) matching '{searchTerm}'",
                Data = notes.Select(MapToDto).ToList()
            };
        }

        // Toggle pin status (true -> false, false -> true)
        public async Task<ApiResponseDto<NoteResponseDto>> TogglePinAsync(int noteId, int userId)
        {
            var note = await GetOwnedNoteAsync(noteId, userId);

            note.IsPinned = !note.IsPinned;

            await _noteRepository.UpdateNoteAsync(note);

            return new ApiResponseDto<NoteResponseDto>
            {
                Success = true,
                Message = note.IsPinned ? "Note pinned" : "Note unpinned",
                Data = MapToDto(note)
            };
        }

        // Sets a reminder for a note and publishes it to RabbitMQ for background processing
        public async Task<ApiResponseDto<string>> SetReminderAsync(int noteId, DateTime reminderDateTime, int userId)
        {
            var note = await GetOwnedNoteAsync(noteId, userId);

            note.ReminderDateTime = reminderDateTime;
            note.IsReminderSent = false;   // reset in case reminder is being rescheduled

            await _noteRepository.UpdateNoteAsync(note);

            // Publish to RabbitMQ - the background consumer will pick this up when the time comes
            await _rabbitMqProducer.PublishReminderAsync(new ReminderMessageDto
            {
                NoteId = note.NoteId,
                UserId = note.UserId,
                Title = note.Title,
                ReminderDateTime = reminderDateTime
            });

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Reminder set successfully",
                Data = null
            };
        }
    }
}