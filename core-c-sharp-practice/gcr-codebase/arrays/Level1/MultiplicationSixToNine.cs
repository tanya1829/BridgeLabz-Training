using System;

class MultiplicationSixToNine
{
    static void Main()
    {
        // Taking input number
        Console.Write("Enter the number: ");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.Error.WriteLine(" Input is Invalid .");
            Environment.Exit(1);
        }

        // Declaring array to store results
        int[] results = new int[4];
        int index = 0;

        // Generating table from 6 to 9
        for (int i = 6; i <= 9; i++)
        {
            results[index++] = number * i;
            Console.WriteLine($"{number} * {i} = {number * i}");
        }
    }
}
