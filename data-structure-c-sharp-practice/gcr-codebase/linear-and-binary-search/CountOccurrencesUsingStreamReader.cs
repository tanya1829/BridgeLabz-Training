using System;
using System.IO;

class CountOccurrencesUsingStreamReader
{
    static void Main()
    {
        string word = "hello";
        int count = 0;

        using (StreamReader sr = new StreamReader("sample.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(word))
                {
                    count++;
                }
            }
        }

        Console.WriteLine("Word count: " + count);
    }
}
