using System;
class UniversityFees{
	static void Main(){
		double fee = 125000;
        double discountPercent = 10;

        double discount = fee * discountPercent / 100;
        double finalFee = fee - discount;
		Console.WriteLine(" discount amount is INR  "+ discount + "  and the final fees is INR  "+ finalFee );
		
	}
}