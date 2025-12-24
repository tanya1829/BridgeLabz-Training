using System;

class TwoDArray
{
    static void Main(string[] args)
    {
        // Taking Input
        Console.Write("Enter number of rows : ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
        {
            Console.Error.WriteLine("Invalid rows input.");
            Environment.Exit(1);
        }

        // Taking input for columns
        Console.Write("Enter number of columns : ");
        if (!int.TryParse(Console.ReadLine(), out int columns) || columns <= 0)
        {
            Console.Error.WriteLine("Invalid columns input.");
            Environment.Exit(1);
        }

        // Creating 2D array
        int[,] matrix = new int[rows, columns];

        // Input elements
        Console.WriteLine(" Enter matrix elements : ");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.Error.WriteLine("Invalid matrix element.");
                    Environment.Exit(1);
                }
            }
        }

        // Displaying matrix and calculating sum
		
        int sum = 0;
        Console.WriteLine("\nMatrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
                sum += matrix[i, j];
            }
            Console.WriteLine();
        }

        // Displaying sum
		
        Console.WriteLine($"\nSum of all elements: {sum}");
    }
}
