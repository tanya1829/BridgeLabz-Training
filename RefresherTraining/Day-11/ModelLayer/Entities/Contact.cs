using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Entities
{
    // Database entity - maps directly to the Contact table
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
    }
}