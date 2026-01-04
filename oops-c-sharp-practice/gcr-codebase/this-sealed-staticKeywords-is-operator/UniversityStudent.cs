// Question:
// Create a Student class using static, this, readonly and is operator
// for University Student Management.

using System;

class UniversityStudent
{
    // Static university name
    public static string UniversityName = "GLA University";
    private static int totalStudents = 0;

    // Readonly roll number
    public readonly int RollNumber;
    public string Name;
    public char Grade;

    // Constructor using this keyword
    public Student(int RollNumber, string Name, char Grade)
    {
        this.RollNumber = RollNumber;
        this.Name = Name;
        this.Grade = Grade;
        totalStudents++;
    }

    // Static method to display total students
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    static void Main()
    {
        Student s = new Student(1, "Ana", 'A');

        if (s is Student)
        {
            Console.WriteLine(s.Name + " Grade: " + s.Grade);
        }

        DisplayTotalStudents();
    }
}