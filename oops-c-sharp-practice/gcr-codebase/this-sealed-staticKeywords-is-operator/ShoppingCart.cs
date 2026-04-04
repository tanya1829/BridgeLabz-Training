// Question:
// Create a Product class for a Shopping Cart System
// using static, this, readonly and is operator.

using System;

class ShoppingCart
{
    // Static discount shared by all products
    public static double Discount = 10;

    // Readonly product ID
    public readonly int ProductID;
    public string ProductName;
    public double Price;
    public int Quantity;

    // Constructor using this keyword
    public Product(int ProductID, string ProductName, double Price, int Quantity)
    {
        this.ProductID = ProductID;
        this.ProductName = ProductName;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    // Static method to update discount
    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    static void Main()
    {
        Product p = new Product(101, "Laptop", 50000, 1);

        if (p is Product)
        {
            Console.WriteLine(p.ProductName + " Price: " + p.Price);
        }

        UpdateDiscount(15);
    }
}