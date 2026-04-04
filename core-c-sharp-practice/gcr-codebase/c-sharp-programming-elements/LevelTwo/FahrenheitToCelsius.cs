using System;

class FahrenheitToCelsius {
	
    public static void Main(string[] args) {
    // take user input
	
        Console.Write("Enter the temperature in Fahrenheit: ");
        double fahrenheit = Convert.ToDouble(Console.ReadLine());
		
    // conversion
        double celsiusResult = (fahrenheit - 32) * 5 / 9;

        Console.WriteLine($"The {fahrenheit} Fahrenheit is {celsiusResult} Celsius");
    }
}
