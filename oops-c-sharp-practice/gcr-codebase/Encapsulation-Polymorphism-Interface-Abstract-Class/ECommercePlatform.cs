using System;

//  Interface for Taxable Items 
interface ITaxable
{
    double GetTaxAmount();
    string ShowTaxInfo();
}

// Abstract Product
abstract class Product
{
    private int id;
    private string productName;
    private double basePrice;

    public void SetId(int pid) { id = pid; }
    public int GetId() { return id; }

    public void SetProductName(string name) { productName = name; }
    public string GetProductName() { return productName; }

    public void SetBasePrice(double price) { basePrice = price; }
    public double GetBasePrice() { return basePrice; }

    // Abstract method for discount
    public abstract double GetDiscountAmount();

    // Virtual display method
    public virtual void ShowProduct()
    {
        Console.WriteLine("Product ID: " + id);
        Console.WriteLine("Product Name: " + productName);
        Console.WriteLine("Price: " + basePrice);
        Console.WriteLine("Discount: " + GetDiscountAmount());
    }
}

// Electronics
class Electronics : Product, ITaxable
{
    public override double GetDiscountAmount()
    {
        return GetBasePrice() * 0.10; // 10% discount
    }

    public double GetTaxAmount()
    {
        return GetBasePrice() * 0.18; // 18% GST
    }

    public string ShowTaxInfo()
    {
        return "GST @18%";
    }

    public override void ShowProduct()
    {
        base.ShowProduct();
        Console.WriteLine("Tax: " + GetTaxAmount() + " (" + ShowTaxInfo() + ")");
        Console.WriteLine("Final Price: " + (GetBasePrice() + GetTaxAmount() - GetDiscountAmount()));
    }
}

// Clothing 
class Clothing : Product, ITaxable
{
    public override double GetDiscountAmount()
    {
        return GetBasePrice() * 0.05; // 5% discount
    }

    public double GetTaxAmount()
    {
        return GetBasePrice() * 0.12; // 12% GST
    }

    public string ShowTaxInfo()
    {
        return "GST @12%";
    }

    public override void ShowProduct()
    {
        base.ShowProduct();
        Console.WriteLine("Tax: " + GetTaxAmount() + " (" + ShowTaxInfo() + ")");
        Console.WriteLine("Final Price: " + (GetBasePrice() + GetTaxAmount() - GetDiscountAmount()));
    }
}

// Groceries
class Groceries : Product
{
    public override double GetDiscountAmount()
    {
        return 0; // no discount
    }

    public override void ShowProduct()
    {
        base.ShowProduct();
        Console.WriteLine("Final Price: " + GetBasePrice());
    }
}

//  Main Program 
class Program
{
    static void Main()
    {
        Electronics elec = new Electronics();
        elec.SetId(1);
        elec.SetProductName("Laptop");
        elec.SetBasePrice(50000);

        Clothing cloth = new Clothing();
        cloth.SetId(2);
        cloth.SetProductName("T-Shirt");
        cloth.SetBasePrice(1000);

        Groceries grocery = new Groceries();
        grocery.SetId(3);
        grocery.SetProductName("Rice");
        grocery.SetBasePrice(200);

        Console.WriteLine("---- Electronics ----");
        elec.ShowProduct();

        Console.WriteLine("\n---- Clothing ----");
        cloth.ShowProduct();

        Console.WriteLine("\n---- Grocery ----");
        grocery.ShowProduct();
    }
}
