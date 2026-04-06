using System;
using System.Text.RegularExpressions;

class ValidateCreditCard
{
    static void Main()
    {
        Console.Write("Enter card number: ");
        string card = Console.ReadLine();

        string pattern = @"^(4\d{15}|5\d{15})$";

        Console.WriteLine(
            Regex.IsMatch(card, pattern) ? "Valid Card" : "Invalid Card"
        );
    }
}
