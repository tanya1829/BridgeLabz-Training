using System;
using System.Collections.Generic;

class SubsetCheck
{
    static void Main()
    {
        HashSet<int> a = new HashSet<int> { 2, 3 };
        HashSet<int> b = new HashSet<int> { 1, 2, 3, 4 };

        Console.WriteLine(a.IsSubsetOf(b)); // true
    }
}
