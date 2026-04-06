using System;
using System.IO;

class ReadFileStreamReader
{
    static void Main()
    {
        using (StreamReader sr = new StreamReader("sample.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
