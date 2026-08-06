using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;
using System.Collections.Generic;

namespace HealthClinicApp.Service
{
    // Contains all database operations related to Appointment
    public class AppointmentService
    {
        // Books a new appointment (inserts a record)
        public void BookAppointment(Appointment appointment)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = @"INSERT INTO Appointment (PatientId, DoctorId, AppointmentDate, Status)
                VALUES (@PatId, @DocId, @Date, @Status)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PatId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@DocId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@Date", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@Status", appointment.Status);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Appointment booked successfully." : "Booking failed.");
        }

        // Fetches all appointment records
        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM Appointment";

            using SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                appointments.Add(new Appointment
                {
                    AppointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId")),
                    PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                    DoctorId = reader.GetInt32(reader.GetOrdinal("DoctorId")),
                    AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                    Status = reader.GetString(reader.GetOrdinal("Status"))
                });
            }
            return appointments;
        }

        // Cancels an appointment by updating its status
        public void CancelAppointment(int appointmentId)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "UPDATE Appointment SET Status='Cancelled' WHERE AppointmentId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", appointmentId);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Appointment cancelled." : "Appointment not found.");
        }
    }
}