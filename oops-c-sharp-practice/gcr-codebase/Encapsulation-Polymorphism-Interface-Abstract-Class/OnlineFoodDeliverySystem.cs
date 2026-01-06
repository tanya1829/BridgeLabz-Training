using System;

//  Interface for Discount Feature
interface IDiscountable
{
    void SetDiscount(double percentage);
    string ShowDiscountInfo();
}

//  Abstract Food Item 
abstract class FoodItem
{
    private string foodName;
    private double unitPrice;
    private int itemCount;

    public void SetFoodName(string name) { foodName = name; }
    public string GetFoodName() { return foodName; }

    public void SetUnitPrice(double price) { unitPrice = price; }
    public double GetUnitPrice() { return unitPrice; }

    public void SetItemCount(int count) { itemCount = count; }
    public int GetItemCount() { return itemCount; }

    public void ShowItemDetails()
    {
        Console.WriteLine("Item Name: " + foodName);
        Console.WriteLine("Price per Item: " + unitPrice);
        Console.WriteLine("Quantity: " + itemCount);
    }

    public abstract double GetTotalAmount();
}

//  Veg Item 
class VegItem : FoodItem, IDiscountable
{
    private double discountAmount = 0;

    public override double GetTotalAmount()
    {
        return (GetUnitPrice() * GetItemCount()) - discountAmount;
    }

    public void SetDiscount(double percentage)
    {
        discountAmount = (GetUnitPrice() * GetItemCount()) * percentage / 100;
    }

    public string ShowDiscountInfo()
    {
        return "Veg Discount Applied: " + discountAmount;
    }

    public void ShowVegItem()
    {
        ShowItemDetails();
        Console.WriteLine("Total Price: " + GetTotalAmount());
        Console.WriteLine(ShowDiscountInfo());
    }
}

//  Non-Veg Item
class NonVegItem : FoodItem, IDiscountable
{
    private double serviceCharge = 50;
    private double discountAmount = 0;

    public override double GetTotalAmount()
    {
        return (GetUnitPrice() * GetItemCount()) + serviceCharge - discountAmount;
    }

    public void SetDiscount(double percentage)
    {
        discountAmount = ((GetUnitPrice() * GetItemCount()) + serviceCharge) * percentage / 100;
    }

    public string ShowDiscountInfo()
    {
        return "Non-Veg Discount Applied: " + discountAmount;
    }

    public void ShowNonVegItem()
    {
        ShowItemDetails();
        Console.WriteLine("Extra Charge: " + serviceCharge);
        Console.WriteLine("Total Price: " + GetTotalAmount());
        Console.WriteLine(ShowDiscountInfo());
    }
}

//Main Program 
class ProgramFood
{
    static void Main()
    {
        VegItem vegFood = new VegItem();
        vegFood.SetFoodName("Paneer Butter Masala");
        vegFood.SetUnitPrice(200);
        vegFood.SetItemCount(2);
        vegFood.SetDiscount(10);

        Console.WriteLine("---- Veg Item ----");
        vegFood.ShowVegItem();
        Console.WriteLine();

        NonVegItem nonVegFood = new NonVegItem();
        nonVegFood.SetFoodName("Chicken Curry");
        nonVegFood.SetUnitPrice(250);
        nonVegFood.SetItemCount(1);
        nonVegFood.SetDiscount(5);

        Console.WriteLine("---- Non-Veg Item ----");
        nonVegFood.ShowNonVegItem();
    }
}
