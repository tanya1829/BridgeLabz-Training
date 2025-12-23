using System;

class FriendsComparison
{
    static void Main(String[] args)
    {
        Console.Write("Amar Age & Height: ");
        int aAge = Convert.ToInt32(Console.ReadLine());
        int aHt = Convert.ToInt32(Console.ReadLine());

        Console.Write("Akbar Age & Height: ");
        int bAge = Convert.ToInt32(Console.ReadLine());
        int bHt = Convert.ToInt32(Console.ReadLine());

        Console.Write("Anthony Age & Height: ");
        int cAge = Convert.ToInt32(Console.ReadLine());
        int cHt = Convert.ToInt32(Console.ReadLine());

        int youngestAge = Math.Min(aAge, Math.Min(bAge, cAge));
        int tallestHt = Math.Max(aHt, Math.Max(bHt, cHt));

        Console.WriteLine("Youngest Age: " + youngestAge);
        Console.WriteLine("Tallest Height: " + tallestHt);
    }
}
