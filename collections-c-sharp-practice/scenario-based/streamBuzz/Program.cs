using System;
using System.Collections.Generic;

public class Program
{
    // Register creator
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    // Get top post counts
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var creator in records)
        {
            int count = 0;

            foreach (var like in creator.WeeklyLikes)
            {
                if (like >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result[creator.CreatorName] = count;
            }
        }

        return result;
    }

    // Calculate average likes
    public double CalculateAverageLikes()
    {
        double total = 0;
        int count = 0;

        foreach (var creator in CreatorStats.EngagementBoard)
        {
            foreach (var like in creator.WeeklyLikes)
            {
                total += like;
                count++;
            }
        }

        if (count == 0)
            return 0;

        return total / count;
    }

    // Main Method
    public static void Main(string[] args)
    {
        Program program = new Program();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice:");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine();

                    double[] likes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = double.Parse(Console.ReadLine());
                    }

                    CreatorStats creator = new CreatorStats
                    {
                        CreatorName = name,
                        WeeklyLikes = likes
                    };

                    program.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    var result = program.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;

                case 3:
                    double avg = program.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {avg}");
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;   // ❗ no Environment.Exit()
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
