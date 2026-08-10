using Microsoft.Data.SqlClient;

namespace ContactsApp.Repository
{
    public class DatabaseConnection
    {
        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}