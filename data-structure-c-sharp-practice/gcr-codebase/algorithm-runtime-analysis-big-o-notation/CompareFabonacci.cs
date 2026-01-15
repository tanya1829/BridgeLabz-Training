using System;
using System.Diagnostics;

class FibonacciComparison
{
    static void Main()
    {
        int n = 40;   // keep small for recursion
        Stopwatch sw = new Stopwatch();

        // Recursive Fibonacci (O(2^N))
        sw.Start();
        int recResult = RecursiveFib(n);
        sw.Stop();
        Console.WriteLine("Recursive Result: " + recResult);
        Console.WriteLine("Recursive Time: " + sw.ElapsedMilliseconds + " ms");

        // Iterative Fibonacci (O(N))
        sw.Reset();
        sw.Start();
        int itrResult = IterativeFib(n);
        sw.Stop();
        Console.WriteLine("Iterative Result: " + itrResult);
        Console.WriteLine("Iterative Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static int RecursiveFib(int n)
    {
        if (n <= 1)
            return n;

        return RecursiveFib(n - 1) + RecursiveFib(n - 2);
    }

    static int IterativeFib(int n)
    {
        if (n <= 1)
            return n;

        int a = 0, b = 1, c = 0;

        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return b;
    }
}