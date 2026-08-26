using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Repository;
using FundooNotesApp.Business.Interface;
using FundooNotesApp.Business.Service;

namespace FundooNotesApp.Tests
{
    [TestClass]
    public class NoteServiceTests
    {
        private Mock<INoteRepository> _mockNoteRepository;
        private Mock<IRabbitMqProducerService> _mockRabbitMqProducer;
        private NoteService _noteService;

        [TestInitialize]
        public void Setup()
        {
            _mockNoteRepository = new Mock<INoteRepository>();
            _mockRabbitMqProducer = new Mock<IRabbitMqProducerService>();
            _noteService = new NoteService(_mockNoteRepository.Object, _mockRabbitMqProducer.Object);
        }

        [TestMethod]
        public async Task CreateNoteAsync_ValidData_ReturnsSuccess()
        {
            // Arrange
            var createDto = new CreateNoteRequestDto { Title = "Test Note", Description = "Test Description" };

            // Act
            var result = await _noteService.CreateNoteAsync(createDto, userId: 1);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Test Note", result.Data.Title);
            _mockNoteRepository.Verify(repo => repo.AddNoteAsync(It.IsAny<Note>()), Times.Once);
        }

        [TestMethod]
        public async Task MoveToTrashAsync_OwnedNote_MarksAsTrashed()
        {
            // Arrange - a note owned by user 1
            var note = new Note { NoteId = 5, UserId = 1, Title = "My Note", IsTrashed = false };
            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(5)).ReturnsAsync(note);

            // Act
            var result = await _noteService.MoveToTrashAsync(noteId: 5, userId: 1);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.IsTrue(note.IsTrashed);   // confirm the flag was actually flipped
        }

        [TestMethod]
        public async Task MoveToTrashAsync_NoteNotFound_ThrowsNoteNotFoundException()
        {
            // Arrange - repository returns null (note doesn't exist)
            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(It.IsAny<int>())).ReturnsAsync((Note)null);

            // Act & Assert
            await Assert.ThrowsExactlyAsync<NoteNotFoundException>(
                () => _noteService.MoveToTrashAsync(noteId: 99, userId: 1)
            );
        }

        [TestMethod]
        public async Task MoveToTrashAsync_NoteBelongsToAnotherUser_ThrowsUnauthorizedNoteAccessException()
        {
            // Arrange - note exists but belongs to a different user (userId 2, not 1)
            var note = new Note { NoteId = 5, UserId = 2, Title = "Someone else's note" };
            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(5)).ReturnsAsync(note);

            // Act & Assert - user 1 tries to delete user 2's note
            await Assert.ThrowsExactlyAsync<UnauthorizedNoteAccessException>(
                () => _noteService.MoveToTrashAsync(noteId: 5, userId: 1)
            );
        }

        [TestMethod]
        public async Task DeletePermanentAsync_NoteNotInTrash_ThrowsInvalidNoteOperationException()
        {
            // Arrange - note exists, owned by user, but not trashed yet
            var note = new Note { NoteId = 5, UserId = 1, IsTrashed = false };
            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(5)).ReturnsAsync(note);

            // Act & Assert - permanent delete should be blocked until note is trashed first
            await Assert.ThrowsExactlyAsync<InvalidNoteOperationException>(
                () => _noteService.DeletePermanentAsync(noteId: 5, userId: 1)
            );
        }

        [TestMethod]
        public async Task TogglePinAsync_UnpinnedNote_BecomesPinned()
        {
            // Arrange
            var note = new Note { NoteId = 5, UserId = 1, IsPinned = false };
            _mockNoteRepository.Setup(repo => repo.GetNoteByIdAsync(5)).ReturnsAsync(note);

            // Act
            var result = await _noteService.TogglePinAsync(noteId: 5, userId: 1);

            // Assert
            Assert.IsTrue(result.Data.IsPinned);
            Assert.AreEqual("Note pinned", result.Message);
        }
    }
}