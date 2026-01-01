/*Methods – Bank Account Manager
1. Scenario: A banking app needs to perform operations like deposit, withdraw, and check balance for a user.
● Problem: Design a BankAccount class with:
● Fields/Properties: AccountNumber, Balance.
● Methods: Deposit(double), Withdraw(double), CheckBalance().
● Include logic to prevent overdraft.*/

using System;
class Bank{
    static void Main()
    {
        Client client=new Client(1234567890,100);
        Console.WriteLine(client.check());
        client.withdrawl(50);
        Console.WriteLine(client.check());
        client.deposit(89);
        Console.WriteLine(client.check());
    }
}
public class BankAccount
{
   protected int AccountNumber;
   private double balance;
   //getter
   protected double getValue(){
    return balance;
   }
   //setter
   protected void setValue(double amount){
    balance=amount;
   }
}

class Client : BankAccount
{
    //constructor
    public Client(int accountNumber, double openingbalance){
        AccountNumber = accountNumber;
        setValue(openingbalance);
    }

    public double check()
    {
        return getValue();
    }

    public void deposit(double depositamount){
        setValue(getValue()+depositamount);
    }
    public void withdrawl(double withdrawlamount)
    {
        setValue(getValue()-withdrawlamount);
    }
    
}
