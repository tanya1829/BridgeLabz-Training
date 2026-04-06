namespace HealthCareApp.Models
{
public class Doctor
{
public int DoctorId { get; set; }
public string Name { get; set; }
public string Contact { get; set; }
public decimal Fee { get; set; }
public int SpecialistId { get; set; }
}
}