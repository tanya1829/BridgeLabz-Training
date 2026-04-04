using System;

class Handshakes
{
    static void Main()
    {
        Console.Write("Enter the number of students: ");
        int numOfStudents = Convert.ToInt32(Console.ReadLine());

        int handshakes = (numOfStudents * (numOfStudents - 1)) / 2;

        Console.WriteLine("Maximum number of handshakes = " + handshakes);
    }
}
