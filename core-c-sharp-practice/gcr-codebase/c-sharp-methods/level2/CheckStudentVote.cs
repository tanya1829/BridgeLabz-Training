using System;

class StudentVoteChecker
{
    static void Main()
    {
        int[] ages = new int[10];
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter age of student {i + 1}: ");
            ages[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Student {i + 1} can vote: {CanStudentVote(ages[i])}");
        }
    }

    public static bool CanStudentVote(int age)
    {
        if (age < 0) return false;
        return age >= 18;
    }
}
