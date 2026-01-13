using System;
using System.IO;  // Required for FileStream and StreamReader

class ByteStreamToCharacterUsingstreamReader
{
    static void Main()
    {
        string filePath = "sample.txt"; // Path to the file to read

        try
        {
            // Open the file as a byte stream
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // Convert byte stream to character stream using StreamReader
                using (StreamReader reader = new StreamReader(fs))
                {
                    int ch;

                    // Read each character until end of file (-1)
                    while ((ch = reader.Read()) != -1)
                    {
                        Console.Write((char)ch); // Convert byte to character and print
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file was not found.");
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}
