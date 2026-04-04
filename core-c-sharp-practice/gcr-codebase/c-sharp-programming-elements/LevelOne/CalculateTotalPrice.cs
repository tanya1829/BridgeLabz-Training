using System;

class CalculateTotalPrice
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int unitP = int.Parse(inputs[0]);
        int q = int.Parse(inputs[1]);
        int totalP = unitP*q;
        Console.WriteLine(totalP);
    }
}