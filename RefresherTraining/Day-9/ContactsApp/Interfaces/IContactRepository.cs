using ContactsApp.Models;

namespace ContactsApp.Interfaces
{
    // Contract for database operations - Repository must implement these
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
        bool UpdateContact(int id, Contact contact);
        bool DeleteContact(int id);
    }
}