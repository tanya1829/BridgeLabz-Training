using System;

class TriangleArea
{
    static void Main(){
		
	// Taking input from user
        Console.Write("Enter the base in inches: ");
        double baseInInches = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the height in inches: ");
        double heightInInches = Convert.ToDouble(Console.ReadLine());

        // Area in square inches.
        double areaInSquareInches = 0.5 * baseInInches * heightInInches;

        // Converting area to square centimeters
        double areaInSquareCentimeters = areaInSquareInches * 2.54 * 2.54;
        
		
		Console.WriteLine("Area of Triangle is " + areaInSquareInches + " square inches ");
		Console.WriteLine("Area of Triangle is " + areaInSquareCentimeters + "square centimeters" );
}
}