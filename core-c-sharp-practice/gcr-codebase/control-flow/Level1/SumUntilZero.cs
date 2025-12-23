using System;

class SumUntilZero
{
    static void Main()
    {
        double t = 0;
		
        double value;

        while ((value = Convert.ToDouble(Console.ReadLine())) != 0)
            t += value;

        Console.WriteLine($"Total = {t}");
    }
}
