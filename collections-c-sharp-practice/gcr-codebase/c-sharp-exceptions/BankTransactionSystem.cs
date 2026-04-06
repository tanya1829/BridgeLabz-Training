using System;
using System.Collections.Generic;
using System.Text;
       
        // Custom exception for insufficient balance
        class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string message) : base(message)
            {
            }
        }

        class BankAccount
        {
            private double balance;

            // Constructor to set initial balance
            public BankAccount(double initialBalance)
            {
                balance = initialBalance;
            }

            // Withdraw method
            public void Withdraw(double amount)
            {
                // Check for negative amount
                if (amount < 0)
                {
                    throw new ArgumentException("Invalid amount!");
                }

                // Check for insufficient balance
                if (amount > balance)
                {
                    throw new InsufficientFundsException("Insufficient balance!");
                }

                // Perform withdrawal
                balance -= amount;
                Console.WriteLine("Withdrawal successful, new balance: " + balance);
            }
        }

        internal class BankTransactionSystem
        {
           public static void Main(string[] args)
            {
                try
                {
                    // Create bank account with initial balance
                    BankAccount account = new BankAccount(5000);

                    // Ask user for withdrawal amount
                    Console.Write("Enter withdrawal amount: ");
                    double amount = double.Parse(Console.ReadLine());

                    // Attempt withdrawal
                    account.Withdraw(amount);
                }
                catch (InsufficientFundsException ex)
                {
                    // Handle insufficient balance
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    // Handle negative amount
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    // Handle invalid input
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    