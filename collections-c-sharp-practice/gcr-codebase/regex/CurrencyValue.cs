using System;
using System.Text.RegularExpressions;

class CurrencyValue
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        string pattern = @"\$?\s?\d+\.\d{2}";
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Currency values:");
        foreach (Match m in matches)
        {
            Console.WriteLine(m.Value.Trim());
        }
    }
}
