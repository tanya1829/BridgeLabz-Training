using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBookShelfApp
{
    internal class BookUtility
    {
		private string[] title;
		private string[] author;

		// Add Book
		public void AddBook()
		{
			Console.WriteLine("How many books you want to store");
			int numberBooks = int.Parse(Console.ReadLine());

			title = new string[numberBooks];
			author = new string[numberBooks];

			for (int i = 0; i < numberBooks; i++)
			{
				Console.Write($"Enter title of book {i + 1}: ");
				title[i] = Console.ReadLine();

				Console.Write($"Enter author of book {i + 1}: ");
				author[i] = Console.ReadLine();

				Console.WriteLine("Book added successfully!");
			}
		}

		// Sort Books by Title
		public void SortBook()
		{
			if (title == null || title.Length == 0)
			{
				Console.WriteLine("No books to sort.");
				return;
			}

			for (int i = 0; i < title.Length - 1; i++)
			{
				for (int j = i + 1; j < title.Length; j++)
				{
					if (string.Compare(title[i], title[j]) > 0)
					{
						// swap title
						string tempTitle = title[i];
						title[i] = title[j];
						title[j] = tempTitle;

						// swap author
						string tempAuthor = author[i];
						author[i] = author[j];
						author[j] = tempAuthor;
					}
				}
			}

			Console.WriteLine("\nBooks sorted successfully by title.\n");

			for (int i = 0; i < title.Length; i++)
			{
				Console.WriteLine("Title  : " + title[i]);
				Console.WriteLine("Author : " + author[i]);
			}
		}


		// Search Book by Author
		public void SearchBook()
		{
			if (title == null || title.Length == 0)
			{
				Console.WriteLine("No books available.");
				return;
			}

			Console.Write("Enter author name to search: ");
			string searchAuthor = Console.ReadLine();

			bool found = false;

			for (int i = 0; i < title.Length; i++)
			{
				if (author[i].Equals(searchAuthor, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Book Found:");
					Console.WriteLine("Title  : " + title[i]);
					Console.WriteLine("Author : " + author[i]);
					found = true;
				}
			}

			if (!found)
			{
				Console.WriteLine("No book found for given author.");
			}
		}
	}
}