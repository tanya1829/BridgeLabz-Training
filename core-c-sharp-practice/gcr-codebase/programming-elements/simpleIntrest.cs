using System;

class simpleInterest
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int p = int.Parse(inputs[0]);
        int r = int.Parse(inputs[1]);
        int t = int.Parse(inputs[2]);
        double SI = (p * r * t) / 100.0;
        Console.WriteLine(SI);
    }
}
