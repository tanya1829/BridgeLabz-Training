using System;

class DateArithmetic
{
    static void Main()
    {
        Console.WriteLine("Enter date (yyyy-MM-dd):");
        DateTime date = DateTime.Parse(Console.ReadLine());

        DateTime result = date
            .AddDays(7)
            .AddMonths(1)
            .AddYears(2)
            .AddDays(-21);   // 3 weeks = 21 days

        Console.WriteLine("Final Date: " + result.ToShortDateString());
    }
}
