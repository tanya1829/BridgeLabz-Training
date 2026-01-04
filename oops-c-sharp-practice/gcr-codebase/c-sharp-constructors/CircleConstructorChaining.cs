// Question:
// Write a Circle class and use constructor chaining
// to initialize radius with default and user-provided values.

using System;

class CircleConstructorChaining
{
    public double radius;

    // Default constructor calling parameterized constructor
    public Circle() : this(1)
    {
        // Default radius set using chaining
    }

    // Parameterized constructor
    public Circle(double r)
    {
        radius = r;
    }

    static void Main()
    {
        Circle c1 = new Circle();
        Circle c2 = new Circle(5);

        Console.WriteLine(c1.radius);
        Console.WriteLine(c2.radius);
    }
}