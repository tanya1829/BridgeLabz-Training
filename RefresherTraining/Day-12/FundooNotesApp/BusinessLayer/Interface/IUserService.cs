using System.Threading.Tasks;
using FundooNotesApp.ModelLayer.DTOs;



namespace FundooNotesApp.Business.Service
{
    // Service interface - defines business logic contract
    public interface IUserService
    {
        Task<ResponseDTO<string>> RegisterAsync(RegisterDTO registerDto);
        Task<ResponseDTO<string>> LoginAsync(LoginDTO loginDto);
        Task<ResponseDTO<string>> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDto);
    }
}