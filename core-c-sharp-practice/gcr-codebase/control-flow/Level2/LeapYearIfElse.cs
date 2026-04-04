using System;

class LeapYearIfElse
{
    static void Main(String[] args)
    {
        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        if (year < 1582)
        {
            Console.WriteLine("Year must be 1582 or later");
        }
        else if (year % 400 == 0)
        {
            Console.WriteLine("Leap Year");
        }
        else if (year % 100 == 0)
        {
            Console.WriteLine("Not a Leap Year");
        }
        else if (year % 4 == 0)
        {
            Console.WriteLine("Leap Year");
        }
        else
        {
            Console.WriteLine("Not a Leap Year");
        }
    }
}
