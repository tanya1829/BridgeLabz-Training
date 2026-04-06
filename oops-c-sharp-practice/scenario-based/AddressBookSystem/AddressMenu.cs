using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AddressBookSystem
{

    internal class AddressMenu
    {

        AddressBookUtility utility = new AddressBookUtility();
        public void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n ---- Address Book ----");
                Console.WriteLine("1. Add Contact ");
                Console.WriteLine("2. Edit A contact");
                Console.WriteLine("3.Delete A Contact");
                Console.WriteLine("4.Display A contact");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter you choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.AddContact();
                        break;
                    case 2:
                        utility.EditContact();
                        break;
                    case 3:
                        utility.DeleteContact();
                        break;
                    case 4:
                        utility.DisplayContacts();
                        break;
                    case 5:
                        Console.WriteLine("Thank you.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } 
               while (choice != 5);
       
        }
   
    }

}

