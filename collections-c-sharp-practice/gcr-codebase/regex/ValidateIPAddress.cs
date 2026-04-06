using System;
using System.Text.RegularExpressions;

class ValidateIPAddress
{
    static void Main()
    {
        Console.Write("Enter IP address: ");
        string ip = Console.ReadLine();

        string pattern =
            @"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}" +
            @"(25[0-5]|2[0-4]\d|[01]?\d\d?)$";

        Console.WriteLine(
            Regex.IsMatch(ip, pattern) ? "Valid IP" : "Invalid IP"
        );
    }
}
