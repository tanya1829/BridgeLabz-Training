using ContactsApp.Models;

namespace ContactsApp.Interfaces
{
    // Contract for business logic - Service must implement these
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
        bool UpdateContact(int id, Contact contact);
        bool DeleteContact(int id);
    }
}