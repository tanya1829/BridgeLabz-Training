// Question:
// Create a Student class with rollNumber as public, name as protected,
// and CGPA as private.
// Implement public methods to access and modify CGPA.
// Create a subclass PostgraduateStudent to demonstrate protected access.

using System;

class StudentAccess
{
    // Public member - accessible everywhere
    public int rollNumber;

    // Protected member - accessible in derived classes
    protected string name;

    // Private member - accessible only inside this class
    private double cgpa;

    // Public method to set CGPA
    public void SetCGPA(double value)
    {
        cgpa = value;
    }

    // Public method to get CGPA
    public double GetCGPA()
    {
        return cgpa;
    }
}

// Subclass to demonstrate protected access
class PostgraduateStudent : Student
{
    public void DisplayStudentName()
    {
        name = "Ana"; // accessing protected variable
        Console.WriteLine("Student Name: " + name);
    }

    static void Main()
    {
        PostgraduateStudent pg = new PostgraduateStudent();
        pg.rollNumber = 101;
        pg.SetCGPA(8.5);

        pg.DisplayStudentName();
        Console.WriteLine("CGPA: " + pg.GetCGPA());
    }
}