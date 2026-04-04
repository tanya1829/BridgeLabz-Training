using System;

class AthleteRounds {
    public static void Main(string[] args) {
		
    // take user input
	
        Console.Write("Enter the side1: ");
		
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the side2: ");
		
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the side3: ");
		
        double side3 = Convert.ToDouble(Console.ReadLine());

        double perimeter = (side1 + side2 + side3);
		
        double totalDistance = 5000; // meters

        double rounds = totalDistance / perimeter;

        Console.WriteLine($"The total number of rounds the athlete will run is {rounds}");
    }
}
