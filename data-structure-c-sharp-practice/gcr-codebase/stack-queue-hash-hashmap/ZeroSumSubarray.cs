using System;
using System.Collections.Generic;

class ZeroSumSubarray
{
    static bool Exists(int[] arr)
    {
        HashSet<int> seenSums = new HashSet<int>();
        int sum = 0;

        foreach (int num in arr)
        {
            sum += num;

            // Zero sum found
            if (sum == 0 || seenSums.Contains(sum))
                return true;

            seenSums.Add(sum);
        }
        return false;
    }

    static void Main()
    {
        Console.WriteLine(Exists(new int[] { 4, -2, -2, 1 }));
    }
}