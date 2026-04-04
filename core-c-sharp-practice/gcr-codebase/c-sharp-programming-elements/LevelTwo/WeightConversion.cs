using System;

class WeightConversion {
    public static void Main(string[] args) {
		
        		// take user input
        Console.Write("Enter the weight in pounds: ");
        double pounds = Convert.ToDouble(Console.ReadLine());
      
        double kilograms = (pounds / 2.2);

        Console.WriteLine($"The weight of the person in pounds is {pounds} and in kg is {kilograms}");
    }
}
