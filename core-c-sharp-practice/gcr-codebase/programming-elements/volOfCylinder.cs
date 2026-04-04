using System;

class volOfCylinder
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
		
        double r = double.Parse(inputs[0]);
		
        double h = double.Parse(inputs[1]);
		
        double volume = 3.14 * r * r * h;
		
        Console.WriteLine(volume);
    }
}
