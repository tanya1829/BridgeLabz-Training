using System;

class FootballTeamHeights
{
    static void Main()
    {
        int[] heights = new int[11];
        Random rand = new Random();

        for (int i = 0; i < 11; i++)
            heights[i] = rand.Next(150, 251); // 150 to 250 cm

        Console.WriteLine("Player Heights: " + string.Join(", ", heights));
        Console.WriteLine("Sum of Heights: " + Sum(heights));
        Console.WriteLine("Mean Height: " + Mean(heights));
        Console.WriteLine("Shortest Player: " + Shortest(heights));
        Console.WriteLine("Tallest Player: " + Tallest(heights));
    }

    static int Sum(int[] arr)
    {
        int sum = 0;
        foreach (int x in arr) sum += x;
        return sum;
    }

    static double Mean(int[] arr)
    {
        return Sum(arr) / (double)arr.Length;
    }

    static int Shortest(int[] arr)
    {
        int min = arr[0];
        foreach (int x in arr) if (x < min) min = x;
        return min;
    }

    static int Tallest(int[] arr)
    {
        int max = arr[0];
        foreach (int x in arr) if (x > max) max = x;
        return max;
    }
}
