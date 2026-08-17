namespace FundooNotesApp.ModelLayer.DTOs
{
    // Data coming from client during registration
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
}