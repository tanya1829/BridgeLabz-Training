// Question:
// Develop an Employee class with employeeID as public,
// department as protected, and salary as private.
// Implement public methods to modify salary.
// Create a subclass Manager to access employeeID and department.

using System;

class EmployeeAccess
{
    // Public member
    public int employeeID;

    // Protected member
    protected string department;

    // Private member
    private double salary;

    // Public method to set salary
    public void SetSalary(double amount)
    {
        salary = amount;
    }

    // Public method to get salary
    public double GetSalary()
    {
        return salary;
    }
}

// Subclass demonstrating protected access
class Manager : Employee
{
    public void DisplayEmployeeInfo()
    {
        employeeID = 201;
        department = "IT";

        Console.WriteLine("Employee ID: " + employeeID);
        Console.WriteLine("Department: " + department);
    }

    static void Main()
    {
        Manager m = new Manager();
        m.SetSalary(75000);

        m.DisplayEmployeeInfo();
        Console.WriteLine("Salary: " + m.GetSalary());
    }
}