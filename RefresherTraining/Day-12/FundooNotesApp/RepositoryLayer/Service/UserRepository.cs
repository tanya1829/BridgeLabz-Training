using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    // Repository implementation - handles actual DB operations via EF Core
    public class UserRepository : IUserRepository
    {
        private readonly FundooDbContext _context;

        public UserRepository(FundooDbContext context)
        {
            _context = context;
        }

        // Add new user to database
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Fetch user by email - used for login and duplicate-check during registration
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        // Fetch user by id
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}