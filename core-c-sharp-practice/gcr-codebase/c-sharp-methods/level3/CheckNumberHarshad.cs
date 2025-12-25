using System;

class NumberCheckerQ3
{
    // Count digits
    public static int CountDigits(int number)
    {
        int count = 0;
        while (number > 0)
        {
            count++;
            number /= 10;
        }
        return count;
    }

    // Get digits array
    public static int[] GetDigits(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];
        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    // Sum of digits
    public static int SumDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits) sum += d;
        return sum;
    }

    // Sum of squares of digits
    public static int SumSquares(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits) sum += (int)Math.Pow(d, 2);
        return sum;
    }

    // Check if number is Harshad
    public static bool IsHarshad(int number, int[] digits)
    {
        int sum = SumDigits(digits);
        return number % sum == 0;
    }

    // Frequency of digits
    public static int[,] DigitFrequency(int[] digits)
    {
        int[,] freq = new int[10, 2]; // [digit, frequency]
        for (int i = 0; i < 10; i++) freq[i, 0] = i;

        foreach (int d in digits) freq[d, 1]++;

        return freq;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(number);

        Console.WriteLine($"Digits: [{string.Join(", ", digits)}]");
        Console.WriteLine($"Sum of Digits: {SumDigits(digits)}");
        Console.WriteLine($"Sum of Squares of Digits: {SumSquares(digits)}");
        Console.WriteLine($"Is Harshad Number: {IsHarshad(number, digits)}");

        Console.WriteLine("Digit Frequencies:");
        int[,] freq = DigitFrequency(digits);
        for (int i = 0; i < 10; i++)
        {
            if (freq[i, 1] > 0)
                Console.WriteLine($"Digit {freq[i, 0]}: {freq[i, 1]} times");
        }
    }
}
