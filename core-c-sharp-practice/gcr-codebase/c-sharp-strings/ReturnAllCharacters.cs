using System;

class ReturnAllCharacters
{
    static char[] GetChars(string s)
    {
        char[] arr = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            arr[i] = s[i];
        }
        return arr;
    }

    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string s1 = Console.ReadLine() ?? "";

        char[] custom = GetChars(s1);
        char[] builtIn = s1.ToCharArray();

        Console.WriteLine("Custom output: " + new string(custom));
        Console.WriteLine("Built-in output: " + new string(builtIn));
    }
}
