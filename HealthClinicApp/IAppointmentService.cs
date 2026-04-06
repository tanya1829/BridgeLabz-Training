using HealthCareApp.Models;
using System.Collections.Generic;


namespace HealthCareApp.Interfaces
{
public interface IAppointmentService
{
void BookAppointment(Appointment a);
void CancelAppointment(int id);
List<Appointment> GetAppointments();
}
}