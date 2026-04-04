using System;

class BMICalculator
{
    static void Main()
    {
        double[,] data = new double[10, 3]; // weight, height(cm), BMI

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter weight(kg) for person {i + 1}: ");
            data[i, 0] = double.Parse(Console.ReadLine());
            Console.Write($"Enter height(cm) for person {i + 1}: ");
            data[i, 1] = double.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 10; i++)
        {
            data[i, 2] = CalculateBMI(data[i, 0], data[i, 1]);
        }

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Person {i + 1}: Weight={data[i,0]} kg, Height={data[i,1]} cm, BMI={data[i,2]:F2}, Status={GetBMIStatus(data[i,2])}");
        }
    }

    static double CalculateBMI(double weight, double heightCm)
    {
        double heightM = heightCm / 100;
        return weight / (heightM * heightM);
    }

    static string GetBMIStatus(double bmi)
    {
        if (bmi < 18.5) return "Underweight";
        else if (bmi < 24.9) return "Normal";
        else if (bmi < 29.9) return "Overweight";
        else return "Obese";
    }
}
