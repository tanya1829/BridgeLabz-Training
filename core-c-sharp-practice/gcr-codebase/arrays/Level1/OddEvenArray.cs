using System;

class OddEvenArray
{
    static void Main()
    {
        // Taking input number
        Console.Write("Enter a natural number: ");
        if (!int.TryParse(Console.ReadLine(), out int number) || number <= 0)
        {
            Console.Error.WriteLine("Invalid natural number.");
            Environment.Exit(1);
        }

        // Declaring arrays for odd and even numbers
        int[] even = new int[number / 2 + 1];
        int[] odd = new int[number / 2 + 1];

        // Index variables
        int evenIndex = 0, oddIndex = 0;

        // Separating odd and even numbers
        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
                even[evenIndex++] = i;
            else
                odd[oddIndex++] = i;
        }

        // Displaying odd numbers
        Console.WriteLine("Odd Numbers:");
        for (int i = 0; i < oddIndex; i++)
            Console.Write(odd[i] + " ");

        // Displaying even numbers
        Console.WriteLine("\nEven Numbers:");
        for (int i = 0; i < evenIndex; i++)
            Console.Write(even[i] + " ");
    }
}
