using System;
using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.DTOs;
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

        public async Task<ResponseDTO<string>> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return new ResponseDTO<string>
                {
                    Success = false,
                    Message = "Email already registered",
                    Data = null
                };
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

            return new ResponseDTO<string>
            {
                Success = true,
                Message = "User registered successfully",
                Data = user.Email
            };
        }

        public async Task<ResponseDTO<string>> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return new ResponseDTO<string>
                {
                    Success = false,
                    Message = "Invalid email or password",
                    Data = null
                };
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new ResponseDTO<string>
            {
                Success = true,
                Message = "Login successful",
                Data = token
            };
        }

        public async Task<ResponseDTO<string>> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDto)
        {
            await Task.CompletedTask;

            return new ResponseDTO<string>
            {
                Success = true,
                Message = "Forgot password API - to be implemented",
                Data = null
            };
        }
    }
}