using System;

class BasicCalculator
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int first = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int second = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose operation (+ - * /):");
        char ab = Console.ReadLine()[0];

        switch (ab)
        {
            case '+': Console.WriteLine(Add(first, second)); break;
            case '-': Console.WriteLine(Sub(first, second)); break;
            case '*': Console.WriteLine(Mul(first, second)); break;
            case '/': Console.WriteLine(Div(first, second)); break;
        }
    }

    static int Add(int x, int y) => x + y;
    static int Sub(int x, int y) => x - y;
    static int Mul(int x, int y) => x * y;
    static int Div(int x, int y) => x / y;
}
