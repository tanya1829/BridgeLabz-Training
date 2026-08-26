using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FundooNotesApp.ModelLayer.Entities;

using FundooNotesApp.Repository;

namespace FundooNotesApp.Repository
{
    // Repository interface - defines data access contract
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int userId);
    }
}