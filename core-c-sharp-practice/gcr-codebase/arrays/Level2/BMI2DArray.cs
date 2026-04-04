using System;

class BMI2DArray
{
    static void Main()
    {
        // Take input for number of persons
        Console.Write("Enter number of persons: ");
        int number = int.Parse(Console.ReadLine());

        
        double[][] personData = new double[number][];
        string[] weightStatus = new string[number];

        
        for (int i = 0; i < number; i++)
            personData[i] = new double[3];

        
        for (int i = 0; i < number; i++)
        {
            Console.Write($"Enter weight of person {i + 1}: ");
            personData[i][0] = double.Parse(Console.ReadLine());

            Console.Write($"Enter height of person {i + 1}: ");
            personData[i][1] = double.Parse(Console.ReadLine());

            personData[i][2] = personData[i][0] / (personData[i][1] * personData[i][1]);

            
            if (personData[i][2] < 18.5)
                weightStatus[i] = "Underweight";
            else if (personData[i][2] < 25)
                weightStatus[i] = "Normal";
            else if (personData[i][2] < 30)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }

        // Display results
        Console.WriteLine("\nBMI Details:");
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"Person {i + 1}: Weight={personData[i][0]}, Height={personData[i][1]}, BMI={personData[i][2]}, Status={weightStatus[i]}");
        }
    }
}
