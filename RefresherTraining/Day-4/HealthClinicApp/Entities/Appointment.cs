namespace HealthClinicApp.Entities
{
    // Matches the "Appointment" table in SQL
    public class Appointment
    {
        public int AppointmentId { get; set; }            // Primary Key
        public int PatientId { get; set; }                   // Foreign Key -> Patient
        public int DoctorId { get; set; }                       // Foreign Key -> Doctor
        public DateTime AppointmentDate { get; set; }              // Date of appointment
        public string Status { get; set; } = "Scheduled";             // Scheduled / Completed / Cancelled
    }
}