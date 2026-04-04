using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
	internal class AddressBookUtility : IAddressBook
	{
		private Contact[] contacts;
		private int count = 0;

		// constructor 
		public AddressBookUtility()
		{
			Console.WriteLine("Enter the number of contacts you want to store");
			int size = int.Parse(Console.ReadLine());
			contacts = new Contact[size];
		}
		//for adding a contact
		public void AddAContact()
		{
			if (count == contacts.Length)
			{
				Console.WriteLine("Address book is full");
				return;

			}
			Console.WriteLine("Enter FirstName");
			string firstName = Console.ReadLine();
			Console.WriteLine("Enter LastName");
			string lastName = Console.ReadLine();
			Console.WriteLine("Enter your Email");
			string email = Console.ReadLine();
			Console.WriteLine("Enter Phone numver");
			string phone = Console.ReadLine();
			Console.WriteLine("enter address");
			string address = Console.ReadLine();
			Console.WriteLine("enter city");
			string city = Console.ReadLine();
			Console.WriteLine("State");
			string state = Console.ReadLine();
			Console.WriteLine("Enter zip");
			string zipCode = Console.ReadLine();

			contacts[count] = new Contact(firstName, lastName, address,
										   city, state, zipCode, phone, email);
			count++;

			Console.WriteLine("You Have  added Contact successfully.");

		}
		// for editing an exisiting contact
		public void EditContact()
		{
			Console.WriteLine("Enter your full Name");
			string name = Console.ReadLine();
			for (int i = 0; i < count; i++)
			{
				if (contacts[i].GetFullName().Equals(name))
				{
					Console.Write("New City: ");
					contacts[i].City = Console.ReadLine();

					Console.Write("New State: ");
					contacts[i].State = Console.ReadLine();

					Console.WriteLine("Contact updated.");
					return;
				}
			}
			Console.WriteLine("Contact not found.");
		}
		// for deleting a contact
		public void DeleteContact()
		{
			Console.Write("Enter Full Name to Delete: ");
			string name = Console.ReadLine();

			for (int i = 0; i < count; i++)
			{
				if (contacts[i].GetFullName().Equals(name))
				{
					for (int j = i; j < count - 1; j++)
					{
						contacts[j] = contacts[j + 1];
					}

					contacts[count - 1] = null;
					count--;

					Console.WriteLine("Contact deleted.");
					return;
				}
			}
		}
				 // Display Contacts
			public void DisplayContacts()
		    {
			   if (count == 0)
			{
				Console.WriteLine("No contacts available.");
				return;
			}

			    for (int i = 0; i < count; i++)
			{
				Console.WriteLine(contacts[i]);
			}
		}
	}
}

	


		
