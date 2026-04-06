using System;

class BinarySearchFirstLastOccurrence
{
    static void Main()
    {
        int[] arr = { 1, 2, 2, 2, 3, 4 };
        int target = 2;

        int first = -1, last = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                if (first == -1) first = i;
                last = i;
            }
        }

        Console.WriteLine("First index: " + first);
        Console.WriteLine("Last index: " + last);
    }
}
