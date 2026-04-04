using System;

class ReversePalindromeDuckNumber
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

    // Reverse digits array
    public static int[] ReverseDigits(int[] digits)
    {
        int[] rev = new int[digits.Length];
        for (int i = 0; i < digits.Length; i++)
            rev[i] = digits[digits.Length - 1 - i];
        return rev;
    }

    // Check palindrome
    public static bool IsPalindrome(int[] digits)
    {
        int[] rev = ReverseDigits(digits);
        for (int i = 0; i < digits.Length; i++)
            if (digits[i] != rev[i]) return false;
        return true;
    }

    // Check duck number
    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int d in digits)
            if (d != 0) return true;
        return false;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(number);

        Console.WriteLine($"Digits: [{string.Join(", ", digits)}]");
        Console.WriteLine($"Reversed Digits: [{string.Join(", ", ReverseDigits(digits))}]");
        Console.WriteLine($"Is Palindrome: {IsPalindrome(digits)}");
        Console.WriteLine($"Is Duck Number: {IsDuckNumber(digits)}");
    }
}
