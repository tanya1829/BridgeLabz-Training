using System;

class ChocolateDistribution
{
    static void Main()
    {
        Console.Write("Enter number of chocolates: ");
        int chocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        int children = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(chocolates, children);

        Console.WriteLine("Each child gets: " + result[0]);
        Console.WriteLine("Remaining chocolates: " + result[1]);
    }

       public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        return new int[] { number / divisor, number % divisor };
    }
}
