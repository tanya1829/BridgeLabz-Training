using System;
using System.Text;
using System.Diagnostics;

class CompareStringBuilder
{
    static void Main()
    {
        int n = 10000;

        // Using String
        Stopwatch sw1 = new Stopwatch();
        sw1.Start();
        string str = "";
        for (int i = 0; i < n; i++)
        {
            str += "a";
        }
        sw1.Stop();
        Console.WriteLine("Time using string: " + sw1.ElapsedMilliseconds + " ms");

        // Using StringBuilder
        Stopwatch sw2 = new Stopwatch();
        sw2.Start();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; ii++)
        {
            sb.Append("a");
        }
        sw2.Stop();
        Console.WriteLine("Time using StringBuilder: " + sw2.ElapsedMilliseconds + " ms");
    }
}
