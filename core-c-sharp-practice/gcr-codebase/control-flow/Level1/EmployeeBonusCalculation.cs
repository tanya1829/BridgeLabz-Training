using System;

class EmployeeBonusCalculation
{
    static void Main()
    {
        //Taking salary as double
        double salary = Convert.ToDouble(Console.ReadLine());
        
        int year = Convert.ToInt32(Console.ReadLine());

        if (year > 5)
			
            Console.WriteLine($"Bonus = {salary * 0.05}");
			
        else
            Console.WriteLine("No bonus");
    }
}
