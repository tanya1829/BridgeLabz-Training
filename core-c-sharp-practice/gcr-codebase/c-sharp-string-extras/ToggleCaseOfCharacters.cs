using System;

class ToggleCaseOfCharacters
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine() ?? "";

        string result = "";

        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];

            if (ch >= 'A' && ch <= 'Z')
            {
                ch = (char)(ch + 32);
            }
            else if (ch >= 'a' && ch <= 'z')
            {
                ch = (char)(ch - 32);
            }

            result = result + ch;
        }

        Console.WriteLine("Toggled string: " + result);
    }
}
