using System;

class RandomNumbersStats
{
    static void Main()
    {
        int[] arr = Generate4DigitRandomArray(5);
        Console.WriteLine("Numbers: " + string.Join(", ", arr));

        double[] stats = FindAverageMinMax(arr);
        Console.WriteLine($"Average: {stats[0]:F2}, Min: {stats[1]}, Max: {stats[2]}");
    }

    static int[] Generate4DigitRandomArray(int size)
    {
        int[] arr = new int[size];
        Random rand = new Random();
        for (int i = 0; i < size; i++)
            arr[i] = rand.Next(1000, 10000);
        return arr;
    }

    static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0], max = numbers[0], sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
            if (n < min) min = n;
            if (n > max) max = n;
        }
        double avg = sum / (double)numbers.Length;
        return new double[] { avg, min, max };
    }
}
