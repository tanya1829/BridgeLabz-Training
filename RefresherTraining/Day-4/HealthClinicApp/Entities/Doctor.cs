namespace HealthClinicApp.Entities
{
    // Matches the "Doctor" table in SQL
    public class Doctor
    {
        public int DoctorId { get; set; }          // Primary Key
        public string FirstName { get; set; }         // First name
        public string LastName { get; set; }             // Last name
        public string Specialization { get; set; }          // e.g. Cardiologist, Dentist
        public string Phone { get; set; }                      // Contact number
    }
}