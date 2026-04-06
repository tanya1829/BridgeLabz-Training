using System;
using System.Text;

class ConcatenateUsingStringBuilder
{
    static void Main()
    {
        string[] words = { "Hello", " ", "C#", " ", "World" };

        StringBuilder sb = new StringBuilder();

        foreach (string word in words)
        {
            sb.Append(word);
        }

        Console.WriteLine("Concatenated String: " + sb.ToString());
    }
}
