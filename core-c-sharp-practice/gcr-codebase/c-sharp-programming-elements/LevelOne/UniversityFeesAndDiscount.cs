using System;
class UniversityFeesAndDiscount{
	static void Main(){
		Console.Write("Enter Fees: ");
        double fees = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Discount Percent: ");
        double discountPercent = Convert.ToDouble(Console.ReadLine());

        double discount = fees * discountPercent / 100;
        double finalFee = fees - discount;

        Console.WriteLine("The discount amount is INR " + discount + " and the final discounted fees is INR " + finalFee  );
	}
}