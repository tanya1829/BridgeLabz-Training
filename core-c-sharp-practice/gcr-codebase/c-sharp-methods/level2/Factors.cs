using System;

class Factors
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int[] factors = GetFactors(n);

        Console.WriteLine("Factors: " + string.Join(", ", factors));
        Console.WriteLine("Sum: " + Sum(factors));
        Console.WriteLine("Sum of squares: " + SumOfSquares(factors));
        Console.WriteLine("Product: " + Product(factors));
    }

    static int[] GetFactors(int num)
    {
        int count = 0;
        for (int i = 1; i <= num; i++)
            if (num % i == 0) count++;

        int[] arr = new int[count];
        int index = 0;
        for (int i = 1; i <= num; i++)
            if (num % i == 0) arr[index++] = i;

        return arr;
    }

    static int Sum(int[] arr)
    {
        int sum = 0;
        foreach (int x in arr) sum += x;
        return sum;
    }

    static int SumOfSquares(int[] arr)
    {
        int sum = 0;
        foreach (int x in arr) sum += (int)Math.Pow(x, 2);
        return sum;
    }

    static int Product(int[] arr)
    {
        int prod = 1;
        foreach (int x in arr) prod *= x;
        return prod;
    }
}
