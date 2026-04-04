using System;
class QuotientRemainder
{
	static void Main()
	{
		Console.Write("Enter the number :");
		int numberr = Convert.ToInt32(Console.ReadLine());
		 
		 Console.write("Enter the divisor");
		 int divisor = Convert.ToInt32(Console.ReadLine());
		 
		 int[] result = FindRemainderAndQuotient(numberr, divisor);
		 
		 Console.WriteLine("Quotient : " + result[0]);
		 Console.WriteLine("Remainder : " + result[1]);
	}
	public static int[] FindReaminderAndQuotient(int numberr, int divisor)
	{
		return new int[] {number / divisor , number % divisor};
	}
}
	