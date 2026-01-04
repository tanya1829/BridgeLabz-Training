// Question:
// Create a BankAccount class using static, this, readonly and is operator.
// Demonstrate best programming practices in C#.

using System;

class BankAccountSystem
{
    // Static variable shared by all accounts
    public static string bankName = "SBI";
    private static int totalAccounts = 0;

    // Readonly account number (cannot be changed)
    public readonly int AccountNumber;
    public string AccountHolderName;

    // Constructor using this keyword
    public BankAccount(int AccountNumber, string AccountHolderName)
    {
        this.AccountNumber = AccountNumber;
        this.AccountHolderName = AccountHolderName;
        totalAccounts++;
    }

    // Static method to show total accounts
    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    static void Main()
    {
        BankAccount acc = new BankAccount(101, "Ana");

        // Using is operator for type checking
        if (acc is BankAccount)
        {
            Console.WriteLine("Account Holder: " + acc.AccountHolderName);
        }

        GetTotalAccounts();
    }
}