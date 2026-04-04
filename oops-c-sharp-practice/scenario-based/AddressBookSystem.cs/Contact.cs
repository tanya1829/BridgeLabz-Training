using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AddressBookSystem
{
    internal class Contact
    {   // data memebers are private
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string city;
        private string state;
        private string zipCode;
        private string address;

        // properties are public 
        public string FirstName {
               get { return firstName; }    
               set { firstName = value; } 
        }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }    
        public string ZipCode { get { return zipCode; } set { zipCode = value; } }
        public string Address { get { return address; } set { address = value; } }

        // constructor 
        public Contact(string firstName, string lastName, string email, string phone, string city, string state, string zipCode, string address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
			this.Address = address;
			this.City = city;
			this.State = state;
            this.ZipCode = zipCode;
            this.Phone = phone;
			this.Email = email;

		}  
            // for full name
            public string GetFullName()
            {
            return FirstName + " " + LastName;
            }
		// for displaying
		public override string ToString()
		{
			return FirstName + " " + LastName + " " +
				   Address + " " + City + " " +
				   State + " " + ZipCode + " " +
				   Phone + " " + Email;
		}

	}
}

