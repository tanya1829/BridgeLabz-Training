using System;

class Factors
{
    static void Main(String[] args)
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                Console.WriteLine(i);
        }
    }
}
