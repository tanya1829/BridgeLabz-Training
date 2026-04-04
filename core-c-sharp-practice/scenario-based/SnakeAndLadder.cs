using System;

class SnakeAndLadder

{
    public static int RollDice()
    {

        Random random = new Random();
        int value = random.Next(1, 7);
        return value;
    }

    public static int LadderMove(int position)

    {
        switch (position)

        {
            case 11: return 56;
            case 17: return (43 - 17);
            
            case 31: return (51 - 31);
            case 68: return (87 - 68);
            case 75: return (95 - 75);
            default: return 0;
        }
    }

    public static int SnakeMove(int position)
    {
        switch (position)
        {
            case 99: return 8;
            case 97: return (97 - 84);
            case 95: return (95 - 71);
            case 76: return (76 - 28);
            case 38: return (38 - 7);
            default: return 0;
        }
    }

    public static void Main()
    {
        Console.WriteLine("enter number of players");
        int playerCount = int.Parse(Console.ReadLine());

        int[] positions = new int[playerCount];
        int gameOver = 0;

        while (gameOver == 0)
        {
            for (int i = 0; i < playerCount; i++)
            {
                int diceValue = RollDice();

                Console.WriteLine();
                Console.WriteLine("player " + (i + 1) + " turn");
                Console.ReadLine();
                Console.WriteLine("dice value = " + diceValue);

                if ((positions[i] + diceValue) <= 100)
                    positions[i] += diceValue;

                if (positions[i] == 100)
                {
                    Console.WriteLine("player " + (i + 1) + " wins");
                    gameOver = 1;
                    break;
                }

                switch (positions[i])
                {
                    // snake
                    case 99:
                    case 96:
                    case 94:
                    case 77:
                    case 37:
                        Console.WriteLine();
                        Console.WriteLine("snake bit");

                        int snakeDrop = SnakeMove(positions[i]);
                        positions[i] = positions[i] - snakeDrop;
                        break;

                    // ladder
                    case 11:
                    case 17:
                    case 31:
                    case 68:
                    case 75:
                        Console.WriteLine();
                        Console.WriteLine("ladder reached");
                        Console.WriteLine();

                        int ladderJump = LadderMove(positions[i]);
                        positions[i] = positions[i] + ladderJump;
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("player " + (i + 1) + " score is " + positions[i]);
            }

            if (gameOver == 1)
                break;
        }
    }
}