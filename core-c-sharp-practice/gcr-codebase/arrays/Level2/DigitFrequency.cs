using System;

class DigitFrequency
{
    static void Main(string[] args)
    {
       
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int temp = number;

        
        int count = 0;

        
        while (temp != 0)
        {
            count++;
            temp = temp / 10;
        }

        
        int[] digits = new int[count];

        
        temp = number;

        
        int index = 0;

        // Extract digits and store in array
        while (temp != 0)
        {
            digits[index] = temp % 10;   
            temp = temp / 10;            
            index++;
        }

        // Frequency array to store count of digits 0–9
        int[] frequency = new int[10];

        // Loop through digits array and count frequency
        for (int i = 0; i < digits.Length; i++)
        {
            frequency[digits[i]]++;
        }

        // Display frequency of each digit
        Console.WriteLine("\nDigit Frequency:");

        for (int i = 0; i < frequency.Length; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine("Digit " + i + " occurs " + frequency[i] + " times");
            }
        }
    }
}

