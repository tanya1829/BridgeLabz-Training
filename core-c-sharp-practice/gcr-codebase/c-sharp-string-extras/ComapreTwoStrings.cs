using System;

class CompareTwoStrings
{
    static void Main()
    {
        Console.WriteLine("Enter first string:");
        string s1 = Console.ReadLine() ?? "";

        Console.WriteLine("Enter second string:");
        string s2 = Console.ReadLine() ?? "";

        int i = 0;

        while (i < s1.Length && i < s2.Length)
        {
            if (s1[i] < s2[i])
            {
                Console.WriteLine(s1 + " comes before " + s2);
                return;
            }
            else if (s1[i] > s2[i])
            {
                Console.WriteLine(s2 + " comes before " + s1);
                return;
            }
            i++;
        }

        if (s1.Length == s2.Length)
            Console.WriteLine("Both strings are equal");
        else if (s1.Length < s2.Length)
            Console.WriteLine(s1 + " comes before " + s2);
        else
            Console.WriteLine(s2 + " comes before " + s1);
    }
}
