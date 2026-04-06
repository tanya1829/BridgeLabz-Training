using System;
using System.Collections.Generic;

class StockSpan
{
    static void CalculateSpan(int[] prices)
    {
        // Stack stores indices of days
        Stack<int> stack = new Stack<int>();

        // First day span is always 1
        stack.Push(0);
        Console.Write("1 ");

        for (int i = 1; i < prices.Length; i++)
        {
            // Remove days with price less than or equal to current
            while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                stack.Pop();

            // If stack empty → span is i+1
            int span = (stack.Count == 0) ? i + 1 : i - stack.Peek();
            Console.Write(span + " ");

            // Push current day index
            stack.Push(i);
        }
    }

    static void Main()
    {
        CalculateSpan(new int[] { 100, 80, 60, 70, 60, 75, 85 });
    }
}