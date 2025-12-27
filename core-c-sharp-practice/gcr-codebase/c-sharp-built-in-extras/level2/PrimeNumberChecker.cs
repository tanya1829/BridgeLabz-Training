using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int num = int.Parse(Console.ReadLine());

        if (IsPrime(num))
            Console.WriteLine("Prime Number");
        else
            Console.WriteLine("Not Prime");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
