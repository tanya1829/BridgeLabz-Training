using System;

class SentenceFormatter
{
    static void Main()
    {
        // Reading the input paragraph and then splitting it on.

        string [] sentences = Console.ReadLine().Split('.');

        for(int i = 0; i < sentences.Length -1; i++)

        {
            Console.WriteLine(FormatSentence(sentences[i]));
        }

    }  // method for formatting a string
          static string FormatSentence (string s)
    {   
        // removing extra spaces 
        s = s.Trim();

        string formmated = "";

        if(s[0] >= 'a' && s[0] <= 'z')
        {
            formmated += (char)(s[0] - 32);
        }
         else
        {
            formmated += s[0];
        }
         for(int i = 1; i < s.Length; i++)
        {
            if(s[i] == ',' || s[i] == ';')
            {
                formmated += s[i] + " ";

                //converting the first char lowercase to upper

            } else if (s[i] >= 'A' && s[i] <= 'Z')
            {
                formmated += (char)(s[i] + 32);
            }
            // skipping continuing spaces

             else if(s[i] == ' ' && s[i-1] == ' ')
            {
                continue;
            }
            else
            {
                formmated += s[i];
            }
        }
        return formmated + '.';
    }
}