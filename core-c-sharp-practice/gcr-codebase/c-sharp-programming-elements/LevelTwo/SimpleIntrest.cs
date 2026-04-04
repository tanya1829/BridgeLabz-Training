using System;

class SimpleInterest {
    public static void Main(string[] args) {
     
	 //take user input
	 
        Console.Write("Enter the principal: ");
		
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the rate: ");
		
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the time: ");
		
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = (principal * rate * time) / 100;

        Console.WriteLine($"The Simple Interest is {simpleInterest} for Principal {principal}, Rate of Interest {rate} and Time {time}");
    }
}
