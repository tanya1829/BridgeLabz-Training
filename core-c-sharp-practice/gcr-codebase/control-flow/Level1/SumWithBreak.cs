using System;

class SumWithBreak
{
    static void Main()
    {
        double total = 0;

        while (true)
			
        {
            double value = Convert.ToDouble(Console.ReadLine());
			
            if (value <= 0)
                break;
            total += value;
        }

        Console.WriteLine($"Total = {total}");
    }
}
