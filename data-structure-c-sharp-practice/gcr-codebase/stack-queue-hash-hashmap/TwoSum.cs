using System;
using System.Collections.Generic;

class TwoSum
{
    static int[] Solve(int[] arr, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            // Check if complement exists
            if (map.ContainsKey(target - arr[i]))
                return new int[] { map[target - arr[i]], i };

            // Store current value with index
            map[arr[i]] = i;
        }
        return null;
    }
}