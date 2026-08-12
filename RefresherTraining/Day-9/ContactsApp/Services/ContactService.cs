using ContactsApp.Interfaces;
using ContactsApp.Models;

namespace ContactsApp.Services
{
    // Business logic layer - sits between Controller and Repository
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public List<Contact> GetAllContacts()
        {
            return _repository.GetAllContacts();
        }

        public Contact? GetContactById(int id)
        {
            return _repository.GetContactById(id);
        }

        public void AddContact(Contact contact)
        {
            _repository.AddContact(contact);
        }

        public bool UpdateContact(int id, Contact contact)
        {
            return _repository.UpdateContact(id, contact);
        }

        public bool DeleteContact(int id)
        {
            return _repository.DeleteContact(id);
        }
    }
}