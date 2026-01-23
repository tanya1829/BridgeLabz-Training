using System;
using System.Collections.Generic;
using System.Text;
 internal class DemonstratingFinallyBlockExecution
    {    
            public static void Main(string[] args)
            {
                try
                {
                    // Ask user for first number
                    Console.Write("Enter first number: ");
                    int num1 = int.Parse(Console.ReadLine());

                    // Ask user for second number
                    Console.Write("Enter second number: ");
                    int num2 = int.Parse(Console.ReadLine());

                    // Perform division
                    int result = num1 / num2;

                    // Print result if successful
                    Console.WriteLine("Result: " + result);
                }
                catch (DivideByZeroException)
                {
                    // Executes when denominator is zero
                    Console.WriteLine("Error: Cannot divide by zero");
                }
                finally
                {
                    // This block always executes
                    Console.WriteLine("Operation completed");
                }
            }
        }
    