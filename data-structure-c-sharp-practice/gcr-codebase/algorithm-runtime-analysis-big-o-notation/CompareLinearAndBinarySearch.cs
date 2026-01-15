using System;
using System.Diagnostics;
class Compare{
    public static int LinearSearch(int[] arr, int target) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == target) return i;
        }
        return -1;
    }
    public static int BinarySearch(int[] arr, int target) {
        int i = 0, j = arr.Length - 1;
        while (i <= j) {
            int mid = i + (j - i) / 2;

            if (arr[mid] == target) return mid;
            if (arr[mid] < target) i = mid + 1;
            else j = mid - 1;
        }
        return -1;
    }
    static void Main() {
        int n = 10_000_000;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
            arr[i] = i;
        int target = n - 1;
        LinearSearch(arr, target);
        BinarySearch(arr, target);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 100; i++)
            LinearSearch(arr, target);
        sw.Stop();

        Console.WriteLine("Linear Search: " + sw.ElapsedMilliseconds + " ms");
        sw.Restart();
        for (int i = 0; i < 100; i++)
            BinarySearch(arr, target);
        sw.Stop();

        Console.WriteLine("Binary Search: " + sw.ElapsedMilliseconds + " ms");
    }

}