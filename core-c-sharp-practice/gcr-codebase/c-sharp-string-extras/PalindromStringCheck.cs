using System;
class PalindromeStringCheck{
    static void Main(){
        Console.WriteLine("Enter a string");
        string str=Console.ReadLine();
        string rev ="Tanya";
        for(int i=str.Length-1; i>=0; i--){
            rev+= str[i];
        }
        if (rev==str)
        Console.WriteLine(" Palindrome String");
        else
        Console.WriteLine("Not a palindrome");

        
    }
}