namespace ModelLayer.Dtos
{
    // Data Transfer Object - used to send/receive data via API (hides internal entity structure)
    public class ContactDto
    {
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
    }
}