using System;

class FactorsPerfectAbundant
{
    // Find all factors of a number
    public static int[] GetFactors(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0) count++;

        int[] factors = new int[count];
        int index = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0) factors[index++] = i;
        }
        return factors;
    }

    // Greatest factor
    public static int GreatestFactor(int[] factors)
    {
        return factors[factors.Length - 1];
    }

    // Sum of factors
    public static int SumFactors(int[] factors)
    {
        int sum = 0;
        foreach (int f in factors) sum += f;
        return sum;
    }

    // Product of factors
    public static long ProductFactors(int[] factors)
    {
        long product = 1;
        foreach (int f in factors) product *= f;
        return product;
    }

    // Product of cubes of factors
    public static long ProductCubesFactors(int[] factors)
    {
        long product = 1;
        foreach (int f in factors) product *= (long)Math.Pow(f, 3);
        return product;
    }

    // Perfect number
    public static bool IsPerfect(int n)
    {
        int sum = 0;
        for (int i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum == n;
    }

    // Abundant number
    public static bool IsAbundant(int n)
    {
        int sum = 0;
        for (int i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum > n;
    }

    // Deficient number
    public static bool IsDeficient(int n)
    {
        int sum = 0;
        for (int i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum < n;
    }

    // Strong number (sum of factorial of digits = number)
    public static bool IsStrong(int n)
    {
        int original = n;
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += Factorial(digit);
            n /= 10;
        }
        return sum == original;
    }

    public static int Factorial(int x)
    {
        int fact = 1;
        for (int i = 2; i <= x; i++) fact *= i;
        return fact;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = GetFactors(number);
        Console.WriteLine($"Factors: [{string.Join(", ", factors)}]");
        Console.WriteLine($"Greatest Factor: {GreatestFactor(factors)}");
        Console.WriteLine($"Sum of Factors: {SumFactors(factors)}");
        Console.WriteLine($"Product of Factors: {ProductFactors(factors)}");
        Console.WriteLine($"Product of Cubes of Factors: {ProductCubesFactors(factors)}");
        Console.WriteLine($"Is Perfect: {IsPerfect(number)}");
        Console.WriteLine($"Is Abundant: {IsAbundant(number)}");
        Console.WriteLine($"Is Deficient: {IsDeficient(number)}");
        Console.WriteLine($"Is Strong: {IsStrong(number)}");
    }
}
