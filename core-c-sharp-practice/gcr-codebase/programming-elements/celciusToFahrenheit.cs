
using System;
class celciusToFahrenheit
{
    static void Main() 
    {
        int temp = int.Parse(Console.ReadLine());
		
        int f = (temp * 9 / 5) + 32;
		
        Console.WriteLine(f);
    }
}
