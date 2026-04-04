using System;

class StudentGradeCalculator
{
    static void Main(string[] args)
    {
       
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        
        double[] physics = new double[n];
        double[] chemistry = new double[n];
        double[] maths = new double[n];

        // Arrays to store percentage and grade
        double[] percentage = new double[n];
        char[] grade = new char[n];

        
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter marks for Student " + (i + 1));

            // Physics marks
            Console.Write("Physics: ");
            physics[i] = Convert.ToDouble(Console.ReadLine());

            
            if (physics[i] < 0)
            {
                Console.WriteLine("Invalid marks! Enter positive values.");
                i--;          
                continue;
            }

            // Chemistry marks
            Cons

