using System;
using System.Collections.Generic;
using System.Text;
internal class NestedTryCatchBlocks
    {
            public static void Main(string[] args)
            {
                // Sample array
                int[] numbers = { 10, 20, 30, 40 };

                try
                {
                    // Ask user for index
                    Console.Write("Enter index: ");
                    int index = int.Parse(Console.ReadLine());

                    // Try to access array element
                    int value = numbers[index];

                    try
                    {
                        // Ask user for divisor
                        Console.Write("Enter divisor: ");
                        int divisor = int.Parse(Console.ReadLine());

                        // Try division
                        int result = value / divisor;

                        // Print result
                        Console.WriteLine("Result: " + result);
                    }
                    catch (DivideByZeroException)
                    {
                        // Handles division by zero
                        Console.WriteLine("Cannot divide by zero!");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Handles invalid array index
                    Console.WriteLine("Invalid array index!");
                }
            }
        }


