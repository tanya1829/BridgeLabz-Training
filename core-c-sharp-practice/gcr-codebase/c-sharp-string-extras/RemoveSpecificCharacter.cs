using System;

class RemoveSpecificCharacter
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string str = Console.ReadLine() ?? "";

        Console.WriteLine("Enter character to remove:");
        char remove = Console.ReadLine()[0];

        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != remove)
                result += str[i];
        }

        Console.WriteLine("Modified string: " + result);
    }
}
