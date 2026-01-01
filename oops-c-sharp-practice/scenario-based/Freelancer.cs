using System;

class Freelancer
{
    static void Main()
    {
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("---- INVOICE GENERATOR ----");
            Console.WriteLine("1. Generate Invoice");
            Console.WriteLine("2. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                GenerateInvoice();
            else if (choice == 2)
                Console.WriteLine("Exiting...");
            else
                Console.WriteLine("Invalid choice!");

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();

        } while (choice != 2);
    }

    static void GenerateInvoice()
    {
        Console.WriteLine("\nEnter invoice details:");
        Console.WriteLine("Example: Logo Design - 3000 INR, Web Page - 4500 INR");
        string input = Console.ReadLine();

        string[] tasks = ParseInvoice(input);
        int totalAmount = GetTotalAmount(tasks);

        Console.WriteLine("\nTotal Invoice Amount: " + totalAmount + " INR");
    }

    // Splits invoice into tasks
    static string[] ParseInvoice(string input)
    {
        return input.Split(", ");
    }

    // Calculates total amount safely
    static int GetTotalAmount(string[] tasks)
    {
        int sum = 0;

        foreach (string task in tasks)
        {
            string[] parts = task.Split('-');

            // Validation to avoid crash
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid task format: " + task);
                continue;
            }

            string amountPart = parts[1].Trim();   // "3000 INR"
            string[] amountTokens = amountPart.Split(' ');

            int amount = int.Parse(amountTokens[0]);
            sum += amount;
        }

        return sum;
    }
}
