using System;

class QuotientAndRemainder
{
    public static int[] FindRemainderAndQuotient(int num, int divisor)
    {
        int quotient = num / divisor;
        int remainder = num % divisor;

        return new int[] { quotient, remainder };
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(num, divisor);

        Console.WriteLine("Quotient = " + result[0]);
        Console.WriteLine("Remainder = " + result[1]);
    }
}
