using System;

class NumberChecker
{
    static void Main()
    {
        int[] nums = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            nums[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (IsPositive(nums[i]))
            {
                Console.WriteLine($"{nums[i]} is positive and {(IsEven(nums[i]) ? "even" : "odd")}");
            }
            else
            {
                Console.WriteLine($"{nums[i]} is negative");
            }
        }

        int cmp = Compare(nums[0], nums[4]);
        Console.WriteLine("First vs Last: " + (cmp == 1 ? "First > Last" : cmp == -1 ? "First < Last" : "First = Last"));
    }

    static bool IsPositive(int n) => n >= 0;
    static bool IsEven(int n) => n % 2 == 0;
    static int Compare(int a, int b) => a > b ? 1 : a < b ? -1 : 0;
}
