using System;

class ReverseNumber
{
    static void Main()
    {
        // Taking input number
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int temp = number;
        int count = 0;

        
        while (temp > 0)
        {
            count++;
            temp /= 10;
        }

        
        int[] digits = new int[count];
        temp = number;

        // Store digits
        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        
        Console.Write("Reversed Number: ");
        for (int i = 0; i < digits.Length; i++)
        {
            Console.Write(digits[i]);
        }
    }
}
