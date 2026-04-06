using System;
using System.Diagnostics;
using System.Text;

class StringPerformance
{
    static void Main()
    {
        int count = 10000;
        Stopwatch sw = new Stopwatch();
        string s = "";
        sw.Start();
        for (int i = 0; i < count; i++)
        {
            s = s + "a";
        }
        sw.Stop();
        Console.WriteLine("String Time: " + sw.ElapsedMilliseconds + " ms");
        StringBuilder sb = new StringBuilder();
        sw.Reset();
        sw.Start();
        for (int i = 0; i < count; i++)
        {
            sb.Append("a");
        }
        sw.Stop();
        Console.WriteLine("StringBuilder Time: " + sw.ElapsedMilliseconds + " ms");
    }
}