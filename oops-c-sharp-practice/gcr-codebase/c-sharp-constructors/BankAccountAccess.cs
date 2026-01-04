// Question:
// Create a BankAccount class with accountNumber as public,
// accountHolder as protected, and balance as private.
// Implement public methods to access and modify balance.
// Create a subclass SavingsAccount to demonstrate access.

using System;

class BankAccountAccess
{
    // Public member
    public int accountNumber;

    // Protected member
    protected string accountHolder;

    // Private member
    private double balance;

    // Public method to set balance
    public void SetBalance(double amount)
    {
        balance = amount;
    }

    // Public method to get balance
    public double GetBalance()
    {
        return balance;
    }
}

// Subclass demonstrating protected access
class SavingsAccount : BankAccount
{
    public void DisplayAccountInfo()
    {
        accountNumber = 12345;
        accountHolder = "Ana";

        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Account Holder: " + accountHolder);
    }

    static void Main()
    {
        SavingsAccount sa = new SavingsAccount();
        sa.SetBalance(5000);

        sa.DisplayAccountInfo();
        Console.WriteLine("Balance: " + sa.GetBalance());
    }
}