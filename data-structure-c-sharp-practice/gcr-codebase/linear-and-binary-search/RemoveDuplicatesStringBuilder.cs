using System;
using System.Text;
// removed duplicate characters using StringBuilder

class RemoveDuplicatesStringBuilder{
    static void Main(){
        Console.WriteLine("Enter a string:");
        string str = Console.ReadLine();

        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < str.Length; i++)
        {
            char currentChar = str[i];
            bool alreadyPresent = false;

            // check if character already exists in result
            for (int j = 0; j < result.Length; j++)
            {
                if (result[j] == currentChar)
                {
                    alreadyPresent = true;
                    break;
                }
            }

            // add only if not present
            if (alreadyPresent == false)
            {
                result.Append(currentChar);
            }
        }

        Console.WriteLine("String without duplicates: " + result);
    }
}