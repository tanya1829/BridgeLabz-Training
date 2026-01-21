using System;
using System.Collections.Generic;

class WordFrequency
{
    static void Main()
    {
        string text = "Hello world hello Java";
        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string word in text.ToLower().Split())
        {
            if (map.ContainsKey(word))
                map[word]++;
            else
                map[word] = 1;
        }

        foreach (var item in map)
            Console.WriteLine(item.Key + " : " + item.Value);
    }
}
