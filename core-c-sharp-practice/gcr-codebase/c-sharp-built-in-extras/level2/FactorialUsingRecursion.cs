using System;

class FactorialUsingRecursion
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Factorial: " + Factorial(n));
    }

    static int Factorial(int n)
    {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }
}
