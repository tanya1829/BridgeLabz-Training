using System;

namespace BridgeLabzTraning.Employee
{
    internal class Employee
    {
        public Employee() { }

        public Employee(string name)
        {
            EmployeeName = name;
        }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public int TotalWorkingDays { get; set; }
        public int TotalWorkingHours { get; set; }
        public int TotalWage { get; set; }

        public const int WAGE_PER_HOUR = 20;
        public const int FULL_TIME_HOURS = 8;
        public const int PART_TIME_HOURS = 4;
        public const int MAX_WORKING_DAYS = 20;
        public const int MAX_WORKING_HOURS = 100;

        public override string ToString()
        {
            return $"Employee ID: {EmployeeID}, Name: {EmployeeName}, Total Wage: {TotalWage}";
        }
    }
}