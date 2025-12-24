using System;

class EmployeeBonus
{
    static void Main()
    {
        
        int employeeCount = 10;

        
        double[] salaries = new double[employeeCount];
        double[] yearsOfService = new double[employeeCount];

        
        double[] bonuses = new double[employeeCount];
        double[] newSalaries = new double[employeeCount];

        
        double totalBonus = 0.0;
        double totalOldSalary = 0.0;
        double totalNewSalary = 0.0;

        
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"\nEmployee {i + 1}");

            Console.Write("Enter salary: ");
            if (!double.TryParse(Console.ReadLine(), out salaries[i]) || salaries[i] <= 0)
            {
                Console.Error.WriteLine("Invalid salary. Please re-enter.");
                i--; // Decrement index to retry
                continue;
            }

            Console.Write("Enter years of service: ");
            if (!double.TryParse(Console.ReadLine(), out yearsOfService[i]) || yearsOfService[i] < 0)
            {
                Console.Error.WriteLine("Invalid years of service. Please re-enter.");
                i--; // Decrement index to retry
                continue;
            }
        }

        
        for (int i = 0; i < employeeCount; i++)
        {
            // Calculate bonus based on years of service
            if (yearsOfService[i] > 5)
                bonuses[i] = salaries[i] * 0.05;
            else
                bonuses[i] = salaries[i] * 0.02;

            // Calculate new salary
            newSalaries[i] = salaries[i] + bonuses[i];

            // Update totals
            totalBonus += bonuses[i];
            totalOldSalary += salaries[i];
            totalNewSalary += newSalaries[i];
        }

        // Display totals
        Console.WriteLine("\n--- Company Bonus Summary ---");
        Console.WriteLine($"Total Old Salary: {totalOldSalary}");
        Console.WriteLine($"Total Bonus Paid: {totalBonus}");
        Console.WriteLine($"Total New Salary: {totalNewSalary}");
    }
}
