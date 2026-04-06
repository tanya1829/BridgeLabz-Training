using System;
using System.Collections.Generic;

class Policy : IComparable<Policy>
{
    public string PolicyNumber { get; set; }
    public string CoverageType { get; set; }
    public DateTime ExpiryDate { get; set; }

    public int CompareTo(Policy other)
    {
        return this.ExpiryDate.CompareTo(other.ExpiryDate);
    }

    public override string ToString()
    {
        return $"{PolicyNumber} ({CoverageType}) Expiry: {ExpiryDate.ToShortDateString()}";
    }
}

class InsuranceSystem
{
    static void Main()
    {
        HashSet<string> policyNumbers = new HashSet<string>();
        List<string> insertionOrder = new List<string>();
        SortedSet<Policy> sortedPolicies = new SortedSet<Policy>();

        AddPolicy("P101", "Health", DateTime.Now.AddDays(20));
        AddPolicy("P102", "Life", DateTime.Now.AddDays(40));
        AddPolicy("P103", "Health", DateTime.Now.AddDays(10));
        AddPolicy("P101", "Health", DateTime.Now.AddDays(20)); // duplicate

        Console.WriteLine("All Unique Policies:");
        foreach (var p in insertionOrder)
            Console.WriteLine(p);

        Console.WriteLine("\nPolicies Expiring in 30 Days:");
        foreach (var p in sortedPolicies)
            if ((p.ExpiryDate - DateTime.Now).Days <= 30)
                Console.WriteLine(p.PolicyNumber);

        void AddPolicy(string num, string type, DateTime expiry)
        {
            if (policyNumbers.Add(num))
            {
                insertionOrder.Add(num);
                sortedPolicies.Add(new Policy
                {
                    PolicyNumber = num,
                    CoverageType = type,
                    ExpiryDate = expiry
                });
            }
        }
    }
}
