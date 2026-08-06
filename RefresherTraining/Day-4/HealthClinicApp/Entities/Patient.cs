namespace HealthClinicApp.Entities
{
    // Matches the "Patient" table in SQL
    public class Patient
    {
        public int PatientId { get; set; }         // Primary Key
        public string FirstName { get; set; }         // First name
        public string LastName { get; set; }             // Last name
        public DateTime DateOfBirth { get; set; }           // Date of birth
        public string Phone { get; set; }                     // Contact number
        public string Address { get; set; }                     // Residential address
        public char Gender { get; set; }                          // 'M' / 'F' / 'O'
    }
}