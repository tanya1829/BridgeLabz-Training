using System;

class FizzBuzzWhile
{
    static void Main(String[] args)
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int i = 1;
        while (i <= n)
        {
            if (i % 3 == 0 && i % 5 == 0)
                Console.WriteLine("FizzBuzz");
            else if (i % 3 == 0)
                Console.WriteLine("Fizz");
            else if (i % 5 == 0)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(i);

            i++;
        }
    }
}
