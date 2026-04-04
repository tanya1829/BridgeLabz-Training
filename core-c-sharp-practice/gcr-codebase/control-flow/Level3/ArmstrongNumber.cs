using System;

class ArmstrongNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        int originalNumber = number;
        int sum = 0;

        // loop until number becomes 0
        while (number != 0)
        {
            int remainder = number % 10;      // get last digit
            sum = sum + (remainder * remainder * remainder); // cube
            number = number / 10;              // remove last digit
        }

        if (sum == originalNumber)
            Console.WriteLine("Armstrong Number");
        else
            Console.WriteLine("Not an Armstrong Number");
    }
}
