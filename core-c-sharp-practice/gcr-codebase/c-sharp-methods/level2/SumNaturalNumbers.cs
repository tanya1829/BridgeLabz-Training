using System;

class SumNaturalNumbers
{
    static void Main()
    {
        Console.Write("Enter a natural number: ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Not a natural number!");
            return;
        }

        int sumRec = SumRecursive(n);
        int sumFormula = n * (n + 1) / 2;

        Console.WriteLine("Sum (Recursive): " + sumRec);
        Console.WriteLine("Sum (Formula): " + sumFormula);
    }

    static int SumRecursive(int n)
    {
        if (n == 1) return 1;
        return n + SumRecursive(n - 1);
    }
}
