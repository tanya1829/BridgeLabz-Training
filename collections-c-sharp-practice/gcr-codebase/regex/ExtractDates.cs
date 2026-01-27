using System;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        Console.Write("Enter text with dates: ");
        string text = Console.ReadLine();

        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Dates found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
