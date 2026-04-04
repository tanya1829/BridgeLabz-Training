using System;

class FriendsStats
{
    static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter age of {names[i]}: ");
            ages[i] = int.Parse(Console.ReadLine());
            Console.Write($"Enter height of {names[i]}: ");
            heights[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Youngest: " + names[Youngest(ages)]);
        Console.WriteLine("Tallest: " + names[Tallest(heights)]);
    }

    static int Youngest(int[] ages)
    {
        int minIndex = 0;
        for (int i = 1; i < ages.Length; i++)
            if (ages[i] < ages[minIndex]) minIndex = i;
        return minIndex;
    }

    static int Tallest(double[] heights)
    {
        int maxIndex = 0;
        for (int i = 1; i < heights.Length; i++)
            if (heights[i] > heights[maxIndex]) maxIndex = i;
        return maxIndex;
    }
}
