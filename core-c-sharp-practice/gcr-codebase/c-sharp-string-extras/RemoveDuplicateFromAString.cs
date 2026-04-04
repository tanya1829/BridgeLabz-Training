using System;
class RemoveDuplicateFromString{
    static void Main(){
        Console.WriteLine("Enter a string");
        string str = Console.ReadLine();
        string res="";
        for(int i =0; i<str.Length; i++){
            char ch =str[i];
            if(!res.Contains(ch)){
                res+=ch;
            }
        }
    Console.WriteLine("string after removing duplicates : " + res)
;    }
}