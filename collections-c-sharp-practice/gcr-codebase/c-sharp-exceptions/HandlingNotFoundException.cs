using System;
using System.Collections.Generic;
using System.Text;
    internal class HandlingNotFoundException
    {
           public static void Main(string[] args)
            {
                string filePath = "data.txt";

                try
                {
                    // Open the file for reading
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        // Create byte array of file size
                        byte[] data = new byte[fs.Length];

                        // Read file data into byte array
                        fs.Read(data, 0, data.Length);

                        // Convert bytes to text
                        string content = Encoding.UTF8.GetString(data);

                        // Print file content
                        Console.WriteLine("File Content:");
                        Console.WriteLine(content);
                    }
                }
                catch (IOException)
                {
                    // Executes if file is not found or cannot be accessed
                    Console.WriteLine("File not found");
                }
            }
        }

