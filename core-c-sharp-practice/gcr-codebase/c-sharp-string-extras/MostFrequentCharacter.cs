using System;

class MostFrequentCharacter
{
    static void Main()
    {
        Console.WriteLine("Enter string:");
        string str = Console.ReadLine() ?? "";

        char mostChar = str[0];
        int maxCount = 0;

        for (int i = 0; i < str.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[i] == str[j])
                    count++;
            }

            if (count > maxCount)
            {
                maxCount = count;
                mostChar = str[i];
            }
        }

        Console.WriteLine("Most frequent character: " + mostChar);
    }
}
