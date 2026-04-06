using System;
using System.Collections.Generic;

class BankingSystem
{
    static void Main()
    {
        Dictionary<int, double> accounts = new Dictionary<int, double>();
        Queue<int> withdrawalQueue = new Queue<int>();

        accounts[101] = 5000;
        accounts[102] = 2000;
        accounts[103] = 8000;

        withdrawalQueue.Enqueue(102);
        withdrawalQueue.Enqueue(101);

        Console.WriteLine("Withdrawal Processing:");
        while (withdrawalQueue.Count > 0)
        {
            int acc = withdrawalQueue.Dequeue();
            accounts[acc] -= 500;
            Console.WriteLine("Account " + acc + " New Balance: " + accounts[acc]);
        }

        Console.WriteLine("\nAccounts Sorted by Balance:");
        SortedDictionary<double, int> sorted = new SortedDictionary<double, int>();
        foreach (var acc in accounts)
            sorted[acc.Value] = acc.Key;

        foreach (var acc in sorted)
            Console.WriteLine("Account " + acc.Value + " : " + acc.Key);
    }
}
