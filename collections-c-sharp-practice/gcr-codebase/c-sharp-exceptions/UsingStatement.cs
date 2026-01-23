using System;
using System.Collections.Generic;
using System.Text;

    internal class UsingStatement
    {    
            public static void Main(string[] args)
            {
                string filePath = "info.txt";

                try
                {
                    // using ensures the file is closed automatically
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read first line from file
                        string firstLine = reader.ReadLine();

                        // Print the first line
                        Console.WriteLine("First line of file:");
                        Console.WriteLine(firstLine);
                    }
                }
                catch (IOException)
                {
                    // Executes if file is not found or cannot be read
                    Console.WriteLine("Error reading file");
                }
            }
        }
    