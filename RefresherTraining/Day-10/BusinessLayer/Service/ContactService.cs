using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using ModelLayer.Entities;
using ModelLayer.Dtos;

namespace BusinessLayer.Service
{
    // Business logic - converts between Entity and Dto, calls Repository
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public List<ContactDto> GetAllContacts()
        {
            List<Contact> contacts = _repository.GetAllContacts();
            List<ContactDto> result = new List<ContactDto>();

            foreach (var contact in contacts)
            {
                result.Add(new ContactDto
                {
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email
                });
            }
            return result;
        }

        public ContactDto? GetContactById(int id)
        {
            Contact? contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return null;
            }

            return new ContactDto
            {
                Name = contact.Name,
                Phone = contact.Phone,
                Email = contact.Email
            };
        }

        public void AddContact(ContactDto contactDto)
        {
            Contact contact = new Contact
            {
                Name = contactDto.Name,
                Phone = contactDto.Phone,
                Email = contactDto.Email
            };
            _repository.AddContact(contact);
        }

        public bool UpdateContact(int id, ContactDto contactDto)
        {
            Contact contact = new Contact
            {
                Name = contactDto.Name,
                Phone = contactDto.Phone,
                Email = contactDto.Email
            };
            return _repository.UpdateContact(id, contact);
        }

        public bool DeleteContact(int id)
        {
            return _repository.DeleteContact(id);
        }
    }
}