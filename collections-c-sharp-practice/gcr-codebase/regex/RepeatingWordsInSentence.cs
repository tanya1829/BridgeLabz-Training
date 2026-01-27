using System;
using System.Text.RegularExpressions;

class RepeatingWordsInSentence
{
    static void Main()
    {
        Console.Write("Enter sentence: ");
        string text = Console.ReadLine();

        string pattern = @"\b(\w+)\s+\1\b";
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("Repeating words:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Groups[1].Value);
        }
    }
}
