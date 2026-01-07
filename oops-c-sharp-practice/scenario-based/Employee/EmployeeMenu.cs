using System;

namespace BridgeLabzTraning.Employee
{
    sealed class EmployeeMenu
    {
        private IEmployee employeeUtility;

        public EmployeeMenu()
        {
            employeeUtility = new EmployeeUtility();
            ShowMenu();
        }

        private void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(" Welcome to Employee Wage Computation ");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Compute Employee Wage");
                Console.WriteLine("2. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        employeeUtility.ComputeEmployeeWage();
                        break;
                    case 2:
                        Console.WriteLine("Exiting Program...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (choice != 2);
        }
    }
}