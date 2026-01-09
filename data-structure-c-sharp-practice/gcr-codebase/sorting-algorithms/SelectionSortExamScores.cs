using System;

class SelectionSortExamScores
{
    static void SelectionSort(int[] scores)
    {
        for (int i = 0; i < scores.Length - 1; i++)
        {
            int minIndex = i;

            // Find minimum in unsorted part
            for (int j = i + 1; j < scores.Length; j++)
                if (scores[j] < scores[minIndex])
                    minIndex = j;

            // Swap minimum with first unsorted element
            (scores[i], scores[minIndex]) = (scores[minIndex], scores[i]);
        }
    }

    static void Main()
    {
        int[] scores = { 65, 85, 70, 90 };
        SelectionSort(scores);

        Console.WriteLine("Sorted Exam Scores:");
        foreach (int s in scores)
            Console.Write(s + " ");
    }
}