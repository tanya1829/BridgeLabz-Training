using System;

class Program
{
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine()!);

        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine()!);

        int result = GCD(num1, num2);
        Console.WriteLine($"GCD of {num1} and {num2} is {result}");
    }
}
