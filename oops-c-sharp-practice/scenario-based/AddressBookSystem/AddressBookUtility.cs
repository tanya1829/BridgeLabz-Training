using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookSystem
{
    internal class AddressBookUtility : IAddressBook
    {
        // List to store all contacts
        private List<Contact> contacts = new List<Contact>();

        // List to store address book names
        private static List<string> bookNames = new List<string>();

        // Create new address book
        public static void CreateAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();

            if (bookNames.Contains(name))
            {
                Console.WriteLine("Address Book already exists!");
                return;
            }

            bookNames.Add(name); // store book name
            Console.WriteLine("Address Book '" + name + "' created!");
            Console.WriteLine("Total Address Books: " + bookNames.Count);
        }

        // Select address book
        public static AddressBookUtility SelectAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();

            if (bookNames.Contains(name))
            {
                Console.WriteLine("Address Book '" + name + "' selected!");
                return new AddressBookUtility(); // new contact list
            }
            else
            {
                Console.WriteLine("Address Book not found!");
                return null;
            }
        }

        // Add a new contact
        public void AddContact()
        {
            Console.Write("First Name: ");
            string fname = Console.ReadLine();

            // check duplicate by first name
            if (contacts.Any(c => c.FirstName.Equals(fname, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Duplicate contact!");
                return;
            }

            Console.Write("Last Name: ");
            string lname = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("Zip: ");
            string zip = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contact contact = new Contact(fname, lname, address, city, state, zip, phone, email);

            contacts.Add(contact); // add to list
            Console.WriteLine("Contact added!");
        }

        // Edit existing contact
        public void EditContact()
        {
            Console.Write("Enter First Name to edit: ");
            string name = Console.ReadLine();

            Contact contact = contacts.FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Console.Write("New City: ");
            contact.City = Console.ReadLine();

            Console.Write("New State: ");
            contact.State = Console.ReadLine();

            Console.WriteLine("Contact updated!");
        }

        // Delete contact
        public void DeleteContact()
        {
            Console.Write("Enter First Name to delete: ");
            string name = Console.ReadLine();

            Contact contact = contacts.FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            contacts.Remove(contact); // remove from list
            Console.WriteLine("Contact deleted!");
        }
        public void DisplayContacts()
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("No contacts available.");
        return;
    }

    foreach (Contact c in contacts)
    {
        Console.WriteLine(c);
    }
}


        // Add multiple contacts
        public void AddMultipleContacts()
        {
            char choice;

            do
            {
                AddContact(); // call add method
                Console.Write("Add another contact? (y/n): ");
                choice = Convert.ToChar(Console.ReadLine());
            }
            while (choice == 'y' || choice == 'Y');
        }

        // Search by city/state
        public void SearchByCityOrState()
        {
            ViewPersonsByCityOrState();
        }

        // View contacts by city
        public void ViewPersonsByCityOrState()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            var result = contacts.Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            foreach (var c in result)
                Console.WriteLine(c);

            if (!result.Any())
                Console.WriteLine("No contacts found!");
        }

        // Count contacts in a city
        public void CountPersonsByCityOrState()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            int count = contacts.Count(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Total contacts in " + city + ": " + count);
        }

        // Sort contacts by first name
        public void SortContactsByName()
        {
            contacts = contacts.OrderBy(c => c.FirstName).ToList();
            Console.WriteLine("Contacts sorted!");
        }
    }
}