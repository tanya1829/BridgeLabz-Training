using System;

class PrimeNumber
{
    static void Main(String[] args)
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 1)
        {
            Console.WriteLine("Not a Prime Number");
            return;
        }

        bool isPrime = true;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
            Console.WriteLine("Prime Number");
        else
            Console.WriteLine("Not a Prime Number");
    }
}
