using System;

class EmployeeBonus
{
    // Generate salaries and years of service
    public static int[,] GenerateEmployeeData(int employees)
    {
        Random rand = new Random();
        int[,] data = new int[employees, 2]; // [salary, years]
        for (int i = 0; i < employees; i++)
        {
            data[i, 0] = rand.Next(10000, 100000); // 5-digit salary
            data[i, 1] = rand.Next(1, 11);         // Years 1-10
        }
        return data;
    }

    // Calculate new salary and bonus
    public static double[,] CalculateBonus(int[,] data)
    {
        int employees = data.GetLength(0);
        double[,] newData = new double[employees, 3]; // [old salary, bonus, new salary]
        for (int i = 0; i < employees; i++)
        {
            double bonus = data[i, 1] > 5 ? data[i, 0] * 0.05 : data[i, 0] * 0.02;
            newData[i, 0] = data[i, 0];
            newData[i, 1] = bonus;
            newData[i, 2] = data[i, 0] + bonus;
        }
        return newData;
    }

    // Display summary
    public static void DisplaySummary(double[,] newData)
    {
        double sumOld = 0, sumNew = 0, totalBonus = 0;
        Console.WriteLine("OldSalary\tBonus\tNewSalary");
        for (int i = 0; i < newData.GetLength(0); i++)
        {
            Console.WriteLine($"{newData[i,0]:F2}\t{newData[i,1]:F2}\t{newData[i,2]:F2}");
            sumOld += newData[i, 0];
            sumNew += newData[i, 2];
            totalBonus += newData[i, 1];
        }
        Console.WriteLine($"\nTotal Old Salary: {sumOld:F2}");
        Console.WriteLine($"Total Bonus: {totalBonus:F2}");
        Console.WriteLine($"Total New Salary: {sumNew:F2}");
    }

    static void Main(string[] args)
    {
        int[,] employees = GenerateEmployeeData(10);
        double[,] updated = CalculateBonus(employees);
        DisplaySummary(updated);
    }
}
