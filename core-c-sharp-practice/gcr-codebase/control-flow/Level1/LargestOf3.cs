using System;

class LargestOf3
{
    static void Main()
    {    
	    Console.Write("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
		
		 Console.Write("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
		
		 Console.Write("Enter the third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Is the first number the largest? {num1 > num2 && num1 > num3}");
		
        
		Console.WriteLine($"Is the second number the largest? {num2 > num1 && num2 > num3}");
        
		Console.WriteLine($"Is the third number the largest? {num3 > num1 && num3 > num2}");
    }
}
