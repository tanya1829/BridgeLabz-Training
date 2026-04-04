using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    internal class AddressBookMain
    {
        public static void Main(string[] args)
        {
             AddressMenu menu = new AddressMenu();
             menu.ShowMenu();
        }
    }
}
