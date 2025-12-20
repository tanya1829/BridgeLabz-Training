using System;

class TotalIncome {
	
    public static void Main(string[] args) {

        Console.Write("Enter your salary: ");
		
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter your bonus: ");
		
        double bonus = Convert.ToDouble(Console.ReadLine());

        double totalIncome = salary + bonus;

        Console.WriteLine($"The salary is INR {salary} and bonus is INR {bonus}. Hence Total Income is INR {totalIncome}");
    }
}
