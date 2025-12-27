using System;
using System.Runtime.Intrinsics.Arm;
class CompareTwoStrings
{
   
        static bool CompareUsingCharAt(string a , string b)
    {
        if(a.Length != b.Length)
        return false;
        for(int i=0;i<a.Length; i++)
        {
            if(a[i] != b[i])
            return false;
        }
        return true;
    }
     static void Main()
    {
        Console.Write("Enter the first String");
        string str1 = Console.ReadLine();
         Console.Write("Enter the second String");
         string str2 = Console.ReadLine();
          bool result = CompareUsingCharAt(str1 , str2);
          Console.WriteLine( result );

        Console.WriteLine(str1.Equals(str2));
    }
        
    }
