using System;
using System.Collections.Generic;
using System.Text;
 internal class HandlingInvalidInput
    {
            // Method to calculate simple interest
            static double CalculateInterest(double amount, double rate, int years)
            {
                // Check for invalid input
                if (amount < 0 || rate < 0)
                {
                    // Throw exception if amount or rate is negative
                    throw new ArgumentException("Amount and rate must be positive");
                }

                // Simple Interest formula
                double interest = (amount * rate * years) / 100;
                return interest;
            }

            public static void Main(string[] args)
            {
                try
                {
                    // Take user inputs
                    Console.Write("Enter amount: ");
                    double amount = double.Parse(Console.ReadLine());

                    Console.Write("Enter rate of interest: ");
                    double rate = double.Parse(Console.ReadLine());

                    Console.Write("Enter number of years: ");
                    int years = int.Parse(Console.ReadLine());

                    // Call interest calculation method
                    double result = CalculateInterest(amount, rate, years);

                    // Print calculated interest
                    Console.WriteLine("Calculated Interest: " + result);
                }
                catch (ArgumentException)
                {
                    // Handle invalid input exception
                    Console.WriteLine("Invalid input: Amount and rate must be positive");
                }
                catch (FormatException)
                {
                    // Handle non-numeric input
                    Console.WriteLine("Please enter valid numeric values");
                }
            }
        }
    