using System;
class LargestWordInSentence{
    static void MAin(){
        Console.WriteLine("enter a sentence");
        string str = Console.ReadLine();
        string word="";
        string  largestWord="";
        for(int i=0; i<=sentence.Length;i++){
            char ch;
            if(i==str.Length)
            ch= ' ';
            else
                ch = sentence[i];

            if (ch != ' ') {
                word += ch;
            } else {
                if (word.Length > largestWord.Length) {
                    largestWord = word;
                }
                word = "";
            }
        }
        Console.WriteLine("Longest word: " + largestWord);
    }
}