using Microsoft.Data.SqlClient;

namespace HealthClinicApp.Service
{
    // Handles creating a connection object to SQL Server
    internal class DatabaseConnection
    {
        // Connection string - database name is HealthClinic
        // Update Server name as per your SSMS instance
        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=HealthClinic;Trusted_Connection=True;TrustServerCertificate=True;";

        // Returns a new SqlConnection object each time it's called
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}