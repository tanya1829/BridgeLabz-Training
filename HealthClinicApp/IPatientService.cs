using HealthCareApp.Models;
using System.Collections.Generic;


namespace HealthCareApp.Interfaces
{
public interface IPatientService
{
void AddPatient(Patient patient);
void UpdatePatient(Patient patient);
List<Patient> GetAllPatients();
Patient GetPatientById(int id);
}
}