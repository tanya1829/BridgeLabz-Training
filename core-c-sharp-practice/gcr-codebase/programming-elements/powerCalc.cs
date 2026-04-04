using System;
class powerCalc
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        double e = double.Parse(inputs[0]);
        double b = double.Parse(inputs[1]);
		double result = Math.Pow(b, e);
		Console.WriteLine(result);
    }
}
