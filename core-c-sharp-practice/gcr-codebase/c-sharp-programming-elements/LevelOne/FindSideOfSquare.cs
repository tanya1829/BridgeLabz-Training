using System;
class FindSideOfSquare
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
		
        double p = double.Parse(input[0]);
        
		double s =p/4.0;
        
		Console.WriteLine(s);
    }
}