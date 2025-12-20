using System;

class ChocolateDistribution {
	
    public static void Main(string[] args) {

        Console.Write("Enter the number of chocolates: ");
		
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the number of children: ");
		
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        int chocolatesEach = (numberOfChocolates / numberOfChildren);
		
        int remainingChocolates = (numberOfChocolates % numberOfChildren);

        Console.WriteLine($"The number of chocolates each child gets is {chocolatesEach} and the number of remaining chocolates is {remainingChocolates}");
    }
}
