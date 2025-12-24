using System;

class BMIProgram
{
    static void Main()
    {
        // Takeing input for number of persons
        Console.Write("Enter number of persons: ");
        int number = int.Parse(Console.ReadLine());

        
        double[] weights = new double[number];
        double[] heights = new double[number];
        double[] bmi = new double[number];
        string[] status = new string[number];

        
        for (int i = 0; i < number; i++)
        {
            Console.Write($"Enter weight of person {i + 1}: ");
            weights[i] = double.Parse(Console.ReadLine());

            Console.Write($"Enter height of person {i + 1} (in meters): ");
            heights[i] = double.Parse(Console.ReadLine());

            // Calculate BMI
            bmi[i] = weights[i] / (heights[i] * heights[i]);

            
            if (bmi[i] < 18.5)
                status[i] = "Underweight";
            else if (bmi[i] < 25)
                status[i] = "Normal";
            else if (bmi[i] < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        
        Console.WriteLine("\nBMI Report:");
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"Person {i + 1}: Weight={weights[i]}, Height={heights[i]}, BMI={bmi[i]}, Status={status[i]}");
        }
    }
}
