using System;

class StudentPerformanceReport
{
    private double[,] marks;

    public StudentPerformanceReport(double[,] data)
    {
        marks = data;
    }

    static void Main()
    {
        Console.WriteLine("Enter total number of students:");
        int students = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter total number of subjects:");
        int subjects = int.Parse(Console.ReadLine());

        double[,] data = new double[students, subjects];
        ReadMarks(data);

        StudentPerformanceReport report = new StudentPerformanceReport(data);
        report.PrintMinAndMaxScores();
        report.PrintAverageAndAboveAverage();
    }

    static void ReadMarks(double[,] data)
    {
        for (int s = 0; s < data.GetLength(0); s++)
        {
            Console.WriteLine($"Enter marks for Student {s + 1}:");

            for (int sub = 0; sub < data.GetLength(1); sub++)
            {
                while (true)
                {
                    try
                    {
                        double value = Convert.ToDouble(Console.ReadLine());
                        if (value < 0)
                            throw new ArgumentException();

                        data[s, sub] = value;
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Please enter a non-negative score.");
                    }
                }
            }
        }
    }

    public void PrintAverageAndAboveAverage()
    {
        for (int s = 0; s < marks.GetLength(0); s++)
        {
            double total = 0;

            for (int sub = 0; sub < marks.GetLength(1); sub++)
                total += marks[s, sub];

            double average = total / marks.GetLength(1);
            Console.WriteLine($"Student {s + 1} average score: {average}");

            bool found = false;
            Console.Write("Scores higher than average: ");

            for (int sub = 0; sub < marks.GetLength(1); sub++)
            {
                if (marks[s, sub] > average)
                {
                    Console.Write(marks[s, sub] + " ");
                    found = true;
                }
            }

            if (!found)
                Console.Write("None");

            Console.WriteLine("\n");
        }
    }

    public void PrintMinAndMaxScores()
    {
        for (int s = 0; s < marks.GetLength(0); s++)
        {
            double min = marks[s, 0];
            double max = marks[s, 0];

            for (int sub = 1; sub < marks.GetLength(1); sub++)
            {
                if (marks[s, sub] > max)
                    max = marks[s, sub];

                if (marks[s, sub] < min)
                    min = marks[s, sub];
            }

            Console.WriteLine($"Student {s + 1} → Highest: {max}, Lowest: {min}");
        }
    }
}