using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using ModelLayer.Entities;

namespace RepositoryLayer.Service
{
    // Talks directly to the database using EF Core + LINQ to Entities
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAllContacts()
        {
            // LINQ to Entities query
            return _context.Contacts.ToList();
        }

        public Contact? GetContactById(int id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public bool UpdateContact(int id, Contact updatedContact)
        {
            Contact? existing = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (existing == null)
            {
                return false;
            }

            existing.Name = updatedContact.Name;
            existing.Phone = updatedContact.Phone;
            existing.Email = updatedContact.Email;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteContact(int id)
        {
            Contact? existing = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (existing == null)
            {
                return false;
            }

            _context.Contacts.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}