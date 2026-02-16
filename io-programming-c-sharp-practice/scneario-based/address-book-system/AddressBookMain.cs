using System;

namespace AddressBookSystem
{
    internal class AddressBookMain
    {
        public static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("WELCOME TO ADDRESS BOOK SYSTEM ---> ");
                AddressBookMenu menu = new AddressBookMenu();
                await menu.ShowMenu();
            }
            catch (Exception ex) // catches unexpected crash
            {
                Console.WriteLine("System Error: " + ex.Message);
            }
        }
    }
}