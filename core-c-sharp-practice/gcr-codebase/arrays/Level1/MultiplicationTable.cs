using System;

class MultiplicationTable
{
    static void Main()
    {
        // Taking input number
        Console.Write("Enter a number: ");
        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.Error.WriteLine("Invalid input.");
            Environment.Exit(1);
        }

        // Declaring array to store multiplication results
        int[] table = new int[10];

        // Generating multiplication table
		
        for (int i = 1; i <= table.Length; i++)
        {
            table[i - 1] = number * i;
			
            Console.WriteLine($"{number} * {i} = {table[i - 1]}");
        }
    }
}
