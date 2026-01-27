using System;
using System.Text.RegularExpressions;

class SocialSecurityNumber
{
    static void Main()
    {
        Console.Write("Enter SSN: ");
        string ssn = Console.ReadLine();

        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        Console.WriteLine(
            Regex.IsMatch(ssn, pattern) ? "Valid SSN" : "Invalid SSN"
        );
    }
}
