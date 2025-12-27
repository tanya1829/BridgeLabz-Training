using System;

class FormatExceptionDemo
{
    static void Main()
    {
        try
        {
            int x = int.Parse("abc");
        }
        catch (FormatException e)
        {
            Console.WriteLine("Exception Caught: " + e.GetType().Name);
        }
    }
}
