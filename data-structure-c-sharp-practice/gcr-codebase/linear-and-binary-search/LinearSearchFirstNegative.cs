using System;

class LinearSearchFirstNegative
{
    static void Main()
    {
        int[] arr = { 5, 3, 7, -2, 9, -6 };

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                Console.WriteLine("First negative number: " + arr[i]);
                return;
            }
        }

        Console.WriteLine("No negative number found");
    }
}
