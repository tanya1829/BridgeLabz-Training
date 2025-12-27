using System;

class TimeZoneAndDateTimeOffset
{
    static void Main()
    {
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        TimeZoneInfo gmt = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        Console.WriteLine("GMT Time: " + TimeZoneInfo.ConvertTime(utcTime, gmt));
        Console.WriteLine("IST Time: " + TimeZoneInfo.ConvertTime(utcTime, ist));
        Console.WriteLine("PST Time: " + TimeZoneInfo.ConvertTime(utcTime, pst));
    }
}
