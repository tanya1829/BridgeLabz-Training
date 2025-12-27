using System;

class Anagram
{
    static void Main()
    {
        Console.WriteLine("Enter first string:");
        string s1 = Console.ReadLine() ?? "";

        Console.WriteLine("Enter second string:");
        string s2 = Console.ReadLine() ?? "";

        if (s1.Length != s2.Length)
        {
            Console.WriteLine("Not Anagram");
            return;
        }

        bool isAnagram = true;

        for (int i = 0; i < s1.Length; i++)
        {
            int count1 = 0, count2 = 0;

            for (int j = 0; j < s1.Length; j++)
            {
                if (s1[i] == s1[j]) count1++;
                if (s1[i] == s2[j]) count2++;
            }

            if (count1 != count2)
            {
                isAnagram = false;
                break;
            }
        }

        if (isAnagram)
            Console.WriteLine("Anagram");
        else
            Console.WriteLine("Not Anagram");
    }
}
