using System;

// Program to analyze weekly temperature data
class  TemperatureAnalyzer
{
    static void Main()
    {
        TemperatureAnalyzer report = new TemperatureAnalyzer();

        // 7 days × 24 readings per day
        double[,] weekReadings = new double[7, 24];

        Console.WriteLine("Enter hourly temperature values for 7 days:");

        for (int dayIndex = 0; dayIndex < 7; dayIndex++)
        {
            Console.WriteLine("Day " + (dayIndex + 1));

            for (int hourIndex = 0; hourIndex < 24; hourIndex++)
            {
                // ensures valid numeric input
                while (!double.TryParse(Console.ReadLine(), out weekReadings[dayIndex, hourIndex]))
                {
                    Console.WriteLine("Invalid input. Enter a number again:");
                }
            }
        }

        report.DetectExtremeDays(weekReadings);
        report.ComputeDailyAverages(weekReadings);
    }

    // identifies days with highest and lowest recorded temperature
    void DetectExtremeDays(double[,] data)
    {
        double highestTemp = data[0, 0];
        double lowestTemp = data[0, 0];

        int hottestDayIndex = 0;
        int coldestDayIndex = 0;

        for (int d = 0; d < data.GetLength(0); d++)
        {
            for (int h = 0; h < data.GetLength(1); h++)
            {
                double current = data[d, h];

                if (current > highestTemp)
                {
                    highestTemp = current;
                    hottestDayIndex = d;
                }

                if (current < lowestTemp)
                {
                    lowestTemp = current;
                    coldestDayIndex = d;
                }
            }
        }

        Console.WriteLine("Hottest day : Day " + (hottestDayIndex + 1));
        Console.WriteLine("Coldest day : Day " + (coldestDayIndex + 1));
    }

    // calculates and displays average temperature for each day
    void ComputeDailyAverages(double[,] data)
    {
        for (int d = 0; d < data.GetLength(0); d++)
        {
            double dayTotal = 0;

            for (int h = 0; h < data.GetLength(1); h++)
            {
                dayTotal += data[d, h];
            }

            double average = dayTotal / data.GetLength(1);
            Console.WriteLine($"Average temperature of Day {d + 1} : {average}");
        }
    }
}