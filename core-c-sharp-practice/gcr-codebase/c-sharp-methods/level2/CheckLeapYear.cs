using System;

class LeapYearChecker
{
    static void Main()
    {
        Console.Write("Enter a year (>= 1582): ");
        int year = int.Parse(Console.ReadLine());
        if (year < 1582)
        {
            Console.WriteLine("Year must be >= 1582");
            return;
        }

        Console.WriteLine(IsLeapYear(year) ? "Leap Year" : "Not a Leap Year");
    }

    static bool IsLeapYear(int y)
    {
        return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
    }
}
