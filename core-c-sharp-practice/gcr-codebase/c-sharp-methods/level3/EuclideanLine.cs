using System;

class EuclideanLine
{
    // Calculate Euclidean distance
    public static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    // Calculate slope and y-intercept
    public static double[] LineEquation(double x1, double y1, double x2, double y2)
    {
        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - m * x1;
        return new double[] { m, b };
    }

    static void Main(string[] args)
    {
        Console.Write("Enter x1: "); double x1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter y1: "); double y1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter x2: "); double x2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter y2: "); double y2 = Convert.ToDouble(Console.ReadLine());

        double dist = Distance(x1, y1, x2, y2);
        double[] line = LineEquation(x1, y1, x2, y2);

        Console.WriteLine($"Euclidean Distance: {dist:F2}");
        Console.WriteLine($"Equation of Line: y = {line[0]:F2}*x + {line[1]:F2}");
    }
}
