using System;

// Interface for GPS
interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string location);
}

// Abstract Vehicle class
abstract class Vehicle
{
    private string vehicleId;
    private string driverName;
    private double ratePerKm;
    private string location;

    public void SetVehicleId(string id) { vehicleId = id; }
    public string GetVehicleId() { return vehicleId; }

    public void SetDriverName(string name) { driverName = name; }
    public string GetDriverName() { return driverName; }

    public void SetRatePerKm(double rate) { ratePerKm = rate; }
    public double GetRatePerKm() { return ratePerKm; }

    public void SetLocation(string loc) { location = loc; }
    public string GetLocation() { return location; }

    public void GetVehicleDetails()
    {
        Console.WriteLine("Vehicle ID: " + GetVehicleId());
        Console.WriteLine("Driver Name: " + GetDriverName());
        Console.WriteLine("Rate per Km: " + GetRatePerKm());
        Console.WriteLine("Current Location: " + GetLocation());
    }

    public abstract double CalculateFare(double distance);
}

// Car class
class Car : Vehicle, IGPS
{
    public override double CalculateFare(double distance)
    {
        return distance * GetRatePerKm();
    }

    public string GetCurrentLocation() { return GetLocation(); }
    public void UpdateLocation(string loc) { SetLocation(loc); }

    public void Display()
    {
        GetVehicleDetails();
        Console.WriteLine("Fare for 10 km: " + CalculateFare(10));
    }
}

// Bike class
class Bike : Vehicle, IGPS
{
    public override double CalculateFare(double distance)
    {
        return distance * GetRatePerKm();
    }

    public string GetCurrentLocation() { return GetLocation(); }
    public void UpdateLocation(string loc) { SetLocation(loc); }

    public void Display()
    {
        GetVehicleDetails();
        Console.WriteLine("Fare for 5 km: " + CalculateFare(5));
    }
}

// Auto class
class Auto : Vehicle, IGPS
{
    public override double CalculateFare(double distance)
    {
        return distance * GetRatePerKm();
    }

    public string GetCurrentLocation() { return GetLocation(); }
    public void UpdateLocation(string loc) { SetLocation(loc); }

    public void Display()
    {
        GetVehicleDetails();
        Console.WriteLine("Fare for 3 km: " + CalculateFare(3));
    }
}

// Main Program
class ProgramRide
{
    static void Main()
    {
        Car car = new Car();
        car.SetVehicleId("C101");
        car.SetDriverName("Rahul");
        car.SetRatePerKm(15);
        car.SetLocation("City Center");

        Bike bike = new Bike();
        bike.SetVehicleId("B101");
        bike.SetDriverName("Anita");
        bike.SetRatePerKm(10);
        bike.SetLocation("City Center");

        Auto auto = new Auto();
        auto.SetVehicleId("A101");
        auto.SetDriverName("Zainab");
        auto.SetRatePerKm(8);
        auto.SetLocation("City Center");

        Console.WriteLine("Car Details:");
        car.Display();
        Console.WriteLine();

        Console.WriteLine("Bike Details:");
        bike.Display();
        Console.WriteLine();

        Console.WriteLine("Auto Details:");
        auto.Display();
    }
}