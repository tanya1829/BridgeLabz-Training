using System;

class PalindromeChecker
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine();

        if (IsPalindrome(str))
            Console.WriteLine("Palindrome");
        else
            Console.WriteLine("Not Palindrome");
    }

    static bool IsPalindrome(string s)
    {
        int i = 0, j = s.Length - 1;

        while (i < j)
        {
            if (s[i] != s[j])
                return false;
            i++;
            j--;
        }
        return true;
    }
}
