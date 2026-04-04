using System;

class FriendssComparison
{
    static void Main()
    {
        
        string[] names = { "Amar", "Akbar", "Anthony" };

        
        int[] ages = new int[3];
        double[] heights = new double[3];

        
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"\nEnter details for {names[i]}");

            Console.Write("Age: ");
            ages[i] = int.Parse(Console.ReadLine());

            Console.Write("Height: ");
            heights[i] = double.Parse(Console.ReadLine());
        }

        // Initialize youngest and tallest
        int youngestIndex = 0;
        int tallestIndex = 0;

        // Find youngest and tallest
        for (int i = 1; i < names.Length; i++)
        {
            if (ages[i] < ages[youngestIndex])
                youngestIndex = i;

            if (heights[i] > heights[tallestIndex])
                tallestIndex = i;
        }

        
        Console.WriteLine($"\nYoungest: {names[youngestIndex]}");
        Console.WriteLine($"Tallest: {names[tallestIndex]}");
    }
}
