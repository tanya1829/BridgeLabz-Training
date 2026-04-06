using System;
using System.IO;

class ByteStreamToCharacterUsingStreamReader
{
    static void Main()
    {
        using (FileStream fs = new FileStream("sample.txt", FileMode.Open))
        using (StreamReader sr = new StreamReader(fs))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
}
