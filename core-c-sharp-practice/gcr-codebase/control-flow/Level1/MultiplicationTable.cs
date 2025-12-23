using System;

class MultiplicationTable
{
    static void Main()
	
    {
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 6; i <= 9; i++)
		
            Console.WriteLine($"{n} * {i} = {n * i}");
    }
}
