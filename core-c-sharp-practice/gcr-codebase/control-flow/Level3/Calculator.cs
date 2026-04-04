using System;

class Calculator
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double first = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double second = double.Parse(Console.ReadLine());

        Console.Write("Enter operator (+, -, *, /): ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "+":
                Console.WriteLine("Result = " + (first + second));
                break;

            case "-":
                Console.WriteLine("Result = " + (first - second));
                break;

            case "*":
                Console.WriteLine("Result = " + (first * second));
                break;

            case "/":
                Console.WriteLine("Result = " + (first / second));
                break;

            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
