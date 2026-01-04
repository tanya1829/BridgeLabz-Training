// Question:
// Write a program to create a Circle class with radius as attribute.
// Add methods to calculate and display area and circumference of the circle.

using System;

class CircleArea
{
    // Radius of the circle
    public double radius;

    // Method to calculate and display area and circumference
    public void Calculate()
    {
        Console.WriteLine("Area: " + (Math.PI * radius * radius));
        Console.WriteLine("Circumference: " + (2 * Math.PI * radius));
    }

    static void Main()
    {
        // Creating circle object
        Circle c = new Circle();

        // Assigning radius value
        c.radius = 5;

        // Calling calculation method
        c.Calculate();
    }
}