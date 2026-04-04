// Question:
// Create a BankAccount class using static, readonly, this keyword and is operator.

using System;

class BankAccountStatic
{
    // Static variable shared by all accounts
    public static string bankName = "SBI";

    // Readonly variable cannot be changed after initialization
    public readonly int accountNumber;

    public string holderName;

    // Constructor using this keyword
    public BankAccount(int accountNumber, string holderName)
    {
        this.accountNumber = accountNumber;
        this.holderName = holderName;
    }

    static void Main()
    {
        BankAccount acc = new BankAccount(101, "Ana");

        // Using is operator for safe type checking
        if (acc is BankAccount)
        {
            Console.WriteLine(acc.holderName);
        }
    }
}