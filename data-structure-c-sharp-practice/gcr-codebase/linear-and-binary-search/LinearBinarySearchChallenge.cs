using System;
using System.Linq;

class LinearBinarySearchChallenge
{
    static void Main()
    {
        int[] arr = { 3, 4, -1, 1 };

        // Linear Search – first missing positive
        int missing = 1;
        while (Array.Exists(arr, x => x == missing))
        {
            missing++;
        }
        Console.WriteLine("First missing positive: " + missing);

        // Binary Search
        Array.Sort(arr);
        int target = 4;
        int index = Array.BinarySearch(arr, target);

        Console.WriteLine(index >= 0 ? "Target found at index: " + index : "Target not found");
    }
}
