using System;

class CustomFurnitureManufacturing
{
    static int bestProfit = 0;
    static int totalRod = 12;

    static void Main()
    {
        Console.Write("Enter allowed waste: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int wasted))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        int[] sizes = {1,2,3,4,5,6,7,8,9,10,11,12};
        int[] values = {1,5,8,9,10,17,17,20,22,22,25,26};

        CalculateProfit(sizes, values, 0, 0, wasted);
        Console.WriteLine("Best Profit: " + bestProfit);
    }

    static void CalculateProfit(int[] sizes, int[] values, int used, int money, int wasted)
    {
        int usableLength = totalRod - wasted;

        if (used == usableLength)
        {
            if (money > bestProfit)
                bestProfit = money;
            return;
        }

        if (used > usableLength)
            return;

        for (int i = 0; i < sizes.Length; i++)
        {
            CalculateProfit(
                sizes,
                values,
                used + sizes[i],
                money + values[i],
                wasted
            );
        }
    }
}

