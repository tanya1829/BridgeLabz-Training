using System;
using System.Text; // Required for StringBuilder

class ConcatenateUsingStringBuilder
{
    static void Main()
    {
        // Example array of strings
        string[] words = { "Hello", "World", "from", "CSharp" };

        // Create a StringBuilder object
        StringBuilder sb = new StringBuilder();

        // Loop through each string in the array
        foreach (string word in words)
        {
            sb.Append(word);       // Add the word
            sb.Append(" ");        // Add a space after each word
        }

        // Convert StringBuilder to string and remove the trailing space
        string result = sb.ToString().Trim();

        // Print the concatenated result
        Console.WriteLine("Concatenated string: " + result);
    }
}
