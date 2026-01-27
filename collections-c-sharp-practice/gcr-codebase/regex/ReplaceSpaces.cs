using System;
using System.Text.RegularExpressions;

class ReplaceSpaces
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string result = Regex.Replace(text, @"\s+", " ");

        Console.WriteLine("Result:");
        Console.WriteLine(result);
    }
}
