using System;

class WindChill
{
    public static double CalculateWindChill(double temp, double windSpeed)
    {
        double windChill = 35.74 + 0.6215 * temp + (0.4275 * temp - 35.75) * Math.Pow(windSpeed, 0.16);
        return windChill;
    }

    static void Main()
    {
        Console.Write("Enter the temp: ");
        double temp = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter wind speed: ");
        double windSpeed = Convert.ToDouble(Console.ReadLine());

// r-- result
        double r = CalculateWindChill(temp, windSpeed);

        Console.WriteLine("Wind Chill Temperature = " + r);
    }
}
