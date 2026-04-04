// Question:
// Create a Product class with instance variables productName and price.
// Create a class variable totalProducts shared among all products.
// Implement an instance method to display product details
// and a class method to display total number of products.

using System;

class ProductInventory
{
    // Instance variables (unique for each product)
    public string productName;
    public double price;

    // Class variable (shared by all objects)
    public static int totalProducts = 0;

    // Constructor to initialize product and count total products
    public Product(string name, double price)
    {
        productName = name;
        this.price = price;
        totalProducts++; // increases whenever a new product is created
    }

    // Instance method to display product details
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name: " + productName);
        Console.WriteLine("Price: " + price);
    }

    // Class method to display total number of products
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: " + totalProducts);
    }

    static void Main()
    {
        // Creating product objects
        Product p1 = new Product("Pen", 10);
        Product p2 = new Product("Notebook", 50);

        // Displaying product details
        p1.DisplayProductDetails();
        p2.DisplayProductDetails();

        // Displaying total product count
        Product.DisplayTotalProducts();
    }
}