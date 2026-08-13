using ModelLayer.Entities;

namespace RepositoryLayer.Interface
{
    // Contract for database operations
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
        bool UpdateContact(int id, Contact contact);
        bool DeleteContact(int id);
    }
}