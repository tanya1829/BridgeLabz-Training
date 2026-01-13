using System;
using System.IO;

class CountOccurrencesUsingStreamReader
{
    static void Main()
    {
        string filePath = "sample.txt"; // file must exist
        Console.WriteLine("Enter the word to count:");
        string wordToCount = Console.ReadLine();

        int count = 0;

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (word.Equals(wordToCount, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine($"The word '{wordToCount}' appears {count} times in the file.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
