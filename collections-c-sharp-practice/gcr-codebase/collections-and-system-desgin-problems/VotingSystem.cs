using System;
using System.Collections.Generic;

class VotingSystem
{
    static void Main()
    {
        Dictionary<string, int> votes = new Dictionary<string, int>();
        List<string> voteOrder = new List<string>(); // maintains order

        Vote("Alice");
        Vote("Bob");
        Vote("Alice");
        Vote("Charlie");

        Console.WriteLine("Vote Order:");
        foreach (var v in voteOrder)
            Console.WriteLine(v);

        Console.WriteLine("\nSorted Results:");
        SortedDictionary<string, int> sorted = new SortedDictionary<string, int>(votes);
        foreach (var v in sorted)
            Console.WriteLine(v.Key + " : " + v.Value);

        void Vote(string name)
        {
            voteOrder.Add(name);
            if (votes.ContainsKey(name))
                votes[name]++;
            else
                votes[name] = 1;
        }
    }
}
