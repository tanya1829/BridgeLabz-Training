using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf
{
	 internal interface IBookShelf
	{
		void AddBook();
		void BorrowBook();
		void DisplayLibrary();

	}
}