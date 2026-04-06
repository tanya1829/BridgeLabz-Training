using System;
using System.Collections.Generic;
using System.Text;
  // Step 1: Create a custom exception class
    internal class CreatingHandlingCustomException : Exception
    {     
            public CreatingHandlingCustomException(string message) : base(message)
            {
            }
        }

        internal class AgeValidation
        {
            // Step 2: Method to validate age
            static void ValidateAge(int age)
            {
                // If age is less than 18, throw custom exception
                if (age < 18)
                {
                    throw new CreatingHandlingCustomException("Age must be 18 or above");
                }

                // If age is valid
                Console.WriteLine("Age is valid. Access granted.");
            }

            public static void Main(string[] args)
            {
                try
                {
                    // Ask user for age
                    Console.Write("Enter your age: ");
                    int age = int.Parse(Console.ReadLine());

                    // Call validation method
                    ValidateAge(age);
                }
                catch (CreatingHandlingCustomException ex)
                {
                    // Handle custom exception
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    // Handle non-numeric input
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    