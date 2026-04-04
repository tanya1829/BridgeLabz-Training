using System;

class TrigonometricFunctions
{
    public static double[] Trigonometry(double angle)
    {
        double radian = angle * Math.PI / 180;

        double sin = Math.Sin(radian);
        double cos = Math.Cos(radian);
        double tan = Math.Tan(radian);

        return new double[] { sin, cos, tan };
    }

    static void Main()
    {
        Console.Write("Enter angle in degrees: ");
        double angle = Convert.ToDouble(Console.ReadLine());

        double[] result = Trigonometry(angle);

        Console.WriteLine("Sin = " + result[0]);
        Console.WriteLine("Cos = " + result[1]);
        Console.WriteLine("Tan = " + result[2]);
    }
}
