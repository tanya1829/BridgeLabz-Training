using System;

namespace BridgeLabzTraning.Employee
{
    internal class EmployeeUtility : IEmployee
    {
        private Employee employee;
        private Random random = new Random();

        public EmployeeUtility()
        {
            employee = new Employee("BridgeLabz Employee")
            {
                EmployeeID = 101
            };
        }

        public void ComputeEmployeeWage()
        {
            Console.WriteLine("\nEmployee Wage Computation Started...\n");

            while (employee.TotalWorkingDays < Employee.MAX_WORKING_DAYS &&
                   employee.TotalWorkingHours < Employee.MAX_WORKING_HOURS)
            {
                employee.TotalWorkingDays++;

                int empCheck = random.Next(0, 3);
                int empHours = 0;

                switch (empCheck)
                {
                    case 1:
                        empHours = Employee.FULL_TIME_HOURS;
                        Console.WriteLine($"Day {employee.TotalWorkingDays}: Full Time");
                        break;

                    case 2:
                        empHours = Employee.PART_TIME_HOURS;
                        Console.WriteLine($"Day {employee.TotalWorkingDays}: Part Time");
                        break;

                    default:
                        Console.WriteLine($"Day {employee.TotalWorkingDays}: Absent");
                        break;
                }

                if (employee.TotalWorkingHours + empHours > Employee.MAX_WORKING_HOURS)
                    empHours = Employee.MAX_WORKING_HOURS - employee.TotalWorkingHours;

                employee.TotalWorkingHours += empHours;
                employee.TotalWage += empHours * Employee.WAGE_PER_HOUR;

                Console.WriteLine($"Hours: {empHours}, Daily Wage: ₹{empHours * Employee.WAGE_PER_HOUR}\n");
            }

            Console.WriteLine("=================================");
            Console.WriteLine(" Monthly Wage Summary ");
            Console.WriteLine("=================================");
            Console.WriteLine($"Total Days  : {employee.TotalWorkingDays}");
            Console.WriteLine($"Total Hours : {employee.TotalWorkingHours}");
            Console.WriteLine($"Total Wage  : ₹{employee.TotalWage}");
            Console.WriteLine("=================================\n");
        }
    }
}