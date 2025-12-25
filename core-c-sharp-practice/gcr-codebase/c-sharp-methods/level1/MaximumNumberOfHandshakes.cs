using System;
class MaximumNumberOfHandshakes
{
    static void Main()
    {  // taking user input
	
        Console.Write("Enter the number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int handshakes = CalculateHandshakes(n);
        Console.WriteLine("Maximum number of handshakes: " + handshakes);
    }

    // Method to calculate handshakes
    static int CalculateHandshakes(int n)
    {
        return (n * (n - 1)) / 2;
    }
}
