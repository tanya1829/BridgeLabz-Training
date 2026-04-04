using System;

class Staff
{
    public static string EmpName = "Zainab";
    public static int EmpId = 101;
    public static int EmpSalary = 30000;

    public void ShowDetails()
    {
        Console.WriteLine("Name = " + EmpName +
                          " Id = " + EmpId +
                          " Salary = " + EmpSalary);
    }
}

class Lead : Staff
{
    public static int TeamCount = 5;

    public void ShowDetails()
    {
        Console.WriteLine("Name = " + EmpName +
                          " Id = " + EmpId +
                          " Salary = " + EmpSalary +
                          " Team Count = " + TeamCount);
    }
}

class Engineer : Staff
{
    public static string Language = "C#";

    public void ShowDetails()
    {
        Console.WriteLine("Name = " + EmpName +
                          " Id = " + EmpId +
                          " Salary = " + EmpSalary +
                          " Language = " + Language);
    }
}

class TraineeStaff : Staff
{
    public static string Duration = "6 Months";

    public void ShowDetails()
    {
        Console.WriteLine("Name = " + EmpName +
                          " Id = " + EmpId +
                          " Salary = " + EmpSalary +
                          " Training Duration = " + Duration);
    }
}

class Program
{
    public static void Main()
    {
        Staff staff = new Staff();
        Lead lead = new Lead();
        Engineer engineer = new Engineer();
        TraineeStaff trainee = new TraineeStaff();

        staff.ShowDetails();
        lead.ShowDetails();
        engineer.ShowDetails();
        trainee.ShowDetails();
    }
}