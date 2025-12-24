using System;

class MeanHeight
{
    static void Main()
    {
        // Declaring array for heights
        double[] heights = new double[11];

        // Variable to store sum
        double sum = 0.0;

        // Taking height input
        for (int i = 0; i < heights.Length; i++)
        {
            Console.Write($"Enter height of player {i + 1}: ");
            if (!double.TryParse(Console.ReadLine(), out heights[i]))
            {
                Console.Error.WriteLine("Invalid input.");
                Environment.Exit(1);
            }
            sum += heights[i];
        }

        // Calculating mean height
        double mean = sum / heights.Length;

        // Displaying mean height
        Console.WriteLine($"Mean height of football team: {mean}");
    }
}
