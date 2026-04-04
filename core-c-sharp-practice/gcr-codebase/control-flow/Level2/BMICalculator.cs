using System;

class BMICalculator
{
    static void Main(String[] args)
    {
        Console.Write("Weight (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());
        Console.Write("Height (cm): ");
        double heightCm = Convert.ToDouble(Console.ReadLine());

        double heightM = heightCm / 100;
        double bmi = weight / (heightM * heightM);

        Console.WriteLine("BMI: " + bmi);

        if (bmi < 18.5) Console.WriteLine("Underweight");
        else if (bmi < 25) Console.WriteLine("Normal");
        else if (bmi < 30) Console.WriteLine("Overweight");
        else Console.WriteLine("Obese");
    }
}
