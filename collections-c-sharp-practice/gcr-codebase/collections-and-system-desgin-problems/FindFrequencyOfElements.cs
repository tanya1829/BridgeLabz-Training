using System;
using System.Collections.Generic;

class FrequencyUsingUserInput
{
    static void Main()
    {
        // Create list to store input words
        List<string> words = new List<string>();

       
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        // Take input values
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter word " + (i + 1) + ": ");
            string input = Console.ReadLine();
            words.Add(input);
        }

        // Create dictionary for frequency
        Dictionary<string, int> freq = new Dictionary<string, int>();

        // Count frequency
        for (int i = 0; i < words.Count; i++)
        {
            string word = words[i];

            if (freq.ContainsKey(word))
            {
                freq[word]++;
            }
            else
            {
                freq[word] = 1;
            }
        }
        Console.WriteLine("\nFrequency of elements:");
        foreach (var item in freq)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
