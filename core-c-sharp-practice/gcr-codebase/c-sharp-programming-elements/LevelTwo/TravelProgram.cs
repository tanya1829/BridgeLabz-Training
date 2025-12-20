using System;

class TravelProgram {
	
    public static void Main(string[] args) {
		
           // take user input
        Console.Write("Enter the name: ");
		
        string name = Console.ReadLine();

        Console.Write("Enter  from city: ");
		
        string fromCity = Console.ReadLine();

        Console.Write("Enter via city: ");
		
        string viaCity = Console.ReadLine();

        Console.Write("Enter to city: ");
		
        string toCity = Console.ReadLine();

        Console.Write("Enter distance from to via (miles): ");
		
        double fromToVia = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter distance via to final city (miles): ");
		
        double viaToFinalCity = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter total time taken (minutes): ");
		
        int timeTaken = Convert.ToInt32(Console.ReadLine());

        double totalDistance = fromToVia + viaToFinalCity;

        Console.WriteLine($"The results of the trip are: {name}, {totalDistance} miles, {timeTaken} minutes");
    }
}
