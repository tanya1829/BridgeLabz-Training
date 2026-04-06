using System;
using System.Text.RegularExpressions;

class CensorBadWords
{
    static void Main()
    {
        Console.Write("Enter sentence: ");
        string text = Console.ReadLine();

        string pattern = @"\b(damn|stupid)\b";
        string result = Regex.Replace(text, pattern, "****", RegexOptions.IgnoreCase);

        Console.WriteLine("Censored text:");
        Console.WriteLine(result);
    }
}
