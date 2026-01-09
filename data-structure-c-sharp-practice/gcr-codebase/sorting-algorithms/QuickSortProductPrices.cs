using System;

class QuickSortProductPrices
{
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            // Find correct position of pivot
            int pivotIndex = Partition(arr, low, high);

            // Sort left and right parts
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // choosing last element as pivot
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        // Place pivot in correct position
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

    static void Main()
    {
        int[] prices = { 999, 499, 799, 299 };
        QuickSort(prices, 0, prices.Length - 1);

        Console.WriteLine("Sorted Product Prices:");
        foreach (int p in prices)
            Console.Write(p + " ");
    }
}