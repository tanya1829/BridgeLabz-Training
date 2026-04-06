using System.Data.SqlClient;


namespace HealthCareApp.DB
{
public class DbConnection
{
private static string connectionString = "Server=.;Database=HealthCare;Trusted_Connection=True;";


public static SqlConnection GetConnection()
{
       return new SqlConnection(connectionString);
}
}
}