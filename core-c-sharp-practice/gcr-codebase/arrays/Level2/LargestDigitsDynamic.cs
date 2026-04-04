using System;

class LargestDigitsDynamic
{
    static void Main()
    {
        // Taking input number
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        
        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;

        
        while (number != 0)
        {
            
            if (index == maxDigit)
            {
                maxDigit += 10;
                int[] temp = new int[maxDigit];
                Array.Copy(digits, temp, digits.Length);
                digits = temp;
            }

            digits[index++] = number % 10;
            number /= 10;
        }

        // Variables for largest and second largest
        int largest = 0;
        int secondLargest = 0;

        // Find largest and second largest
        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }

       
        Console.WriteLine($"Largest Digit: {largest}");
        Console.WriteLine($"Second Largest Digit: {secondLargest}");
    }
}
