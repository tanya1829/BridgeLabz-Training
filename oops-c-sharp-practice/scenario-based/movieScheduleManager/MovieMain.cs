using System;
using System.Collections.Generic;
using System.Text;

namespace movieScheduleManager
{
	internal class MovieMain
	{
		public static void Main(string[] args)
		{
			MovieMenu utility = new MovieMenu();

			utility.ShowMenu();
		}
	}
}
