using System;
using System.Collections.Generic;

class ShoppingCart
{
    static void Main()
    {
        Dictionary<string, double> cart = new Dictionary<string, double>();
        List<string> order = new List<string>(); // maintains insertion order

        AddItem("Laptop", 75000);
        AddItem("Mouse", 500);
        AddItem("Keyboard", 1500);

        Console.WriteLine("Cart (Insertion Order):");
        foreach (var item in order)
            Console.WriteLine(item + " : " + cart[item]);

        Console.WriteLine("\nCart Sorted by Price:");
        SortedDictionary<double, string> sorted = new SortedDictionary<double, string>();
        foreach (var item in cart)
            sorted[item.Value] = item.Key;

        foreach (var item in sorted)
            Console.WriteLine(item.Value + " : " + item.Key);

        void AddItem(string name, double price)
        {
            cart[name] = price;
            order.Add(name);
        }
    }
}
