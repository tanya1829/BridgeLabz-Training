using System;

// Interface for insurable vehicles
interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

// Abstract Vehicle class
abstract class Vehicle
{
    private string vehicleNumber;
    private string type;
    private double rentalRate;

    public void SetVehicleNumber(string num) { vehicleNumber = num; }
    public string GetVehicleNumber() { return vehicleNumber; }

    public void SetType(string t) { type = t; }
    public string GetType() { return type; }

    public void SetRentalRate(double rate) { rentalRate = rate; }
    public double GetRentalRate() { return rentalRate; }

    public abstract double CalculateRentalCost(int days);

    public virtual void Display()
    {
        Console.WriteLine("Vehicle Number: " + GetVehicleNumber());
        Console.WriteLine("Type: " + GetType());
        Console.WriteLine("Rental Rate: " + GetRentalRate());
    }
}

// Car class
class Car : Vehicle, IInsurable
{
    public override double CalculateRentalCost(int days)
    {
        return GetRentalRate() * days;
    }

    public double CalculateInsurance()
    {
        return 0.05 * GetRentalRate();
    }

    public string GetInsuranceDetails()
    {
        return "Car Insurance 5% of rental rate";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Rental Cost for 3 days: " + CalculateRentalCost(3));
        Console.WriteLine("Insurance: " + CalculateInsurance() + " (" + GetInsuranceDetails() + ")");
    }
}

// Bike class
class Bike : Vehicle, IInsurable
{
    public override double CalculateRentalCost(int days)
    {
        return GetRentalRate() * days;
    }

    public double CalculateInsurance()
    {
        return 0.02 * GetRentalRate();
    }

    public string GetInsuranceDetails()
    {
        return "Bike Insurance 2% of rental rate";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Rental Cost for 3 days: " + CalculateRentalCost(3));
        Console.WriteLine("Insurance: " + CalculateInsurance() + " (" + GetInsuranceDetails() + ")");
    }
}

// Truck class
class Truck : Vehicle, IInsurable
{
    public override double CalculateRentalCost(int days)
    {
        return GetRentalRate() * days;
    }

    public double CalculateInsurance()
    {
        return 0.08 * GetRentalRate();
    }

    public string GetInsuranceDetails()
    {
        return "Truck Insurance 8% of rental rate";
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Rental Cost for 3 days: " + CalculateRentalCost(3));
        Console.WriteLine("Insurance: " + CalculateInsurance() + " (" + GetInsuranceDetails() + ")");
    }
}

// Main program
class ProgramVehicle
{
    static void Main()
    {
        Car car = new Car();
        car.SetVehicleNumber("C101");
        car.SetType("Sedan");
        car.SetRentalRate(2000);

        Bike bike = new Bike();
        bike.SetVehicleNumber("B101");
        bike.SetType("Sport");
        bike.SetRentalRate(500);

        Truck truck = new Truck();
        truck.SetVehicleNumber("T101");
        truck.SetType("Mini Truck");
        truck.SetRentalRate(5000);

        Console.WriteLine("Car Details:");
        car.Display();
        Console.WriteLine();

        Console.WriteLine("Bike Details:");
        bike.Display();
        Console.WriteLine();

        Console.WriteLine("Truck Details:");
        truck.Display();
        Console.WriteLine();
    }
}