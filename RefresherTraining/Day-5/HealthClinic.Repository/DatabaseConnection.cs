using Microsoft.Data.SqlClient;

namespace HealthClinic.Repository
{
    public class DatabaseConnection
    {
        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=HealthClinic;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}