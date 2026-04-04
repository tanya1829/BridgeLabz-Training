using System;

class NullReference
{
    static void Main()
    {
        try
        {
            string str = null;
            Console.WriteLine(str.Length);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(" Output - Exception Caught: " + e.GetType().Name);
        }
    }
}
