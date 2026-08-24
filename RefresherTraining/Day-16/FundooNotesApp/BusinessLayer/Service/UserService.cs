using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.DTOs.Response;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Repository;
using FundooNotesApp.Business.Interface;

namespace FundooNotesApp.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        // Register new user
        public async Task<ApiResponseDto<RegisterResponseDto>> RegisterAsync(RegisterRequestDto registerDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                // Throw instead of returning failure DTO - Controller catches this and returns 409 Conflict
                throw new UserAlreadyExistsException("Email already registered");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = hashedPassword,
                Mobile = registerDto.Mobile
            };

            await _userRepository.AddUserAsync(user);

            return new ApiResponseDto<RegisterResponseDto>
            {
                Success = true,
                Message = "User registered successfully",
                Data = new RegisterResponseDto
                {
                    UserId = user.UserId,
                    Email = user.Email
                }
            };
        }

        // Login user and return JWT token
        public async Task<ApiResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                // Throw instead of returning failure DTO - Controller catches this and returns 401 Unauthorized
                throw new InvalidCredentialsException("Invalid email or password");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new ApiResponseDto<LoginResponseDto>
            {
                Success = true,
                Message = "Login successful",
                Data = new LoginResponseDto
                {
                    Token = token,
                    Email = user.Email
                }
            };
        }

        // Forgot password - stub for future implementation
        public async Task<ApiResponseDto<string>> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordDto)
        {
            await Task.CompletedTask;

            return new ApiResponseDto<string>
            {
                Success = true,
                Message = "Forgot password API - to be implemented",
                Data = null
            };
        }

        // Get logged-in user's profile - called only after JWT token is validated
        public async Task<ApiResponseDto<UserProfileResponseDto>> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                // Throw instead of returning failure DTO - Controller catches this and returns 404 Not Found
                throw new UserNotFoundException("User not found");
            }

            return new ApiResponseDto<UserProfileResponseDto>
            {
                Success = true,
                Message = "Profile fetched successfully",
                Data = new UserProfileResponseDto
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Mobile = user.Mobile
                }
            };
        }
    }
}