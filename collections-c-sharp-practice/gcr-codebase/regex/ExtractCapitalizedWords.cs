using System;
using System.Text.RegularExpressions;

class ExtractCapitalizedWords
{
    static void Main()
    {
        Console.Write("Enter sentence: ");
        string text = Console.ReadLine();

        string pattern = @"\b[A-Z][a-z]*\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Capitalized words:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
