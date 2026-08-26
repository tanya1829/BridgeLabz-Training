using System;

namespace FundooNotesApp.ModelLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // New fields for forgot/reset password flow
        public string? ResetToken { get; set; }              // random token generated on forgot-password request
        public DateTime? ResetTokenExpiry { get; set; }       // token valid only for a limited time (e.g. 15 mins)
    }
}