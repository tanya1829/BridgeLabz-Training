using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the first word");
            string first = Console.ReadLine();

            // Validation for multiple words
            if (first.Trim().Split(' ').Length > 1)
            {
                Console.WriteLine($"{first} is an invalid word");
                return;
            }

            Console.WriteLine("Enter the second word");
            string second = Console.ReadLine();

            if (second.Trim().Split(' ').Length > 1)
            {
                Console.WriteLine($"{second} is an invalid word");
                return;
            }

            // Check reverse (case-insensitive)
            string reversedFirst = new string(first.Reverse().ToArray());

            if (reversedFirst.Equals(second, StringComparison.OrdinalIgnoreCase))
            {
                // Step 1: Reverse first word
                string result = reversedFirst.ToLower();

                // Step 3: Replace vowels with '@'
                result = ReplaceVowelsWithAt(result);

                Console.WriteLine(result);
            }
            else
            {
                // Combine and uppercase
                string combined = (first + second).ToUpper();

                int vowelCount = 0;
                int consonantCount = 0;

                HashSet<char> vowelsSet = new HashSet<char> { 'A', 'E', 'I', 'O', 'U' };

                foreach (char c in combined)
                {
                    if (char.IsLetter(c))
                    {
                        if (vowelsSet.Contains(c))
                            vowelCount++;
                        else
                            consonantCount++;
                    }
                }

                if (vowelCount > consonantCount)
                {
                    // First 2 unique vowels
                    List<char> uniqueVowels = new List<char>();

                    foreach (char c in combined)
                    {
                        if (vowelsSet.Contains(c) && !uniqueVowels.Contains(c))
                        {
                            uniqueVowels.Add(c);
                        }
                        if (uniqueVowels.Count == 2)
                            break;
                    }

                    Console.WriteLine(string.Join("", uniqueVowels));
                }
                else if (consonantCount > vowelCount)
                {
                    // First 2 unique consonants
                    List<char> uniqueConsonants = new List<char>();

                    foreach (char c in combined)
                    {
                        if (char.IsLetter(c) && !vowelsSet.Contains(c) && !uniqueConsonants.Contains(c))
                        {
                            uniqueConsonants.Add(c);
                        }
                        if (uniqueConsonants.Count == 2)
                            break;
                    }

                    Console.WriteLine(string.Join("", uniqueConsonants));
                }
                else
                {
                    Console.WriteLine("Vowels and consonants are equal");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Helper method to replace vowels with '@'
    static string ReplaceVowelsWithAt(string input)
    {
        char[] arr = input.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            if ("aeiou".Contains(arr[i]))
            {
                arr[i] = '@';
            }
        }
        return new string(arr);
    }
}
