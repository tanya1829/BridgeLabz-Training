using System;
using System.Text.RegularExpressions;

class ExtractProgrammingLanguagesName
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string pattern = @"\b(JavaScript|Java|Python|Go|C#)\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Languages found:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }
}
