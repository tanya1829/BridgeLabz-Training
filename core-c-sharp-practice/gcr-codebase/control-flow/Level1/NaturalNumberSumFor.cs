using System;

class NaturalNumberSumFor
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
        {
            int sum = 0;
            for (int i = 1; i <= number; i++)
                sum += i;

            Console.WriteLine($"Sum = {sum}, Formula = {n * (n + 1) / 2}");
        }
    }
}
