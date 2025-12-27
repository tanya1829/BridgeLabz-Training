using System;

class TemperatureConverter
{
    static void Main()
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter temperature:");
        double temp = double.Parse(Console.ReadLine());

        if (choice == 1)
            Console.WriteLine("Result: " + CtoF(temp));
        else
            Console.WriteLine("Result: " + FtoC(temp));
    }

    static double CtoF(double c)
    {
        return (c * 9 / 5) + 32;
    }

    static double FtoC(double f)
    {
        return (f - 32) * 5 / 9;
    }
}
