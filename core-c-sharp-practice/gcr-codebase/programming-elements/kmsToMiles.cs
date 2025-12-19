using System;

class kmsToMiles
{
    static void Main()
    {
        double kilometers = double.Parse(Console.ReadLine()); 
        
        double miles = kilometers * 0.621371;\
            
        Console.WriteLine(miles);
    }
}
