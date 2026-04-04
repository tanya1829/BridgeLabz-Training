using System;
class avgOfThreeNumbers
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int a = int.Parse(inputs[0]);
        int b = int.Parse(inputs[1]);
        int c = int.Parse(inputs[2]);
        double avg = (a + b + c) / 3.0;
        Console.WriteLine(avg);
    }
}
