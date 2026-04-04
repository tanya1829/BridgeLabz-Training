using System;
using System.Text;

class ReverseStringusigStringBuilder{
    static void Main(){
        Console.WriteLine("Enter a String ");
        
        string str= Console.ReadLine();
        StringBuilder sb= new StringBuilder(str);
        sb.Reverse();
        Console.WriteLine("The Reversed string is : " + sb);

    }
}
