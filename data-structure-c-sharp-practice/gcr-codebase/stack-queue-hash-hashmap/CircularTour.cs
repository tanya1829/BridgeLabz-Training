using System;

class CircularTour
{
    static int FindStart(int[] petrol, int[] distance)
    {
        int start = 0;
        int balance = 0;
        int deficit = 0;

        for (int i = 0; i < petrol.Length; i++)
        {
            // Update fuel balance
            balance += petrol[i] - distance[i];

            // If balance negative, reset start
            if (balance < 0)
            {
                deficit += balance;
                start = i + 1;
                balance = 0;
            }
        }

        // Check if circular tour is possible
        return (balance + deficit >= 0) ? start : -1;
    }

    static void Main()
    {
        Console.WriteLine(FindStart(
            new int[] { 6, 3, 7 },
            new int[] { 4, 6, 3 }));
    }
}