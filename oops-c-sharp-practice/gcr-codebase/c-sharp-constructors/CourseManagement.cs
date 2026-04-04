// Question:
// Design a Course class with instance variables courseName, duration, and fee.
// Create a class variable instituteName common for all courses.
// Implement an instance method to display course details
// and a class method to update institute name.

using System;

class CourseManagement
{
    // Instance variables
    public string courseName;
    public int duration;
    public double fee;

    // Class variable shared by all courses
    public static string instituteName = "GLA University";

    // Instance method to display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Course Name: " + courseName);
        Console.WriteLine("Duration: " + duration + " days");
        Console.WriteLine("Fee: " + fee);
        Console.WriteLine("Institute: " + instituteName);
    }

    // Class method to update institute name
    public static void UpdateInstituteName(string name)
    {
        instituteName = name;
    }

    static void Main()
    {
        Course c1 = new Course();
        c1.courseName = "C# Programming";
        c1.duration = 30;
        c1.fee = 5000;

        // Displaying course details
        c1.DisplayCourseDetails();

        // Updating institute name for all courses
        Course.UpdateInstituteName("GLA Online Academy");

        // Displaying updated details
        c1.DisplayCourseDetails();
    }
}