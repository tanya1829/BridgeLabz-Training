using System;
using System.Text.RegularExpressions;

class ExtractLinksFromWebpage
{
    static void Main()
    {
        Console.Write("Enter text with links: ");
        string text = Console.ReadLine();

        string pattern = @"https?://\S+";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Links found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
