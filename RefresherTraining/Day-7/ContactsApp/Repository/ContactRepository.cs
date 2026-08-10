using Microsoft.Data.SqlClient;
using ContactsApp.Models;

namespace ContactsApp.Repository
{
    public class ContactRepository
    {
        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM Contact";

            using SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                contacts.Add(new Contact
                {
                    ContactId = reader.GetInt32(reader.GetOrdinal("ContactId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? "" : reader.GetString(reader.GetOrdinal("Phone")),
                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email"))
                });
            }
            return contacts;
        }

        public Contact? GetContactById(int id)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM Contact WHERE ContactId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Contact
                {
                    ContactId = reader.GetInt32(reader.GetOrdinal("ContactId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? "" : reader.GetString(reader.GetOrdinal("Phone")),
                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email"))
                };
            }
            return null;
        }

        public int AddContact(Contact contact)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "INSERT INTO Contact (Name, Phone, Email) VALUES (@Name, @Phone, @Email)";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", contact.Name);
            cmd.Parameters.AddWithValue("@Phone", contact.Phone);
            cmd.Parameters.AddWithValue("@Email", contact.Email);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int UpdateContact(int id, Contact contact)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "UPDATE Contact SET Name=@Name, Phone=@Phone, Email=@Email WHERE ContactId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", contact.Name);
            cmd.Parameters.AddWithValue("@Phone", contact.Phone);
            cmd.Parameters.AddWithValue("@Email", contact.Email);
            cmd.Parameters.AddWithValue("@ID", id);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int DeleteContact(int id)
        {
            using SqlConnection conn = DatabaseConnection.GetConnection();
            string query = "DELETE FROM Contact WHERE ContactId=@ID";

            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}