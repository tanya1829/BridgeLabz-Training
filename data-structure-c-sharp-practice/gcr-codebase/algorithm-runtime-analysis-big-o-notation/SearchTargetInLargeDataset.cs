using System;
using System.Diagnostics;

class SearchTargetInLargeDataset
{
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target) return i;
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    static void Main()
    {
        int N = 1000000;
        int[] data = new int[N];
        for (int i = 0; i < N; i++) data[i] = i;
        int target = N - 1;

        Stopwatch sw = new Stopwatch();

        sw.Start();
        LinearSearch(data, target);
        sw.Stop();
        Console.WriteLine($"Linear Search: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        BinarySearch(data, target);
        sw.Stop();
        Console.WriteLine($"Binary Search: {sw.ElapsedMilliseconds} ms");
    }
}

