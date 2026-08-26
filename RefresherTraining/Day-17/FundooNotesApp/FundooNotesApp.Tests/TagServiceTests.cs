using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Repository;
using FundooNotesApp.Business.Service;

namespace FundooNotesApp.Tests
{
    [TestClass]
    public class TagServiceTests
    {
        private Mock<ITagRepository> _mockTagRepository;
        private Mock<INoteRepository> _mockNoteRepository;
        private TagService _tagService;

        [TestInitialize]
        public void Setup()
        {
            _mockTagRepository = new Mock<ITagRepository>();
            _mockNoteRepository = new Mock<INoteRepository>();
            _tagService = new TagService(_mockTagRepository.Object, _mockNoteRepository.Object);
        }

        [TestMethod]
        public async Task CreateTagAsync_ValidData_ReturnsSuccess()
        {
            // Arrange
            var createDto = new CreateTagRequestDto { Name = "Work" };

            // Act
            var result = await _tagService.CreateTagAsync(createDto, userId: 1);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Work", result.Data.Name);
        }

        [TestMethod]
        public async Task DeleteTagAsync_TagNotFound_ThrowsTagNotFoundException()
        {
            // Arrange
            _mockTagRepository.Setup(repo => repo.GetTagByIdAsync(It.IsAny<int>())).ReturnsAsync((Tag)null);

            // Act & Assert
            await Assert.ThrowsExactlyAsync<TagNotFoundException>(
                () => _tagService.DeleteTagAsync(tagId: 99, userId: 1)
            );
        }

        [TestMethod]
        public async Task DeleteTagAsync_TagBelongsToAnotherUser_ThrowsUnauthorizedTagAccessException()
        {
            // Arrange - tag exists but belongs to user 2, not user 1
            var tag = new Tag { TagId = 3, UserId = 2, Name = "Personal" };
            _mockTagRepository.Setup(repo => repo.GetTagByIdAsync(3)).ReturnsAsync(tag);

            // Act & Assert
            await Assert.ThrowsExactlyAsync<UnauthorizedTagAccessException>(
                () => _tagService.DeleteTagAsync(tagId: 3, userId: 1)
            );
        }

        [TestMethod]
        public async Task AddTagToNoteAsync_ValidOwnership_LinksSuccessfully()
        {
            // Arrange - both note and tag belong to user 1
            var note = new Note { NoteId = 10, UserId = 1 };
            var tag = new Tag { TagId = 3, UserId = 1 };

            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(10)).ReturnsAsync(note);
            _mockTagRepository.Setup(repo => repo.GetTagByIdAsync(3)).ReturnsAsync(tag);
            _mockTagRepository.Setup(repo => repo.NoteTagExistsAsync(10, 3)).ReturnsAsync(false);

            // Act
            var result = await _tagService.AddTagToNoteAsync(noteId: 10, tagId: 3, userId: 1);

            // Assert
            Assert.IsTrue(result.Success);
            _mockTagRepository.Verify(repo => repo.AddNoteTagAsync(It.IsAny<NoteTag>()), Times.Once);
        }

        [TestMethod]
        public async Task AddTagToNoteAsync_AlreadyLinked_DoesNotDuplicateLink()
        {
            // Arrange - tag is already linked to this note
            var note = new Note { NoteId = 10, UserId = 1 };
            var tag = new Tag { TagId = 3, UserId = 1 };

            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(10)).ReturnsAsync(note);
            _mockTagRepository.Setup(repo => repo.GetTagByIdAsync(3)).ReturnsAsync(tag);
            _mockTagRepository.Setup(repo => repo.NoteTagExistsAsync(10, 3)).ReturnsAsync(true);

            // Act
            var result = await _tagService.AddTagToNoteAsync(noteId: 10, tagId: 3, userId: 1);

            // Assert - should succeed but NOT call AddNoteTagAsync again
            Assert.IsTrue(result.Success);
            _mockTagRepository.Verify(repo => repo.AddNoteTagAsync(It.IsAny<NoteTag>()), Times.Never);
        }
    }
}