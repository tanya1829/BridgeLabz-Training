using System;

class FactorialUsingFor
{
    static void Main()
	
    {
        int no = Convert.ToInt32(Console.ReadLine());
		
        int fact = 1;

        for (int i = 1; i <= no; i++)
            
		     fact *= i;

        Console.WriteLine($"Factorial = {fact}");
    }
}
