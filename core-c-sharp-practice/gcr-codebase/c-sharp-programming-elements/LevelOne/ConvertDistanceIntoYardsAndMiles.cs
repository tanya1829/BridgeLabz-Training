using System;

class ConvertDistanceIntoYardsAndMiles{
	
	static void Main(){
	
		String[] input=Console.ReadLine().Split();
		int distanceInFeet=int.Parse(input[0]);
		double y=(double)distanceInFeet/3.0; // 1 yard is 3 feet
		double miles=y/1760; // 1 mile = 1760 yards
		Console.WriteLine("yards="+y);
		Console.WriteLine("miles="+miles);
	}
}