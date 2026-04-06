using System;
using System.Collections.Generic;

class SymmetricDifference
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        set1.SymmetricExceptWith(set2);

        Console.WriteLine(string.Join(", ", set1)); // 1, 2, 4, 5
    }
}
