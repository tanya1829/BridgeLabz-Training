using System;

class CalendarProgram
{
    static string[] monthNames = 
    { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    static int[] daysInMonth = 
    { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int month = int.Parse(input[0]);
        int year  = int.Parse(input[1]);

        Console.WriteLine("\n" + GetMonthName(month) + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int days = GetDaysInMonth(month, year);
        int firstDay = GetFirstDay(month, year);

        // indentation loop
        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("    "); // 4 spaces for each day gap
        }

        // printing days loop
        for (int day = 1; day <= days; day++)
        {
            Console.Write($"{day,3} "); // %3d equivalent in C#

            if ((day + firstDay) % 7 == 0)
                Console.WriteLine();
        }
    }

    static string GetMonthName(int m)
    {
        return monthNames[m];
    }

    static int GetDaysInMonth(int m, int y)
    {
        if (m == 2 && IsLeapYear(y))
            return 29;
        return daysInMonth[m];
    }

    static bool IsLeapYear(int y)
    {
        return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
    }

    static int GetFirstDay(int m, int y)
    {
        int d = 1;
        int y0 = y - (14 - m) / 12;
        int x  = y0 + y0/4 - y0/100 + y0/400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;
        return d0;
    }

    static string GetMonthName(int m) => monthNames[m];
}
