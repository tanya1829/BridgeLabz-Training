using System;

//  Interface for Department
interface IDepartment
{
    void SetDepartment(string deptName);
    string ShowDepartment();
}

//  Abstract Employee 
abstract class Employee
{
    private int empId;
    private string empName;
    private double basicPay;

    public void SetEmpId(int id) { empId = id; }
    public int GetEmpId() { return empId; }

    public void SetEmpName(string name) { empName = name; }
    public string GetEmpName() { return empName; }

    public void SetBasicPay(double pay) { basicPay = pay; }
    public double GetBasicPay() { return basicPay; }

    // Common display method
    public void ShowEmployee()
    {
        Console.WriteLine("Employee ID: " + empId);
        Console.WriteLine("Employee Name: " + empName);
        Console.WriteLine("Basic Salary: " + basicPay);
    }

    // Abstract salary calculation
    public abstract double GetSalary();
}

//  Full-Time Employee 
class FullTimeEmployee : Employee, IDepartment
{
    private string dept;

    public void SetDepartment(string deptName)
    {
        dept = deptName;
    }

    public string ShowDepartment()
    {
        return dept;
    }

    // Salary with bonus
    public override double GetSalary()
    {
        return GetBasicPay() + (0.20 * GetBasicPay()); // 20% bonus
    }

    public void ShowFullTimeDetails()
    {
        ShowEmployee();
        Console.WriteLine("Department: " + ShowDepartment());
        Console.WriteLine("Total Salary: " + GetSalary());
    }
}

// Part-Time Employee
class PartTimeEmployee : Employee, IDepartment
{
    private string dept;
    private int hoursWorked;

    public void SetDepartment(string deptName)
    {
        dept = deptName;
    }

    public string ShowDepartment()
    {
        return dept;
    }

    public void SetHoursWorked(int hours)
    {
        hoursWorked = hours;
    }

    public int GetHoursWorked()
    {
        return hoursWorked;
    }

    // Hourly salary calculation
    public override double GetSalary()
    {
        return GetHoursWorked() * GetBasicPay();
    }

    public void ShowPartTimeDetails()
    {
        ShowEmployee();
        Console.WriteLine("Department: " + ShowDepartment());
        Console.WriteLine("Hours Worked: " + GetHoursWorked());
        Console.WriteLine("Total Salary: " + GetSalary());
    }
}

//  Main Program 
class Program
{
    static void Main()
    {
        FullTimeEmployee fullEmp = new FullTimeEmployee();
        fullEmp.SetEmpId(1);
        fullEmp.SetEmpName("Rahul");
        fullEmp.SetBasicPay(50000);
        fullEmp.SetDepartment("IT");

        PartTimeEmployee partEmp = new PartTimeEmployee();
        partEmp.SetEmpId(2);
        partEmp.SetEmpName("Anita");
        partEmp.SetBasicPay(500); // per hour
        partEmp.SetHoursWorked(80);
        partEmp.SetDepartment("HR");

        Console.WriteLine("---- Full Time Employee ----");
        fullEmp.ShowFullTimeDetails();

        Console.WriteLine("\n---- Part Time Employee ----");
        partEmp.ShowPartTimeDetails();
    }
}
