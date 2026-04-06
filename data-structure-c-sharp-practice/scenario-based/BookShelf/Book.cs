using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf
{
	internal class Book
	{
		public string Title;
		public string Author;

		public Book(string title, string author)
		{
			Title = title;
			Author = author;
		}
	}
}