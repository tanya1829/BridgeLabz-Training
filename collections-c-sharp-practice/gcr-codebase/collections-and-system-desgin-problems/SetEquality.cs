using System;
using System.Collections.Generic;

class SetEquality
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };

        bool result = set1.SetEquals(set2);
        Console.WriteLine(result); // true
    }
}
