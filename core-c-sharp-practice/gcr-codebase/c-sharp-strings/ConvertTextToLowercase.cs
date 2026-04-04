using System;

class ConvertTextToLowercase
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string s = Console.ReadLine();

        Console.WriteLine("Custom Lowercase: " + ToLower(s));
        Console.WriteLine("ToLower(): " + s.ToLower());
    }

    static string ToLower(string s)
    {
        string result = "";
        foreach (char c in s)
        {
            if (c >= 'A' && c <= 'Z')
                result += (char)(c + 32);
            else
                result += c;
        }
        return result;
    }
}
