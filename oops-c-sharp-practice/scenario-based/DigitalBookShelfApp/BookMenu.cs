using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBookShelfApp
{
    internal class BookMenu
    {
		public void ShowMenu()
		{
			BookUtility utility = new BookUtility();
			while (true)
			{
				Console.WriteLine("\nBookBuddy ");
				Console.WriteLine("1. Add Book");
				Console.WriteLine("2. Sort Books");
				Console.WriteLine("3. Search book by author");
				Console.WriteLine("4. Exit");
				Console.Write("Enter choice: ");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						utility.AddBook();
						break;

					case 2:
						Console.Write("Enter Book to Sort: ");
						utility.SortBook();
						break;

					case 3:
						Console.WriteLine("Enter Book Name to Search: ");
						utility.SearchBook();
						break;

					case 4:
						Console.WriteLine("Exiting bookBuddy...");
						return;

					default:
						Console.WriteLine("Invalid choice.");
						break;
				}
			}
		}
	}
}
