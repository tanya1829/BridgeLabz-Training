using System;

class SmallestOf3
{
    static void Main()
    {
        int num1 = Convert.ToInt32(Console.ReadLine());
		
        int num2 = Convert.ToInt32(Console.ReadLine());
        
		int num3 = Convert.ToInt32(Console.ReadLine());

        bool isSmallest = (num1 < num2 && num1 < num3);
		
        Console.WriteLine($"Is the first number the smallest? {isSmallest}");
    }
}
