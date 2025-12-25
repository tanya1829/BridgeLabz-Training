using System;

class StudentScoreCard
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] scores = GenerateRandomScores(n);
        double[,] stats = CalculateStats(scores, n);
        DisplayScorecard(scores, stats, n);
    }

    // b. Generate random 2-digit PCM scores → 2D array
    static int[,] GenerateRandomScores(int n)
    {
        Random r = new Random();
        int[,] arr = new int[n, 3];
        for (int i = 0; i < n; i++)
        {
            arr[i, 0] = r.Next(10, 100);
            arr[i, 1] = r.Next(10, 100);
            arr[i, 2] = r.Next(10, 100);
        }
        return arr;
    }

    // c. Calculate total, average, percentage → 2D array (rounded to 2 decimals)
    static double[,] CalculateStats(int[,] scores, int n)
    {
        double[,] arr = new double[n, 3];
        for (int i = 0; i < n; i++)
        {
            int total = scores[i,0] + scores[i,1] + scores[i,2];
            double avg = total / 3.0;
            double percent = (total / 300.0) * 100;

            arr[i,0] = Math.Round(total, 2);
            arr[i,1] = Math.Round(avg, 2);
            arr[i,2] = Math.Round(percent, 2);
        }
        return arr;
    }

    // d. Display scorecard in table using "\t"
    static void DisplayScorecard(int[,] scores, double[,] stats, int n)
    {
        Console.WriteLine("P\tC\tM\tTotal\tAverage\tPercentage");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(
                scores[i,0] + "\t" +
                scores[i,1] + "\t" +
                scores[i,2] + "\t" +
                stats[i,0] + "\t" +
                stats[i,1] + "\t" +
                stats[i,2]
            );
        }
    }
}
