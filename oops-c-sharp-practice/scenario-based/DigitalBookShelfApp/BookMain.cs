using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBookShelfApp
{
    internal class BookMain
    {
		public static void Main(string[] args)
		{
			BookMenu utility = new BookMenu();

			utility.ShowMenu();
		}
	}
}