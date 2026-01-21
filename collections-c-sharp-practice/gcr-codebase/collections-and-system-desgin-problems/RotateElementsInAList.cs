using System;
using System.Collections.Generic;

class RotateList
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

        Console.Write("Enter rotate count: ");
        int k = int.Parse(Console.ReadLine());

        // Handle rotate count greater than size
        k = k % list.Count;

        List<int> rotated = new List<int>();

        // Add elements from k to end
        for (int i = k; i < list.Count; i++)
        {
            rotated.Add(list[i]);
        }

        // Add elements from 0 to k-1
        for (int i = 0; i < k; i++)
        {
            rotated.Add(list[i]);
        }

        Console.WriteLine("\nRotated List:");
        foreach (int x in rotated)
        {
            Console.Write(x + " ");
        }
    }
}
