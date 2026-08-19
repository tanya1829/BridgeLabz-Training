namespace FundooNotesApp.ModelLayer.DTOs.Response
{
    // Safe response shape for profile - never include Password here
    public class UserProfileResponseDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}