using System;

class MetalFactoryPipeCutting
{
    static int maxProfit = 0;
    static int totalRodLength = 8;

    public static void Main()
    {
        int[] rodSizes = { 1,2,3,4,5,6,7,8 };
        int[] prices   = { 1,5,8,9,10,17,17,20 };

        CalculateProfit(rodSizes, prices, 0, 0);
        Console.WriteLine("Maximum Profit: " + maxProfit);
    }

    public static void CalculateProfit(int[] sizes, int[] prices, int usedLength, int profit)
    {
        // Exact length achieved
        if (usedLength == totalRodLength)
        {
            if (profit > maxProfit)
                maxProfit = profit;
            return;
        }

        // Length exceeded
        if (usedLength > totalRodLength)
            return;

        // Try all possible cuts
        for (int i = 0; i < sizes.Length; i++)
        {
            CalculateProfit(
                sizes,
                prices,
                usedLength + sizes[i],
                profit + prices[i]
            );
        }
    }
}
