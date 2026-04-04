using System;
class HeightConversion{
	static void Main(){
		Console.Write("Enter your height in cm: ");
        double cm = Convert.ToDouble(Console.ReadLine());

        double inches = cm / 2.54;
        double ft = inches / 12;

        Console.WriteLine("your Height in cm is " + cm + " while in feets is " + ft + " and in inches is " + inches );
	}
}