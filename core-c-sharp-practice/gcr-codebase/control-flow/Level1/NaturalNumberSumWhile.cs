using System;

class NaturalNumberSumWhile
{
    static void Main()
	
    {
		
        int n = Convert.ToInt32(Console.ReadLine());

        if (n > 0)
        {
			
            int sumLoop = 0, i = 1;
			
            while (i <= n)
                sumLoop += i++;

            int sumFormula = n * (n + 1) / 2;
            
			Console.WriteLine($"Loop Sum = {sumLoop}, Formula Sum = {sumFormula}");
        }
    }
}
