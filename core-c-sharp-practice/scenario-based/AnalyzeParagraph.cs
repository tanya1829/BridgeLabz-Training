using System;

class AnalyzeParagraph
{
    static void Main()
    {
        Console.WriteLine("Enter a paragraph:");
        string text = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("word count = 0");
            Console.WriteLine("longest word = ");
            Console.WriteLine("result = ");
            return;
        }

        int words = GetWordCount(text);
        string longest = FindLongestWord(text);

        Console.WriteLine("word count = " + words);
        Console.WriteLine("longest word = " + longest);

        Console.WriteLine("Enter word to replace:");
        string target = Console.ReadLine();

        Console.WriteLine("Enter new word:");
        string replacement = Console.ReadLine();

        string updatedText = ManualReplace(text, target, replacement);
        Console.WriteLine("result = " + updatedText);
    }

    static int GetWordCount(string text)
    {
        int count = 0;
        bool letterFound = false;

        foreach (char ch in text)
        {
            if (ch != ' ' && !letterFound)
            {
                count++;
                letterFound = true;
            }
            else if (ch == ' ')
            {
                letterFound = false;
            }
        }
        return count;
    }

    static string FindLongestWord(string text)
    {
        string[] words = ExtractWords(text);
        string longest = "";

        foreach (string w in words)
        {
            if (w.Length > longest.Length)
                longest = w;
        }
        return longest;
    }

    static string[] ExtractWords(string text)
    {
        int size = GetWordCount(text);
        string[] result = new string[size];

        string temp = "";
        int pos = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
            {
                temp += text[i];
            }
            else if (temp != "")
            {
                result[pos++] = temp;
                temp = "";
            }
        }

        if (temp != "")
            result[pos] = temp;

        return result;
    }

    static string ManualReplace(string text, string oldVal, string newVal)
    {
        string output = "";
        int idx = 0;

        while (idx < text.Length)
        {
            if (IsSameWord(text, oldVal, idx))
            {
                output += newVal;
                idx += oldVal.Length;
            }
            else
            {
                output += text[idx];
                idx++;
            }
        }
        return output;
    }

    static bool IsSameWord(string text, string word, int start)
    {
        if (start + word.Length > text.Length)
            return false;

        for (int i = 0; i < word.Length; i++)
        {
            char a = ToLower(text[start + i]);
            char b = ToLower(word[i]);

            if (a != b)
                return false;
        }
        return true;
    }

    static char ToLower(char c)
    {
        if (c >= 'A' && c <= 'Z')
            return (char)(c + 32);
        return c;
    }
}
/*  using System;
class LibraryManagementSystem
{
    static void Main()
    {
        // storing book data
        string[] bookTitle =
        { 
           "Harry Potter" ,
           "A tale of Two Cities" ,
           "An Era Of Darkness" ,
           "Discovery Of India",
           "Think And Grow Rich",
        };

        // author names storage
         string [] bookAuthor = 
         {
            "J K Rowling" ,
            "Charles Dicknes",
            "Shashi Tharoor",
            "Jawaharlal Nehru",
            "Nepoleon Hill",

         };
         // to check availability of a book 
         bool[] bookAvailable={true, false, true, false, true};
          // displaying books
          Console.WriteLine("Library Books : ");
          for(int i=0; i< bookTitle.Length;i++)
          {

           Console.WriteLine ((i+1) + " . " + bookTitle[i] + " by " + bookAuthor[i] + " Status: " + (available[i] ? "Available" : "Checked Out"));
           

          }
    }
} */