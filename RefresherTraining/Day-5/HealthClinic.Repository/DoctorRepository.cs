using Microsoft.Data.SqlClient;
using HealthClinic.Entities;

namespace HealthClinic.Repository
{
    public class DoctorRepository
    {
        public void AddDoctor(Doctor doctor)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = @"INSERT INTO Doctor (FirstName, LastName, Specialization, Phone)
                VALUES (@FirstName, @LastName, @Spec, @Phone)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
            cmd.Parameters.AddWithValue("@Spec", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", doctor.Phone);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

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
            cmd.ExecuteNonQuery();
        }

        public void DeleteDoctor(int doctorId)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "DELETE FROM Doctor WHERE DoctorId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", doctorId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}