using System;

class UnitConverter
{
    static void Main()
    {
        Console.Write("Enter km: ");
        double km = double.Parse(Console.ReadLine());
        Console.WriteLine($"{km} km = {ConvertKmToMiles(km)} miles");

        Console.Write("Enter miles: ");
        double miles = double.Parse(Console.ReadLine());
        Console.WriteLine($"{miles} miles = {ConvertMilesToKm(miles)} km");

        Console.Write("Enter meters: ");
        double m = double.Parse(Console.ReadLine());
        Console.WriteLine($"{m} meters = {ConvertMetersToFeet(m)} feet");

        Console.Write("Enter feet: ");
        double ft = double.Parse(Console.ReadLine());
        Console.WriteLine($"{ft} feet = {ConvertFeetToMeters(ft)} meters");
    }

    public static double ConvertKmToMiles(double km) => km * 0.621371;
    public static double ConvertMilesToKm(double miles) => miles * 1.60934;
    public static double ConvertMetersToFeet(double m) => m * 3.28084;
    public static double ConvertFeetToMeters(double ft) => ft * 0.3048;
}
