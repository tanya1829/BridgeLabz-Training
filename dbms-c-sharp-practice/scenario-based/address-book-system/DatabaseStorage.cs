using System.Collections.Generic;
using System.Data.SqlClient;

namespace AddressBookSystem
{
    internal class DatabaseStorage : IDataStorage
    {
     private string connectionString =
    "Server=localhost\\SQLEXPRESS;Database=AddressBookDB;Trusted_Connection=True;";


        public void Save(List<Contact> contacts)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var c in contacts)
                {
                    string query = "INSERT INTO Contacts VALUES(@fn,@ln,@addr,@city,@state,@zip,@phone,@email)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@fn", c.FirstName);
                    cmd.Parameters.AddWithValue("@ln", c.LastName);
                    cmd.Parameters.AddWithValue("@addr", c.Address);
                    cmd.Parameters.AddWithValue("@city", c.City);
                    cmd.Parameters.AddWithValue("@state", c.State);
                    cmd.Parameters.AddWithValue("@zip", c.Zip);
                    cmd.Parameters.AddWithValue("@phone", c.Phone);
                    cmd.Parameters.AddWithValue("@email", c.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Contact> Load()
        {
            List<Contact> list = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Contacts";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Contact(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString(),
                        reader[6].ToString(),
                        reader[7].ToString()
                    ));
                }
            }

            return list;
        }
    }
}
