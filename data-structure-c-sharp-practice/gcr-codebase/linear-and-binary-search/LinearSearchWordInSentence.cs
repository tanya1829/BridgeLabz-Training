using System;

class LinearSearchWordInSentence
{
    static void Main()
    {
        string[] sentences =
        {
            "I love C sharp",
            "Java is powerful",
            "C sharp is easy",
            "Python is popular"
        };

        string word = "sharp";

        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Contains(word))
            {
                Console.WriteLine("Found sentence: " + sentences[i]);
                return;
            }
        }

        Console.WriteLine("Word not found");
    }
}
