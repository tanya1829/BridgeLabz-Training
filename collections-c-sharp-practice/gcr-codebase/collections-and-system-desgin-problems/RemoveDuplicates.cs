using System;
using System.Collections.Generic;

class RemoveDuplicates
{
    static void Main()
    {
        List<int> list = new List<int>();

        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            list.Add(int.Parse(Console.ReadLine()));
        }

        List<int> result = new List<int>();
        HashSet<int> seen = new HashSet<int>();

        for (int i = 0; i < list.Count; i++)
        {
            if (!seen.Contains(list[i]))
            {
                seen.Add(list[i]);
                result.Add(list[i]);
            }
        }

        Console.WriteLine("\nList after removing duplicates:");
        foreach (int x in result)
        {
            Console.Write(x + " ");
        }
    }
}
