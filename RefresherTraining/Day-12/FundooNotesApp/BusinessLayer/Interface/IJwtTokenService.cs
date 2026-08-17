using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Business.Interface
{
    // Interface for JWT token generation - separated for single responsibility
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}