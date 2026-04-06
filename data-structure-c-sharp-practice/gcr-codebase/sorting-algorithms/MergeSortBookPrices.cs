using System;

class MergeSortBookPrices
{
    static void MergeSort(int[] arr, int left, int right)
    {
        // Base condition
        if (left < right)
        {
            int mid = (left + right) / 2;

            // Divide array into halves
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            // Merge sorted halves
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        // Copy data into temp arrays
        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        // Merge the temp arrays back
        while (i < n1 && j < n2)
        {
            arr[k++] = (L[i] <= R[j]) ? L[i++] : R[j++];
        }

        // Copy remaining elements
        while (i < n1) arr[k++] = L[i++];
        while (j < n2) arr[k++] = R[j++];
    }

    static void Main()
    {
        int[] prices = { 450, 120, 300, 200 };
        MergeSort(prices, 0, prices.Length - 1);

        Console.WriteLine("Sorted Book Prices:");
        foreach (int p in prices)
            Console.Write(p + " ");
    }
}