using System;

class ArgumentOutOfRangeDemo
{
    static void Main()
    {
        try
        {
            string str = "Hello";
            Console.WriteLine(str.Substring(5, -1));
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception Caught: " + e.GetType().Name);
        }
    }
}
