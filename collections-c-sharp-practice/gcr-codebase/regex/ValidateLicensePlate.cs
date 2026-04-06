using System;
using System.Text.RegularExpressions;

class ValidateLicensePlate
{
    static void Main()
    {
        Console.Write("Enter license plate: ");
        string plate = Console.ReadLine();

        string pattern = @"^[A-Z]{2}\d{4}$";

        Console.WriteLine(
            Regex.IsMatch(plate, pattern) ? "Valid Plate" : "Invalid Plate"
        );
    }
}
