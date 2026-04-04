using System;

class StoreNumbers
{
    static void Main()
    {
        // Declaring array to store values
        double[] numbers = new double[10];

        // Variable to store total sum
        double total = 0.0;

        // Indexing variable for array
        int index = 0;

        // Infinite loop for user input
       
	   while (true)
        {
            Console.Write("Enter the number: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.Error.WriteLine("Invalid input.");
                Environment.Exit(1);
            }

            // Break if value is zero/negative or array limit reached
            if (value <= 0 || index == numbers.Length)
                break;

            // Store value in array and increment index
            numbers[index++] = value;
        }

          // Calculating total sum
          for (int i = 0; i < index; i++)
        {
            total += numbers[i];
        }

        // Displaying total
        Console.WriteLine($"Total sum: {total}");
    }
}
