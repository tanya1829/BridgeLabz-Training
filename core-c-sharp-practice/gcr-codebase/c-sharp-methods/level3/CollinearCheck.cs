using System;

class CollinearCheck
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        double x1 = double.Parse(input[0]);
        double y1 = double.Parse(input[1]);
        double x2 = double.Parse(input[2]);
        double y2 = double.Parse(input[3]);
        double x3 = double.Parse(input[4]);
        double y3 = double.Parse(input[5]);

        bool slopeResult = AreCollinearSlope(x1, y1, x2, y2, x3, y3);
        bool areaResult  = AreCollinearArea(x1, y1, x2, y2, x3, y3);

        if (slopeResult && areaResult)
            Console.WriteLine("Points are Collinear");
        else
            Console.WriteLine("Points are NOT Collinear");
    }

    // Method using slope formula
    static bool AreCollinearSlope(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);

        return slopeAB == slopeBC && slopeBC == slopeAC;
    }

    // Method using area of triangle formula
    static bool AreCollinearArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        double area = 0.5 * (x1*(y2 - y3) + x2*(y3 - y1) + x3*(y1 - y2));
        return area == 0;
    }
}
