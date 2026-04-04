using System;

class QuotientAndRemainder {
    public static void Main(string[] args) {

        Console.Write("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int quotient = num1 / num2;
        int remainder = num1 % num2;

        Console.WriteLine("The Quotient is " + quotient + " and Remainder is " + remainder + " of two numbers  " + num1 + "  and " + num2 );
    }
}
