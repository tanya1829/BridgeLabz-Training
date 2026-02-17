using System;

namespace AddressBookSystem
{
    internal class AddressBookMenu
    {
        public async Task ShowMenu()
        {
            AddressBookUtility currentBook = null;

            while (true)
            {
                try
                {
                    Console.WriteLine("\n===============================");
                    Console.WriteLine(" ADDRESS BOOK MENU ");
                    Console.WriteLine("===============================");
                    Console.WriteLine("1. Create Address Book");
                    Console.WriteLine("2. Select Address Book");
                    Console.WriteLine("3. Add Contact");
                    Console.WriteLine("4. Edit Contact");
                    Console.WriteLine("5. Delete Contact");
                    Console.WriteLine("6. Add Multiple Contacts");
                    Console.WriteLine("7. Search by City/State");
                    Console.WriteLine("8. View persons by City/State");
                    Console.WriteLine("9. Count persons by City/State");
                    Console.WriteLine("10. Sort contacts by Name");
                    Console.WriteLine("11. Sort contacts by City");   // UC-12
                    Console.WriteLine("12. Sort contacts by State");  // UC-12
                    Console.WriteLine("13. Sort contacts by Zip");    // UC-12
                    Console.WriteLine("14. Write contacts to File");   // UC-13
                    Console.WriteLine("15. Read contacts from File"); // UC-13
                    Console.WriteLine("16. Write contacts to CSV");   //UC-14
                    Console.WriteLine("17. Read contacts from CSV");  //UC-14
                    Console.WriteLine("18. Save contacts as JSON");    //UC-15
                    Console.WriteLine("19. Load contacts from JSON");  //UC-15
                    Console.WriteLine("20. Write contacts to JSON Server");  // UC-16
                    Console.WriteLine("21. Read contacts from JSON Server");  // UC-16
                    Console.WriteLine("22. Async Write to File");
                    Console.WriteLine("23. Async Read from File");
                    Console.WriteLine("24. Async Write to CSV");
                    Console.WriteLine("25. Async Read from CSV");
                    Console.WriteLine("26. Async Write to JSON");
                    Console.WriteLine("27. Async Read from JSON");

                    Console.WriteLine("28. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddressBookUtility.CreateAddressBook();
                            break;

                        case "2":
                            currentBook = AddressBookUtility.SelectAddressBook();
                            break;

                        case "3":
                            if (currentBook != null) currentBook.AddContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "4":
                            if (currentBook != null) currentBook.EditContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "5":
                            if (currentBook != null) currentBook.DeleteContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "6":
                            if (currentBook != null) currentBook.AddMultipleContacts();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "7":
                            if (currentBook != null) currentBook.SearchByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "8":
                            if (currentBook != null) currentBook.ViewPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "9":
                            if (currentBook != null) currentBook.CountPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "10":
                            if (currentBook != null) currentBook.SortContactsByName();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "11":
                            if (currentBook != null) currentBook.SortContactsByCity();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "12":
                            if (currentBook != null) currentBook.SortContactsByState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "13":
                            if (currentBook != null) currentBook.SortContactsByZip();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "14":
                            if (currentBook != null) currentBook.WriteContactsToFile();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "15":
                            if (currentBook != null) currentBook.ReadContactsFromFile();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "16":
                            if (currentBook != null) currentBook.WriteContactsToCSV();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "17":
                            if (currentBook != null) currentBook.ReadContactsFromCSV();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "18":
                            if (currentBook != null) currentBook.WriteContactsToJSON();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "19":
                            if (currentBook != null) currentBook.ReadContactsFromJSON();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "20":
                            if (currentBook != null)
                                await currentBook.WriteToJsonServer();
                            else
                                Console.WriteLine("Please select an address book first!");
                            break;

                        case "21":
                            if (currentBook != null)
                                await currentBook.ReadFromJsonServer();
                            else
                                Console.WriteLine("Please select an address book first!");
                            break;


                        case "22":
                            if (currentBook != null)
                                await currentBook.WriteContactsToFileAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "23":
                            if (currentBook != null)
                                await currentBook.ReadContactsFromFileAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "24":
                            if (currentBook != null)
                                await currentBook.WriteContactsToCSVAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "25":
                            if (currentBook != null)
                                await currentBook.ReadContactsFromCSVAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "26":
                            if (currentBook != null)
                                await currentBook.WriteContactsToJSONAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "27":
                            if (currentBook != null)
                                await currentBook.ReadContactsFromJSONAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                             case "28":
                            Console.WriteLine("Exiting Address Book System...");
                            return;


                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Menu Error: " + ex.Message);
                }
            }
        }
    }
}