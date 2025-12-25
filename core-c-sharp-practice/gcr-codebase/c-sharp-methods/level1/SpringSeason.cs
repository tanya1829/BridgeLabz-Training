using System;
class SpringSeason
{
	ststic void main(string [] args){
		int month = Convert.ToInt32(args[0]);
		int day = Conver.ToInt32(args[1]);
		bool isSpringg = IsSpringSeason(month,day);
		if(isSpringg)
			Vonsole.WriteLine("Its a spring season");
		else
			Console.WriteLine("Not a spring seaosn");
	}
	static bool IsSpringSeason(int month, int day)
	{
		return (month == 3 && day>=20) ||
		 (month==4 || month ==5)||
		 (month==6 && day<=20);
	}
	
}