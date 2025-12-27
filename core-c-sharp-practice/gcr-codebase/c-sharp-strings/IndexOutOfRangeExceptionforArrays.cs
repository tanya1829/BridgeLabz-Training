using System;

class IndexOutOfRangeException
{
    static void Main()
    {
        try
        {
            int[] arr = { 1, 2, 3 };
            Console.WriteLine(arr[5]);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Exception Caught: " + e.GetType().Name);
        }
    }
}
