using System;
using System.Collections.Generic;

class PairSum
{
    static bool FindPair(int[] arr, int target)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int x in arr)
        {
            // Check if complement exists
            if (set.Contains(target - x))
                return true;

            set.Add(x);
        }
        return false;
    }
}