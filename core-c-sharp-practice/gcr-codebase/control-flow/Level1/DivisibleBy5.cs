using System;

class DivisibleBy5
{
    static void Main()
	
    {
        Console.Write("Enter the number : ");
     
	     int number = Convert.ToInt32(Console.ReadLine());

        bool result = (number % 5 == 0);
		
        Console.WriteLine($"Is the number {number} divisible by 5? {result}");
    }
}
