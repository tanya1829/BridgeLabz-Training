using System;

class NumberChecker
{
    // Method to count digits in a number
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

    // Method to extract digits into an array
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

    // Method to check if number is a duck number (contains non-zero digits)
    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int digit in digits)
        {
            if (digit != 0) return true;
        }
        return false;
    }

    // Method to check if number is an Armstrong number
    public static bool IsArmstrong(int[] digits)
    {
        int n = digits.Length;
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += (int)Math.Pow(digit, n);
        }
        int originalNumber = 0;
        foreach (int d in digits)
            originalNumber = originalNumber * 10 + d;

        return sum == originalNumber;
    }

    // Method to find largest and second largest digits
    public static int[] LargestTwo(int[] digits)
    {
        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (int digit in digits)
        {
            if (digit > largest)
            {
                secondLargest = largest;
                largest = digit;
            }
            else if (digit > secondLargest && digit != largest)
            {
                secondLargest = digit;
            }
        }

        return new int[] { largest, secondLargest };
    }

    // Method to find smallest and second smallest digits
    public static int[] SmallestTwo(int[] digits)
    {
        int smallest = int.MaxValue;
        int secondSmallest = int.MaxValue;

        foreach (int digit in digits)
        {
            if (digit < smallest)
            {
                secondSmallest = smallest;
                smallest = digit;
            }
            else if (digit < secondSmallest && digit != smallest)
            {
                secondSmallest = digit;
            }
        }

        return new int[] { smallest, secondSmallest };
    }

    // Main method
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(number);

        Console.WriteLine($"Number of Digits: {CountDigits(number)}");
        Console.WriteLine($"Digits Array: [{string.Join(", ", digits)}]");
        Console.WriteLine($"Is Duck Number: {IsDuckNumber(digits)}");
        Console.WriteLine($"Is Armstrong Number: {IsArmstrong(digits)}");

        int[] largest = LargestTwo(digits);
        Console.WriteLine($"Largest: {largest[0]}, Second Largest: {largest[1]}");

        int[] smallest = SmallestTwo(digits);
        Console.WriteLine($"Smallest: {smallest[0]}, Second Smallest: {smallest[1]}");
    }
}