// Question:
// Write a program to create an Employee class with attributes name, id, and salary.
// Add a method to display the employee details.

using System;

class EmployeeDetails
{
    // Employee basic details
    public string name;
    public int id;
    public double salary;

    // This method is used to display employee information
    public void DisplayDetails()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Salary: " + salary);
    }

    static void Main()
    {
        // Creating object of Employee class
        Employee emp = new Employee();

        // Assigning values to employee object
        emp.name = "Ana";
        emp.id = 101;
        emp.salary = 50000;

        // Calling method to display details
        emp.DisplayDetails();
    }
}