using System;       // Required for Console operations
using System.IO;    // Required for File and StreamReader

class ReadFileStreamReader
{
    static void Main()
    {
        string filePath = "sample.txt"; // Path of the file to read

        try
        {
            // Create a StreamReader to read the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                // Read the file line by line
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line); // Print each line to the console
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
