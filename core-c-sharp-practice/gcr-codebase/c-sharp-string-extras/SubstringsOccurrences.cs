using System;

class SubstringOccurrences
{
    static void Main()
    {
        Console.WriteLine("Enter the main string:");
        string strMain = Console.ReadLine() ?? "";

        Console.WriteLine("Enter substring:");
        string strSub = Console.ReadLine() ?? "";

        int count = 0;

        for (int i = 0; i <= strMain.Length - strSub.Length; i++)
        {
            bool match = true;

            for (int j = 0; j < strSub.Length; j++)
            {
                if (strMain[i + j] != strSub[j])
                {
                    match = false;
                    break;
                }
            }

            if (match)
                count++;
        }

        Console.WriteLine("Occurrences: " + count);
    }
}
