using System;
using Microsoft.Data.SqlClient;
class StudentConnection
{
    public static void Main(string[]args)
    {
         string querry="SELECT * From StudentRecords";
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Student; Trusted_Connection=True;TrustServerCertificate=True";
       
       
       using (SqlConnection connection = new SqlConnection(connectionString))
       {
       connection.Open();
       
       System.Console.WriteLine("Connection Established");
       SqlCommand command = new SqlCommand(querry , connection);
       SqlDataReader reader = command.ExecuteReader();
       while (reader.Read())
       {
          System.Console.WriteLine(reader["StudentID"].ToString() + " " + reader["Name"].ToString()+ " " + reader["Age"].ToString()+ " " + reader["Gender"].ToString() + " " + reader["Email"].ToString() );
       }
          reader.Close();
         connection.Close();
       
    }
}
}