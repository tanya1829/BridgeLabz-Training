
using System;

class PrimeNeonSpyBuzz
{
    public static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }

    public static bool IsNeon(int n)
    {
        int square = n * n;
        int sum = 0;
        while (square > 0)
        {
            sum += square % 10;
            square /= 10;
        }
        return sum == n;
    }

    public static bool IsSpy(int n)
    {
        int sum = 0, product = 1;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit;
            product *= digit;
            n /= 10;
        }
        return sum == product;
    }

    public static bool IsAutomorphic(int n)
    {
        int square = n * n;
        string str = square.ToString();
        string end = str.Substring(str.Length - n.ToString().Length);
        return end == n.ToString();
    }

    public static bool IsBuzz(int n)
    {
        return n % 7 == 0 || n % 10 == 7;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Is Prime: {IsPrime(number)}");
        Console.WriteLine($"Is Neon: {IsNeon(number)}");
        Console.WriteLine($"Is Spy: {IsSpy(number)}");
        Console.WriteLine($"Is Automorphic: {IsAutomorphic(number)}");
        Console.WriteLine($"Is Buzz: {IsBuzz(number)}");
    }
}
