using System;

class SnackCorner
{
    static string[] menuItems = {
        "Chocolate Muffin",
        "Veg Wrap",
        "Paneer Sandwich",
        "Sweet Corn",
        "Masala Idli",
        "Veg Pulao",
        "Chicken Nuggets",
        "Milkshake",
        "Lemonade",
        "Herbal Tea"
    };

    static int[] menuPrices = { 45, 55, 70, 60, 90, 80, 120, 130, 35, 25 };

    static void Main()
    {
        Console.WriteLine("=== WELCOME TO SNACK CORNER ===");
        bool exitFlag = false;

        while (!exitFlag)
        {
            Console.WriteLine("\nENTER YOUR CHOICE:");
            Console.WriteLine("1. VIEW MENU");
            Console.WriteLine("2. PLACE ORDER");
            Console.WriteLine("3. EXIT");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Enter a number (1-3).");
                continue;
            }

            if (choice == 1)
            {
                DisplayMenu();
            }
            else if (choice == 2)
            {
                TakeOrder();
            }
            else if (choice == 3)
            {
                exitFlag = true;
                Console.WriteLine("THANK YOU! VISIT AGAIN.");
            }
            else
            {
                Console.WriteLine("Please enter a valid choice (1-3).");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- MENU ---");
        for (int i = 0; i < menuItems.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + menuItems[i] + " --> ₹" + menuPrices[i]);
        }
    }

    static void TakeOrder()
    {
        Console.WriteLine("Enter item numbers to order (space separated):");
        string input = Console.ReadLine();
        string[] selectedItems = input.Split(' ');

        int total = 0;
        string orderSummary = "";

        for (int i = 0; i < selectedItems.Length; i++)
        {
            int index;
            if (int.TryParse(selectedItems[i], out index))
            {
                index -= 1; // array index
                if (index >= 0 && index < menuItems.Length)
                {
                    Console.WriteLine("Add " + menuItems[index] + " for ₹" + menuPrices[index] + "? (y/n)");
                    string confirm = Console.ReadLine();
                    if (confirm.ToLower() == "y")
                    {
                        total += menuPrices[index];
                        orderSummary += menuItems[index] + " ";
                    }
                }
                else
                {
                    Console.WriteLine("Item " + selectedItems[i] + " is invalid and skipped.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input: " + selectedItems[i]);
            }
        }

        if (total == 0)
        {
            Console.WriteLine("No items selected. Order cancelled.");
            return;
        }

        Console.WriteLine("TOTAL AMOUNT: ₹" + total);
        Console.WriteLine("Enter payment amount:");

        int payment;
        if (!int.TryParse(Console.ReadLine(), out payment))
        {
            Console.WriteLine("Invalid payment. Order cancelled.");
            return;
        }

        if (payment >= total)
        {
            Console.WriteLine("Your order: " + orderSummary + "has been placed successfully!");
            if (payment > total)
            {
                Console.WriteLine("Your change: ₹" + (payment - total));
            }
        }
        else
        {
            Console.WriteLine("Insufficient payment. Order declined.");
        }
    }
}