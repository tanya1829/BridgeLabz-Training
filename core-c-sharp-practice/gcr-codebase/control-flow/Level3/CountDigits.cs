using System;

class CountDigits
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int count = 0;

        while (number != 0)
        {
            number = number / 10; // remove last digit
            count++;
        }

        Console.WriteLine("Number of digits = " + count);
    }
}
