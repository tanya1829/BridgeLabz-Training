using System;

class Substring
{
    static void Main()
    {
        Console.WriteLine("enter the string");

        string s1= Console.ReadLine();
        Console.WriteLine("enter the start index");
        int startIndex= int.Parse(Console.ReadLine ());
        Console.WriteLine("enter the end index");
        int endIndex= int.Parse(Console.ReadLine());
    
       string custom=  CreatingSubstring( s1, startIndex ,  endIndex);
       string builtIn = s1.Substring(startIndex, endIndex - startIndex);
       
       Console.WriteLine(custom);
       Console.WriteLine(builtIn);

    } 
     static string CreatingSubstring(string s, int startIndex, int endIndex){
        string result ="";
        for(int i=startIndex; i< endIndex; i++){
            result += s[i];
        }
        return result;
     }
}
