using System;

class AbundantNumber
{
    static void Main()
    
    {
        Console.Write("Enter a number : ");

        int number = int.Parse(Console.ReadLine());

        int sum = 0;

        for (int i = 1; i < number; i++)

        {
            if (number % i == 0)

                sum = sum + i;
        }

        if (sum > number)

            Console.WriteLine("Abundant Number");

        else

            Console.WriteLine("Not an Abundant Number");
    }
}
