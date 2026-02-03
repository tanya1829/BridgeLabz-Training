using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookSystem
{
    internal class AddressBookUtility : IAddressBook
    {
        // List to store contacts in current address book
        private List<Contact> contacts = new List<Contact>();

        // Static list to store all address book names
        private static List<string> bookNames = new List<string>();

        // Create a new address book
        public static void CreateAddressBook()
        {
            try
            {
                Console.Write("Enter Address Book Name: ");
                string name = Console.ReadLine();

                // Check for empty name
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("Book name cannot be empty!");

                // Check for duplicate address book
                if (bookNames.Contains(name))
                    throw new Exception("Address Book already exists!");

                bookNames.Add(name); // Add new book name
                Console.WriteLine("Address Book created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Select an existing address book
        public static AddressBookUtility SelectAddressBook()
        {
            try
            {
                Console.Write("Enter Address Book Name: ");
                string name = Console.ReadLine();

                // Check if book exists
                if (!bookNames.Contains(name))
                    throw new Exception("Address Book not found!");

                Console.WriteLine("Address Book selected!");
                return new AddressBookUtility(); // Return new instance
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        // Add a single contact
        public void AddContact()
        {
            try
            {
                Console.Write("First Name: ");
                string fname = Console.ReadLine();

                // Validate first name
                if (string.IsNullOrWhiteSpace(fname))
                    throw new Exception("First name cannot be empty!");

                // Check duplicate contact by first name
                if (contacts.Any(c => c.FirstName.Equals(fname, StringComparison.OrdinalIgnoreCase)))
                    throw new Exception("Duplicate contact!");

                Console.Write("Last Name: ");
                string lname = Console.ReadLine();

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("State: ");
                string state = Console.ReadLine();

                Console.Write("Phone: ");
                string phone = Console.ReadLine();

                // Validate phone number digits only
                if (!phone.All(char.IsDigit))
                    throw new Exception("Phone must be numeric!");

                // Create contact object
                Contact contact = new Contact(fname, lname, "", city, state, "", phone, "");
                contacts.Add(contact); // Add to list

                Console.WriteLine("Contact added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Edit existing contact
        public void EditContact()
        {
            try
            {
                Console.Write("Enter First Name to edit: ");
                string name = Console.ReadLine();

                // Find contact
                Contact contact = contacts.FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (contact == null)
                    throw new Exception("Contact not found!");

                Console.Write("New City: ");
                contact.City = Console.ReadLine(); // Update city

                Console.WriteLine("Contact updated!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Delete a contact
        public void DeleteContact()
        {
            try
            {
                Console.Write("Enter First Name to delete: ");
                string name = Console.ReadLine();

                // Find contact
                Contact contact = contacts.FirstOrDefault(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (contact == null)
                    throw new Exception("Contact not found!");

                contacts.Remove(contact); // Remove contact
                Console.WriteLine("Contact deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Add multiple contacts in loop
        public void AddMultipleContacts()
        {
            char choice;
            do
            {
                AddContact(); // Call add method
                Console.Write("Add another? (y/n): ");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'y' || choice == 'Y');
        }

        public void SearchByCityOrState() => ViewPersonsByCityOrState();

        // View contacts by city
        public void ViewPersonsByCityOrState()
        {
            try
            {
                Console.Write("Enter City: ");
                string city = Console.ReadLine();

                // Filter contacts by city
                var result = contacts.Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));

                if (!result.Any())
                    throw new Exception("No contacts found!");

                foreach (var c in result)
                    Console.WriteLine(c); // Display contact
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Count contacts in a city
        public void CountPersonsByCityOrState()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            int count = contacts.Count(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Total contacts: " + count);
        }

        // Sort contacts alphabetically by first name
        public void SortContactsByName()
        {
            contacts = contacts.OrderBy(c => c.FirstName).ToList();
            Console.WriteLine("Contacts sorted!");
        }
    }
}


		
