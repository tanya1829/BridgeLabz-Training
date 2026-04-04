using System;

//  Interface for Loan Facility 
interface ILoanable
{
    void RequestLoan(double loanAmount);
    double GetLoanLimit();
}

// Abstract Bank Account 
abstract class BankAccount
{
    private string accNo;
    private string customerName;
    private double totalBalance;

    public void SetAccNo(string number)
    {
        accNo = number;
    }

    public string GetAccNo()
    {
        return accNo;
    }

    public void SetCustomerName(string name)
    {
        customerName = name;
    }

    public string GetCustomerName()
    {
        return customerName;
    }

    public void SetTotalBalance(double amount)
    {
        totalBalance = amount;
    }

    public double GetTotalBalance()
    {
        return totalBalance;
    }

    public void AddMoney(double amount)
    {
        totalBalance += amount;
    }

    public void RemoveMoney(double amount)
    {
        totalBalance -= amount;
    }

    public void ShowAccountDetails()
    {
        Console.WriteLine("Account Number: " + accNo);
        Console.WriteLine("Account Holder: " + customerName);
        Console.WriteLine("Balance: " + totalBalance);
    }

    public abstract double CalculateInterestAmount();
}

// Savings Account 
class SavingsAccount : BankAccount, ILoanable
{
    public override double CalculateInterestAmount()
    {
        return GetTotalBalance() * 0.04; // 4% interest
    }

    public void RequestLoan(double loanAmount)
    {
        Console.WriteLine("Loan requested: " + loanAmount);
    }

    public double GetLoanLimit()
    {
        return GetTotalBalance() * 2;
    }
}

// Current Account 
class CurrentAccount : BankAccount, ILoanable
{
    public override double CalculateInterestAmount()
    {
        return GetTotalBalance() * 0.01; // 1% interest
    }

    public void RequestLoan(double loanAmount)
    {
        Console.WriteLine("Loan requested: " + loanAmount);
    }

    public double GetLoanLimit()
    {
        return GetTotalBalance();
    }
}

// Main Program
class ProgramBank
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount();
        savings.SetAccNo("SA101");
        savings.SetCustomerName("Rahul");
        savings.SetTotalBalance(50000);

        CurrentAccount current = new CurrentAccount();
        current.SetAccNo("CA101");
        current.SetCustomerName("Anita");
        current.SetTotalBalance(30000);

        Console.WriteLine("---- Savings Account ----");
        savings.ShowAccountDetails();
        Console.WriteLine("Interest: " + savings.CalculateInterestAmount());
        Console.WriteLine("Loan Eligibility: " + savings.GetLoanLimit());

        Console.WriteLine();

        Console.WriteLine("---- Current Account ----");
        current.ShowAccountDetails();
        Console.WriteLine("Interest: " + current.CalculateInterestAmount());
        Console.WriteLine("Loan Eligibility: " + current.GetLoanLimit());
    }
}
