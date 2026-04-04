using System;

class Quadratic
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());

        double[] roots = FindRoots(a, b, c);
        if (roots.Length == 0)
            Console.WriteLine("No real roots");
        else
            Console.WriteLine("Roots: " + string.Join(", ", roots));
    }

    static double[] FindRoots(double a, double b, double c)
    {
        double delta = b * b - 4 * a * c;
        if (delta < 0) return new double[0];
        if (delta == 0) return new double[] { -b / (2 * a) };
        double sqrtDelta = Math.Sqrt(delta);
        return new double[] { (-b + sqrtDelta) / (2 * a), (-b - sqrtDelta) / (2 * a) };
    }
}
