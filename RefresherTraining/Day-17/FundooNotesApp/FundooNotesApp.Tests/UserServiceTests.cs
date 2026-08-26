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
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IJwtTokenService> _mockJwtTokenService;
        private UserService _userService;

        // Runs before every test method - fresh mocks each time so tests don't affect each other
        [TestInitialize]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockJwtTokenService = new Mock<IJwtTokenService>();
            _userService = new UserService(_mockUserRepository.Object, _mockJwtTokenService.Object);
        }

        [TestMethod]
        public async Task RegisterAsync_NewEmail_ReturnsSuccess()
        {
            // Arrange - simulate that no user exists with this email
            _mockUserRepository
                .Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            var registerDto = new RegisterRequestDto
            {
                FirstName = "Tanya",
                LastName = "Sharma",
                Email = "tanya@test.com",
                Password = "Test@123",
                Mobile = "9876543210"
            };

            // Act
            var result = await _userService.RegisterAsync(registerDto);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("User registered successfully", result.Message);
            Assert.AreEqual("tanya@test.com", result.Data.Email);
        }

        [TestMethod]
        public async Task RegisterAsync_DuplicateEmail_ThrowsUserAlreadyExistsException()
        {
            // Arrange - simulate that a user already exists with this email
            var existingUser = new User { Email = "tanya@test.com" };
            _mockUserRepository
                .Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(existingUser);

            var registerDto = new RegisterRequestDto
            {
                FirstName = "Tanya",
                LastName = "Sharma",
                Email = "tanya@test.com",
                Password = "Test@123",
                Mobile = "9876543210"
            };

            // Act & Assert - expect the exception to be thrown
            await Assert.ThrowsExactlyAsync<UserAlreadyExistsException>(
                () => _userService.RegisterAsync(registerDto)
            );
        }

        [TestMethod]
        public async Task LoginAsync_ValidCredentials_ReturnsToken()
        {
            // Arrange - hash a known password the same way UserService does, so Verify succeeds
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Test@123");
            var existingUser = new User
            {
                UserId = 1,
                Email = "tanya@test.com",
                Password = hashedPassword,
                FirstName = "Tanya",
                LastName = "Sharma"
            };

            _mockUserRepository
                .Setup(repo => repo.GetUserByEmailAsync("tanya@test.com"))
                .ReturnsAsync(existingUser);

            _mockJwtTokenService
                .Setup(jwt => jwt.GenerateToken(It.IsAny<User>()))
                .Returns("fake-jwt-token");

            var loginDto = new LoginRequestDto
            {
                Email = "tanya@test.com",
                Password = "Test@123"
            };

            // Act
            var result = await _userService.LoginAsync(loginDto);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("fake-jwt-token", result.Data.Token);
        }

        [TestMethod]
        public async Task LoginAsync_WrongPassword_ThrowsInvalidCredentialsException()
        {
            // Arrange
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("CorrectPassword");
            var existingUser = new User
            {
                Email = "tanya@test.com",
                Password = hashedPassword
            };

            _mockUserRepository
                .Setup(repo => repo.GetUserByEmailAsync("tanya@test.com"))
                .ReturnsAsync(existingUser);

            var loginDto = new LoginRequestDto
            {
                Email = "tanya@test.com",
                Password = "WrongPassword"   // deliberately wrong
            };

            // Act & Assert
            await Assert.ThrowsExactlyAsync<InvalidCredentialsException>(
                () => _userService.LoginAsync(loginDto)
            );
        }

        [TestMethod]
        public async Task LoginAsync_UserDoesNotExist_ThrowsInvalidCredentialsException()
        {
            // Arrange - no user found for this email
            _mockUserRepository
                .Setup(repo => repo.GetUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            var loginDto = new LoginRequestDto
            {
                Email = "doesnotexist@test.com",
                Password = "AnyPassword"
            };

            // Act & Assert
            await Assert.ThrowsExactlyAsync<InvalidCredentialsException>(
                () => _userService.LoginAsync(loginDto)
            );
        }
    }
}