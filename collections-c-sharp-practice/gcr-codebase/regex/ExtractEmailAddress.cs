using System;
using System.Text.RegularExpressions;

class ExtractEmailAddress
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string pattern = @"[\w.-]+@[\w.-]+\.\w+";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Emails found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
