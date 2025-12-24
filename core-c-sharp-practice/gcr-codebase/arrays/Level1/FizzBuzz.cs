using System;

class FizzBuzz
{
    static void Main()
    {
        // Taking user input
        Console.Write("Enter a positive number: ");
        if (!int.TryParse(Console.ReadLine(), out int number) || number <= 0)
        {
            Console.Error.WriteLine("Invalid input.");
            Environment.Exit(1);
        }

        // Declaring string array to store results
        string[] results = new string[number + 1];

        // Storing FizzBuzz results
        for (int i = 1; i <= number; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                results[i] = "FizzBuzz";
            else if (i % 3 == 0)
                results[i] = "Fizz";
            else if (i % 5 == 0)
                results[i] = "Buzz";
            else
                results[i] = i.ToString();
        }

        // Displaying results
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine($"Position {i} = {results[i]}");
        }
    }
}
