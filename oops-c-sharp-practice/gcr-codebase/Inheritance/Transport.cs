using System;

class Transport
{
    protected int speedLimit = 40;
    protected string fuel = "Diesel";

    public virtual void ShowDetails()
    {
        Console.WriteLine("Speed Limit: " + speedLimit + " km/hr, Fuel: " + fuel);
    }
}

class CarTransport : Transport
{
    private int seats = 5;

    public override void ShowDetails()
    {
        Console.WriteLine("Car → Speed: " + speedLimit + " km/hr, Fuel: " + fuel + ", Seats: " + seats);
    }
}

class TruckTransport : Transport
{
    private int loadCapacity = 500;

    public override void ShowDetails()
    {
        Console.WriteLine("Truck → Speed: " + speedLimit + " km/hr, Fuel: " + fuel + ", Load: " + loadCapacity);
    }
}

class BikeTransport : Transport
{
    private bool sideCarAttached = false;

    public override void ShowDetails()
    {
        Console.WriteLine("Bike → Speed: " + speedLimit + " km/hr, Fuel: " + fuel + ", Sidecar: " + sideCarAttached);
    }
}

class Program
{
    static void Main()
    {
        Transport t1 = new Transport();
        Transport t2 = new CarTransport();
        Transport t3 = new TruckTransport();
        Transport t4 = new BikeTransport();

        t1.ShowDetails();
        t2.ShowDetails();
        t3.ShowDetails();
        t4.ShowDetails();
    }
}