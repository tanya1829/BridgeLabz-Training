using System;
using System.Collections.Generic;

class SlidingWindowMax
{
    static void FindMax(int[] arr, int k)
    {
        // Deque stores indices of useful elements
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            // Remove elements outside the current window
            if (deque.Count > 0 && deque.First.Value <= i - k)
                deque.RemoveFirst();

            // Remove smaller elements from back
            while (deque.Count > 0 && arr[deque.Last.Value] < arr[i])
                deque.RemoveLast();

            // Add current element index
            deque.AddLast(i);

            // Window starts when i >= k - 1
            if (i >= k - 1)
                Console.Write(arr[deque.First.Value] + " ");
        }
    }

    static void Main()
    {
        FindMax(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
    }
}