using System;

class NumberGuessingGame
{
    static void Main()
    {
        int low = 1, high = 100;
        bool correct = false;

        Console.WriteLine("Think of a number between 1 and 100");

        while (!correct)
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Is your number " + guess + "? (high/low/correct)");
            string feedback = Console.ReadLine();

            if (feedback == "correct")
                correct = true;
            else if (feedback == "high")
                high = guess - 1;
            else if (feedback == "low")
                low = guess + 1;
        }
    }

    static int GenerateGuess(int low, int high)
    {
        return (low + high) / 2;
    }
}
