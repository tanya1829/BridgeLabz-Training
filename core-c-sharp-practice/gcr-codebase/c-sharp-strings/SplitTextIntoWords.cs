using System;

class SplitWordsWithoutSplit
{
    static void Main()
    {
        Console.Write("Enter sentence: ");
        string s = Console.ReadLine();

        SplitAndDisplay(s);
    }

    static void SplitAndDisplay(string s)
    {
        string word = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                word += s[i];
            }
            else
            {
                PrintWord(word);
                word = "";
            }
        }
        PrintWord(word);
    }

    static void PrintWord(string word)
    {
        if (word == "") return;

        int length = 0;
        foreach (char c in word)
            length++;

        Console.WriteLine(word + " -> " + length);
    }
}
