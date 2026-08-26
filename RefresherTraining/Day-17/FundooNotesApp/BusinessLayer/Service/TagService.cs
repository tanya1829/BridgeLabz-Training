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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly INoteRepository _noteRepository;

        public TagService(ITagRepository tagRepository, INoteRepository noteRepository)
        {
            _tagRepository = tagRepository;
            _noteRepository = noteRepository;
        }

        private static TagResponseDto MapToDto(Tag tag)
        {
            return new TagResponseDto
            {
                TagId = tag.TagId,
                Name = tag.Name,
                CreatedAt = tag.CreatedAt
            };
        }

        // Helper - fetches tag and verifies ownership
        private async Task<Tag> GetOwnedTagAsync(int tagId, int userId)
        {
            var tag = await _tagRepository.GetTagByIdAsync(tagId);

            if (tag == null)
                throw new TagNotFoundException("Tag not found");

            if (tag.UserId != userId)
                throw new UnauthorizedTagAccessException("You are not allowed to access this tag");

            return tag;
        }

        // Helper - fetches note and verifies ownership (reused from note-tag linking flows)
        private async Task<Note> GetOwnedNoteAsync(int noteId, int userId)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId);

            if (note == null)
                throw new NoteNotFoundException("Note not found");

            if (note.UserId != userId)
                throw new UnauthorizedNoteAccessException("You are not allowed to access this note");

            return note;
        }

        public async Task<ApiResponseDto<TagResponseDto>> CreateTagAsync(CreateTagRequestDto createTagDto, int userId)
        {
            var tag = new Tag
            {
                Name = createTagDto.Name,
                UserId = userId
            };

            await _tagRepository.AddTagAsync(tag);

            return new ApiResponseDto<TagResponseDto>
            {
                Success = true,
                Message = "Tag created successfully",
                Data = MapToDto(tag)
            };
        }

        public async Task<ApiResponseDto<List<TagResponseDto>>> GetTagsAsync(int userId)
        {
            var tags = await _tagRepository.GetTagsByUserIdAsync(userId);

            return new ApiResponseDto<List<TagResponseDto>>
            {
                Success = true,
                Message = "Tags fetched successfully",
                Data = tags.Select(MapToDto).ToList()
            };
        }

        public async Task<ApiResponseDto<string>> DeleteTagAsync(int tagId, int userId)
        {
            var tag = await GetOwnedTagAsync(tagId, userId);

            await _tagRepository.DeleteTagAsync(tag);

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Tag deleted successfully",
                Data = null
            };
        }

        // Link a tag to a note - checks ownership of both, and avoids duplicate links
        public async Task<ApiResponseDto<string>> AddTagToNoteAsync(int noteId, int tagId, int userId)
        {
            await GetOwnedNoteAsync(noteId, userId);
            await GetOwnedTagAsync(tagId, userId);

            var alreadyLinked = await _tagRepository.NoteTagExistsAsync(noteId, tagId);
            if (alreadyLinked)
            {
                return new ApiResponseDto<string>
                {
                    Success = true,
                    Message = "Tag is already linked to this note",
                    Data = null
                };
            }

            await _tagRepository.AddNoteTagAsync(new NoteTag { NoteId = noteId, TagId = tagId });

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Tag added to note successfully",
                Data = null
            };
        }

        public async Task<ApiResponseDto<string>> RemoveTagFromNoteAsync(int noteId, int tagId, int userId)
        {
            await GetOwnedNoteAsync(noteId, userId);
            await GetOwnedTagAsync(tagId, userId);

            var removed = await _tagRepository.RemoveNoteTagAsync(noteId, tagId);

            if (!removed)
                throw new TagNotFoundException("This tag is not linked to the given note");

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Tag removed from note successfully",
                Data = null
            };
        }

        public async Task<ApiResponseDto<List<NoteResponseDto>>> GetNotesByTagAsync(int tagId, int userId)
        {
            await GetOwnedTagAsync(tagId, userId);

            var notes = await _tagRepository.GetNotesByTagIdAsync(tagId, userId);

            var noteDtos = notes.Select(n => new NoteResponseDto
            {
                NoteId = n.NoteId,
                Title = n.Title,
                Description = n.Description,
                IsArchived = n.IsArchived,
                IsPinned = n.IsPinned,
                CreatedAt = n.CreatedAt
            }).ToList();

            return new ApiResponseDto<List<NoteResponseDto>>
            {
                Success = true,
                Message = "Notes fetched successfully",
                Data = noteDtos
            };
        }
    }
}