using System;
class CountVowelsAndConsonants
{
    static void Main(){
        Console.WriteLine("enter the string");
        string s = Console.ReadLine();
         int vowels=0;
         int consonants=0;
         for(int i =0; i< s.Length; i++){
            char ch = char.ToLower(s[i]);
            if(ch >= 'a' && ch <= 'z')
            {
                if(ch == 'a' || ch == 'e' || ch== 'i' || ch== 'o' || ch== 'u')
                vowels++;
                else
                consonants++;

            }

         }
        
        Console.WriteLine("Vowels : " + vowels);
        Console.WriteLine("consonants : " + consonants);
         
    }
}