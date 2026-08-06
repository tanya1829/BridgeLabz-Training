using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;
using System.Collections.Generic;

namespace HealthClinicApp.Service
{
    // Contains all database operations related to Doctor
    public class DoctorService
    {
        // Inserts a new doctor record into the database
        public void AddDoctor(Doctor doctor)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();

            // Parameterized query to prevent SQL Injection
            string query = @"INSERT INTO Doctor (FirstName, LastName, Specialization, Phone)
                VALUES (@FirstName, @LastName, @Spec, @Phone)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
            cmd.Parameters.AddWithValue("@Spec", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", doctor.Phone);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Doctor added successfully." : "Failed to add doctor.");
        }

        // Fetches all doctor records from the database
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM Doctor";

            using SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                doctors.Add(new Doctor
                {
                    DoctorId = reader.GetInt32(reader.GetOrdinal("DoctorId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Specialization = reader.GetString(reader.GetOrdinal("Specialization")),
                    Phone = reader.GetString(reader.GetOrdinal("phone"))
                });
            }
            return doctors;
        }

        // Updates an existing doctor's details based on DoctorId
        public void UpdateDoctor(Doctor doctor)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = @"UPDATE Doctor SET FirstName=@FirstName, LastName=@LastName, 
                Specialization=@Spec, Phone=@Phone WHERE DoctorId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
            cmd.Parameters.AddWithValue("@Spec", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", doctor.Phone);
            cmd.Parameters.AddWithValue("@ID", doctor.DoctorId);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Doctor updated." : "Doctor not found.");
        }

        // Deletes a doctor record based on DoctorId
        public void DeleteDoctor(int doctorId)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "DELETE FROM Doctor WHERE DoctorId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", doctorId);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Doctor deleted." : "Doctor not found.");
        }
    }
}