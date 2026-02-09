using HealthCareApp.Models;
using System.Collections.Generic;


namespace HealthCareApp.Interfaces
{
public interface IDoctorService
{
void AddDoctor(Doctor doctor);
List<Doctor> GetDoctors();
}
}