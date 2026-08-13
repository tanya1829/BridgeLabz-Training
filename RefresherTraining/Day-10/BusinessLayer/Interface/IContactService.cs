using ModelLayer.Dtos;

namespace BusinessLayer.Interface
{
    // Contract for business logic - works with DTOs (not raw entities)
    public interface IContactService
    {
        List<ContactDto> GetAllContacts();
        ContactDto? GetContactById(int id);
        void AddContact(ContactDto contactDto);
        bool UpdateContact(int id, ContactDto contactDto);
        bool DeleteContact(int id);
    }
}