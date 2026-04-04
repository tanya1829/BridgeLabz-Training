using System;

class UnitConverterTempWeight
{
    static void Main()
    {
        Console.Write("Enter Fahrenheit: ");
        double f = double.Parse(Console.ReadLine());
        Console.WriteLine($"{f} F = {ConvertFahrenheitToCelsius(f)} C");

        Console.Write("Enter Celsius: ");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine($"{c} C = {ConvertCelsiusToFahrenheit(c)} F");

        Console.Write("Enter pounds: ");
        double p = double.Parse(Console.ReadLine());
        Console.WriteLine($"{p} lbs = {ConvertPoundsToKg(p)} kg");

        Console.Write("Enter kg: ");
        double kg = double.Parse(Console.ReadLine());
        Console.WriteLine($"{kg} kg = {ConvertKgToPounds(kg)} lbs");

        Console.Write("Enter gallons: ");
        double gal = double.Parse(Console.ReadLine());
        Console.WriteLine($"{gal} gallons = {ConvertGallonsToLiters(gal)} liters");

        Console.Write("Enter liters: ");
        double l = double.Parse(Console.ReadLine());
        Console.WriteLine($"{l} liters = {ConvertLitersToGallons(l)} gallons");
    }

    public static double ConvertFahrenheitToCelsius(double f) => (f - 32) * 5 / 9;
    public static double ConvertCelsiusToFahrenheit(double c) => (c * 9 / 5) + 32;
    public static double ConvertPoundsToKg(double p) => p * 0.453592;
    public static double ConvertKgToPounds(double kg) => kg * 2.20462;
    public static double ConvertGallonsToLiters(double gal) => gal * 3.78541;
    public static double ConvertLitersToGallons(double l) => l * 0.264172;
}
