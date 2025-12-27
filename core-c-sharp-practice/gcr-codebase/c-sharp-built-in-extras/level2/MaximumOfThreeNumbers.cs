using System;

class MaximumOfThreeNumbers
{
    static void Main()
    {
        int a = GetNumber("Enter first number:");
        int b = GetNumber("Enter second number:");
        int c = GetNumber("Enter third number:");

        int max = FindMax(a, b, c);
        Console.WriteLine("Maximum is: " + max);
    }

    static int GetNumber(string msg)
    {
        Console.WriteLine(msg);
        return int.Parse(Console.ReadLine());
    }

    static int FindMax(int x, int y, int z)
    {
        int max = x;
        if (y > max) max = y;
        if (z > max) max = z;
        return max;
    }
}
