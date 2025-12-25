using System;
class CheckNumber
{
	static void Main()
	{
		Console.Write("Enter a number");
		int n = Convert.ToInt32(Console.ReadLine());
		int result = NumberCheckk(n);
		Console.WriteLine("Result" + result);
	}
	static int NumberCheckk(int n){
		if(n >0)
			return 1;
		else if(n<0)
			return -1;
		else
			return 0;
	}
}
