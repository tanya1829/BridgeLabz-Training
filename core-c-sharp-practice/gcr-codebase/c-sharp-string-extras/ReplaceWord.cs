using System;

class ReplaceWord
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine() ?? "";

        Console.WriteLine("Enter word to replace:");
        string oldWord = Console.ReadLine() ?? "";

        Console.WriteLine("Enter new word:");
        string newWord = Console.ReadLine() ?? "";

        string word = "";
        string result = "";

        for (int i = 0; i <= sentence.Length; i++)
        {
            char ch;

            if (i == sentence.Length)
                ch = ' ';
            else
                ch = sentence[i];

            if (ch != ' ')
            {
                word = word + ch;
            }
            else
            {
                if (word == oldWord)
                    result = result + newWord + " ";
                else
                    result = result + word + " ";

                word = "";
            }
        }

        Console.WriteLine("Modified sentence:");
        Console.WriteLine(result);
    }
}
