using System;
using System.Diagnostics;

class SortingComparison
{
    static void Main()
    {
        int size = 5000;
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arr3 = new int[size];

        Random r = new Random();

        // filling arrays
        for (int i = 0; i < size; i++)
        {
            int value = r.Next(1, 10000);
            arr1[i] = value;
            arr2[i] = value;
            arr3[i] = value;
        }

        Stopwatch sw = new Stopwatch();

        // Bubble Sort
        sw.Start();
        BubbleSort(arr1);
        sw.Stop();
        Console.WriteLine("Bubble Sort Time: " + sw.ElapsedMilliseconds + " ms");

        // Merge Sort
        sw.Reset();
        sw.Start();
        MergeSort(arr2, 0, arr2.Length - 1);
        sw.Stop();
        Console.WriteLine("Merge Sort Time: " + sw.ElapsedMilliseconds + " ms");

        // Quick Sort
        sw.Reset();
        sw.Start();
        QuickSort(arr3, 0, arr3.Length - 1);
        sw.Stop();
        Console.WriteLine("Quick Sort Time: " + sw.ElapsedMilliseconds + " ms");
    }

    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Merge Sort
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
                arr[k++] = L[iIndex++];
            else
                arr[k++] = R[jIndex++];
        }

        while (iIndex < n1)
            arr[k++] = L[iIndex++];

        while (jIndex < n2)
            arr[k++] = R[jIndex++];
    }

    // Quick Sort
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int p = Partition(arr, low, high);
            QuickSort(arr, low, p - 1);
            QuickSort(arr, p + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int swap = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = swap;

        return i + 1;
    }
}