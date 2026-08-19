using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.DTOs.Request;
using FundooNotesApp.ModelLayer.DTOs.Response;

namespace FundooNotesApp.Business.Interface
{
    public interface IUserService
    {
        Task<ApiResponseDto<RegisterResponseDto>> RegisterAsync(RegisterRequestDto registerDto);
        Task<ApiResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto loginDto);
        Task<ApiResponseDto<string>> ForgotPasswordAsync(ForgotPasswordRequestDto forgotPasswordDto);
        Task<ApiResponseDto<UserProfileResponseDto>> GetProfileAsync(int userId);   // naya method
    }
}