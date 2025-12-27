using System;

class UppercaseASCII
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string str = Console.ReadLine();

        Console.WriteLine(  ToUpper(s));
        Console.WriteLine( s.ToUpper());
    }

    static string ToUpper(string s)
    {
        string result = "";
        foreach (char c in s)
        {
            if (c >= 'a' && c <= 'z')
                result += (char)(c - 32);
            else
                result += c;
        }
        return result;
    }
}
