using System;

class StringIndexOutOfRange
{
    static void Main()
    {
        try
        {
            string stringg = "Hello";
            Console.WriteLine(stringg[10]);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Output : Exception Caught: " + e.GetType().Name);
        }
    }
}
