using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;
using System.Collections.Generic;

namespace HealthClinicApp.Service
{
    // Contains all database operations related to Patient
    public class PatientService
    {
        // Inserts a new patient record
        public void AddPatient(Patient patient)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = @"INSERT INTO Patient (FirstName, LastName, DateOfBirth, Phone, Address, Gender)
                VALUES (@FirstName, @LastName, @Dob, @Phone, @Address, @Gender)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@Dob", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@Phone", patient.Phone);
            cmd.Parameters.AddWithValue("@Address", patient.Address);
            cmd.Parameters.AddWithValue("@Gender", patient.Gender);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Patient added successfully." : "Failed to add patient.");
        }

        // Fetches all patient records
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM Patient";

            using SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                patients.Add(new Patient
                {
                    PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender"))[0]
                });
            }
            return patients;
        }

        // Updates an existing patient's details based on PatientId
        public void UpdatePatient(Patient patient)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = @"UPDATE Patient SET FirstName=@FirstName, LastName=@LastName, DateOfBirth=@Dob,
                Phone=@Phone, Address=@Address, Gender=@Gender WHERE PatientId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@Dob", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@Phone", patient.Phone);
            cmd.Parameters.AddWithValue("@Address", patient.Address);
            cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            cmd.Parameters.AddWithValue("@ID", patient.PatientId);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Patient updated." : "Patient not found.");
        }

        // Deletes a patient record based on PatientId
        public void DeletePatient(int patientId)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "DELETE FROM Patient WHERE PatientId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", patientId);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Patient deleted." : "Patient not found.");
        }
    }
}