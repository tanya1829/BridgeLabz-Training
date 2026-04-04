using System;

class SumOfDigits
{
    static void Main(string[] args)
    {
        // Taking input
        Console.Write("Enter a positive number: ");
        string input = Console.ReadLine();

        // Validating input
        if (!int.TryParse(input, out int number) || number < 0)
        {
            Console.Error.WriteLine("Invalid input. Please enter a positive integer.");
            Environment.Exit(1);
        }

        // Special case for 0
        if (number == 0)
        {
            Console.WriteLine("Sum of Digits: 0");
            Environment.Exit(0);
        }

        // Find number of digits
        int temp = number;
        int digitCount = 0;

        while (temp > 0)
        {
            digitCount++;
            temp /= 10;
        }

        // Storing digits in array
        int[] digits = new int[digitCount];
        temp = number;

        for (int i = 0; i < digits.Length; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        // Calculating sum of digits
        int sumOfDigits = 0;
        foreach (int digit in digits)
        {
            sumOfDigits += digit;
        }

        // Displaying result
        Console.WriteLine($"Sum of Digits: {sumOfDigits}");
    }
}
