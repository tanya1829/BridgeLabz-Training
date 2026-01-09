using System;
using System.Collections.Generic;

class LongestConsecutive
{
    static int FindLength(int[] arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        int longest = 0;

        foreach (int num in arr)
        {
            // Start only if it's the beginning of a sequence
            if (!set.Contains(num - 1))
            {
                int current = num;
                int count = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    count++;
                }
                longest = Math.Max(longest, count);
            }
        }
        return longest;
    }
}