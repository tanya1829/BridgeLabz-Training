using System;

class FactorialUsingWhile
{
    static void Main()
    {
        int no = Convert.ToInt32(Console.ReadLine());

        int fact = 1, i = 1;

        while (i <= no)
        
            fact *= i++;

        Console.WriteLine($"Factorial = {fact}");
    }
}
