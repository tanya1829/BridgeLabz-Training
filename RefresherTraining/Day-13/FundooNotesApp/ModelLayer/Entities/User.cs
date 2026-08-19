using System;

namespace FundooNotesApp.ModelLayer.Entities
{
    // User entity - maps to Users table in database
    public class User
    {
        public int UserId { get; set; }               // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }              // Unique - used for login
        public string Password { get; set; }           // Hashed password (never store plain text)
        public string Mobile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;   // Auto set on creation
    }
}