using System;

class GradeCalculation
{
    static void Main(String[] args)
    {
        Console.Write("Physics: ");
        int p = Convert.ToInt32(Console.ReadLine());
        Console.Write("Chemistry: ");
        int c = Convert.ToInt32(Console.ReadLine());
        Console.Write("Maths: ");
        int m = Convert.ToInt32(Console.ReadLine());

        double avg = (p + c + m) / 3.0;
        Console.WriteLine("Average Marks: " + avg);

        if (avg >= 90) Console.WriteLine("Grade: A | Excellent");
        else if (avg >= 75) Console.WriteLine("Grade: B | Very Good");
        else if (avg >= 60) Console.WriteLine("Grade: C | Good");
        else if (avg >= 40) Console.WriteLine("Grade: D | Pass");
        else Console.WriteLine("Grade: F | Fail");
    }
}
