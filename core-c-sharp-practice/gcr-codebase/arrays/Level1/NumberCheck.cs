using System;

class NumberCheck
{
    static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Error.WriteLine("Invalid input.");
				
                Environment.Exit(1);
            }
        }

        foreach (int num in numbers)
        {
            if (num > 0)
            {
                Console.WriteLine(num % 2 == 0 ? $"{num} is Positive and Even" : $"{num} is Positive and Odd");
            }
            else if (num < 0)
            {
                Console.WriteLine($"{num} is Negative");
            }
            else
            {
                Console.WriteLine("Number is Zero");
            }
        }

        if (numbers[0] == numbers[^1])
            Console.WriteLine("First and last elements are equal.");
        else if (numbers[0] > numbers[^1])
            Console.WriteLine("First element is greater.");
        else
            Console.WriteLine("Last element is greater.");
    }
}
