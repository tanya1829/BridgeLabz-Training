using System;
class ReverseAString{
    static void Main(){
         Console.WriteLine("Enter a String");
         string str = Console.ReadLine();
         string rev= "";
         for(int i = str.Length-1; i>=0; i--){
            rev+= str[i];

         }
         Console.WriteLine("Reversed Line : " + rev);

    }
}