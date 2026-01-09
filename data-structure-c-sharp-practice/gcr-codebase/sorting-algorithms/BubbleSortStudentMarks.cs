using System;

class BubbleSortStudentMarks
{
    static void BubbleSort(int[] marks)
    {
        int n = marks.Length;

        // Outer loop for number of passes
        for (int i = 0; i < n - 1; i++)
        {
            // Inner loop for comparing adjacent elements
            for (int j = 0; j < n - i - 1; j++)
            {
                // Swap if elements are in wrong order
                if (marks[j] > marks[j + 1])
                {
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                }
            }
        }
    }

    static void Main()
    {
        int[] marks = { 78, 45, 89, 60, 72 };
        BubbleSort(marks);

        Console.WriteLine("Sorted Student Marks:");
        foreach (int m in marks)
            Console.Write(m + " ");
    }
}