using System;

class perimeterOfRec
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
		
        double length = double.Parse(inputs[0]);
		
        double breadth = double.Parse(inputs[1]);
		
        double perimeter = 2 * (length + breadth);
		
        Console.WriteLine(perimeter);
    }
}
