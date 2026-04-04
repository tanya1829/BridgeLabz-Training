using System;

class OddEvenNumbers
{
    static void Main()
    {
        int no = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= no; i++)
            Console.WriteLine($"{i} is {(i % 2 == 0 ? "Even" : "Odd")}");
    }
}
