using System;

class NaturalNumberSum
{
    static void Main()
    {
        int num = Convert.ToInt32(Console.ReadLine());

        if (num > 0)
			
        {
            int sum = num * (num + 1) / 2;
            Console.WriteLine($"The sum of {n} natural numbers is {sum}");
        }
		
        else
        {
			
            Console.WriteLine($"The number {n} is not a natural number");
        }
    }
}
