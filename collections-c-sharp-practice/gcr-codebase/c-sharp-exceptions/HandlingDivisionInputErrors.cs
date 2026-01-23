using System;
using System.Collections.Generic;
using System.Text;

    internal class HandlingDivisionInputErrors
    {     
           public static void Main(string[] args)
            {
                try
                {
                    // Ask user to enter first number
                    Console.Write("Enter first number: ");
                    int num1 = int.Parse(Console.ReadLine());

                    // Ask user to enter second number
                    Console.Write("Enter second number: ");
                    int num2 = int.Parse(Console.ReadLine());

                    // Perform division
                    int result = num1 / num2;

                    // Print result
                    Console.WriteLine("Result: " + result);
                }
                catch (DivideByZeroException)
                {
                    // Executes when denominator is zero
                    Console.WriteLine("Error: Cannot divide by zero");
                }
                catch (FormatException)
                {
                    // Executes when input is not a number
                    Console.WriteLine("Error: Please enter valid numeric values");
                }
            }
        }
