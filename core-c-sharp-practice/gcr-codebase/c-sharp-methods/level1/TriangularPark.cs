using System;
class TriangularPark
{
	static void Main()
	{
		Console.Write(" enter the side 1 ");
		double a= Convert.ToDouble(Console.ReadLine());
		
		Console.Write("Enter the side 2");
		double b= Convert.ToDouble(Console.ReadLine());
		  
		Console.Write("Enter the side 3");
        double c= 	Convert.ToDouble(Console.ReadLine());
		
		double rounds = CalculateRounds(a,b,c);
		Console.WriteLine(" No of rounds required to complete 5km " rounds);
		
		static double CalculateRounds(double a, double b, double c)
    {
        double perimeter = (a + b + c);
        return 5000 / perimeter;
	}
	
}