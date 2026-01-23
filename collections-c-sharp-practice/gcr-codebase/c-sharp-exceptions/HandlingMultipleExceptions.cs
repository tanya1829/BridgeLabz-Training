using System;
using System.Collections.Generic;
using System.Text;
internal class HandlingMultipleExceptions
    {    
           public static void Main(string[] args)
            {
                try
                {
                    // Ask user for array size
                    Console.Write("Enter array size: ");
                    int size = int.Parse(Console.ReadLine());

                    // Initialize array
                    int[] arr = new int[size];

                    // Read array elements
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write("Enter element " + i + ": ");
                        arr[i] = int.Parse(Console.ReadLine());
                    }

                    // Ask user for index
                    Console.Write("Enter index to access: ");
                    int index = int.Parse(Console.ReadLine());

                    // Access and print value at index
                    Console.WriteLine("Value at index " + index + ": " + arr[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    // Executes when index is invalid
                    Console.WriteLine("Invalid index!");
                }
                catch (NullReferenceException)
                {
                    // Executes when array is not initialized
                    Console.WriteLine("Array is not initialized!");
                }
                catch (FormatException)
                {
                    // Handles non-numeric input
                    Console.WriteLine("Please enter valid numbers");
                }
            }
        }
