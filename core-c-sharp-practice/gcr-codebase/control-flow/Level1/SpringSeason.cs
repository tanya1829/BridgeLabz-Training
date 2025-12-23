using System;

class SpringSeason
{
    static void Main()
    {
        Console.Write("Enter the month: ");
		
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the day: ");
        int d = Convert.ToInt32(Console.ReadLine());

        bool isSpring =
            (m == 3 && d >= 20) ||
            (m == 4 || m == 5) ||
            (m == 6 && d <= 20);

        if (isSpring)
            Console.WriteLine("Its a Spring Season");
        else
            Console.WriteLine("Not a Spring Season");
    }
}

