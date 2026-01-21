using System;
using System.Collections.Generic;
using System.Text;

namespace EduResults
{
	internal interface IResult
	{
		void AddStudent();
		void AddDistrict();
		void AddScore();
		void ViewRank();
	}
}
