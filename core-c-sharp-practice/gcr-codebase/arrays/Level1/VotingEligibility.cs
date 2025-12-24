using System;

class VotingEligibility
{
    static void Main()
    {
        int[] ages = new int[10];

        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write($"Enter age of student {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out ages[i]))
            {
                Console.Error.WriteLine("Invalid age input.");
                Environment.Exit(1);
            }
        }

        for (int i = 0; i < ages.Length; i++)
        {
            if (ages[i] < 0)
            {
                Console.WriteLine($"Student age {ages[i]} is invalid.");
            }
            else if (ages[i] >= 18)
            {
                Console.WriteLine($"Student with age {ages[i]} can vote.");
            }
            else
            {
                Console.WriteLine($"Student with age {ages[i]} cannot vote.");
            }
        }
    }
}
