// Question:
// Design an Employee class demonstrating static, this, readonly and is operator.

using System;

class EmployeeManagement
{
    // Static variable shared by all employees
    public static string CompanyName = "TechCorp";
    private static int totalEmployees = 0;

    // Readonly employee ID
    public readonly int Id;
    public string Name;
    public string Designation;

    // Constructor using this keyword
    public Employee(int Id, string Name, string Designation)
    {
        this.Id = Id;
        this.Name = Name;
        this.Designation = Designation;
        totalEmployees++;
    }

    // Static method to display total employees
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    static void Main()
    {
        Employee e = new Employee(1, "Ana", "Developer");

        if (e is Employee)
        {
            Console.WriteLine(e.Name + " - " + e.Designation);
        }

        DisplayTotalEmployees();
    }
}