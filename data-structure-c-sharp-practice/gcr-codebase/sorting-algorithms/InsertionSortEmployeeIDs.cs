using System;

class InsertionSortEmployeeIDs
{
    static void InsertionSort(int[] ids)
    {
        // Start from second element
        for (int i = 1; i < ids.Length; i++)
        {
            int key = ids[i];
            int j = i - 1;

            // Shift elements greater than key to one position ahead
            while (j >= 0 && ids[j] > key)
            {
                ids[j + 1] = ids[j];
                j--;
            }

            // Insert key at correct position
            ids[j + 1] = key;
        }
    }

    static void Main()
    {
        int[] ids = { 105, 101, 110, 102 };
        InsertionSort(ids);

        Console.WriteLine("Sorted Employee IDs:");
        foreach (int id in ids)
            Console.Write(id + " ");
    }
}