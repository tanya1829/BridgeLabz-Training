using System;

// -------- Interface --------
interface IRentable
{
    double GetRentAmount(int totalDays);
}

// -------- Base Vehicle Class --------
class Vehicle
{
    private int id;
    private string name;
    private double pricePerDay;

    public void SetId(int vid)
    {
        id = vid;
    }

    public void SetName(string vname)
    {
        name = vname;
    }

    public void SetPricePerDay(double price)
    {
        pricePerDay = price;
    }

    public int GetId()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public double GetPricePerDay()
    {
        return pricePerDay;
    }

    public void ShowVehicle()
    {
        Console.WriteLine("Vehicle ID: " + id);
        Console.WriteLine("Vehicle Name: " + name);
    }
}

// -------- Bike --------
class Bike : Vehicle, IRentable
{
    public double GetRentAmount(int totalDays)
    {
        return totalDays * GetPricePerDay();
    }

    public void ShowVehicle()
    {
        base.ShowVehicle();
        Console.WriteLine("Vehicle Category: Bike");
    }
}

// -------- Car --------
class Car : Vehicle, IRentable
{
    public double GetRentAmount(int totalDays)
    {
        return totalDays * GetPricePerDay();
    }

    public void ShowVehicle()
    {
        base.ShowVehicle();
        Console.WriteLine("Vehicle Category: Car");
    }
}

// -------- Truck --------
class Truck : Vehicle, IRentable
{
    public double GetRentAmount(int totalDays)
    {
        return totalDays * GetPricePerDay();
    }

    public void ShowVehicle()
    {
        base.ShowVehicle();
        Console.WriteLine("Vehicle Category: Truck");
    }
}

// -------- Customer --------
class Customer
{
    private int custId;
    private string custName;

    public void SetCustId(int id)
    {
        custId = id;
    }

    public void SetCustName(string name)
    {
        custName = name;
    }

    public void ShowCustomer()
    {
        Console.WriteLine("Customer ID: " + custId);
        Console.WriteLine("Customer Name: " + custName);
    }
}

// -------- Main Program --------
class Program
{
    static void Main()
    {
        Bike bike = new Bike();
        bike.SetId(1);
        bike.SetName("Honda Bike");
        bike.SetPricePerDay(300);

        Car car = new Car();
        car.SetId(2);
        car.SetName("Maruti Car");
        car.SetPricePerDay(1000);

        Truck truck = new Truck();
        truck.SetId(3);
        truck.SetName("Tata Truck");
        truck.SetPricePerDay(2000);

        Customer customer = new Customer();
        customer.SetCustId(101);
        customer.SetCustName("Zainab");

        Console.WriteLine("---- Customer Details ----");
        customer.ShowCustomer();

        Console.WriteLine("\n---- Bike Details ----");
        bike.ShowVehicle();
        Console.WriteLine("Rent for 3 days: " + bike.GetRentAmount(3));

        Console.WriteLine("\n---- Car Details ----");
        car.ShowVehicle();
        Console.WriteLine("Rent for 2 days: " + car.GetRentAmount(2));

        Console.WriteLine("\n---- Truck Details ----");
        truck.ShowVehicle();
        Console.WriteLine("Rent for 1 day: " + truck.GetRentAmount(1));
    }
}
