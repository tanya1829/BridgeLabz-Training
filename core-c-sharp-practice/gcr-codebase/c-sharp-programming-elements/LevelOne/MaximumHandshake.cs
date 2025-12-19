using System;

class MaximumHandshake
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
		
        int n = int.Parse(inputs[0]);
        
		double maxHandshake=(double)(n * (n - 1)) / 2.0;
        
		Console.WriteLine(maxHandshake);
    }
}