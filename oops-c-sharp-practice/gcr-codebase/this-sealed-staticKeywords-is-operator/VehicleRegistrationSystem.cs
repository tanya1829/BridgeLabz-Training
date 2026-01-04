// Question:
// Create a Vehicle class demonstrating static, this, readonly and is operator
// for Vehicle Registration System.

using System;

class VehicleRegistrationSystem
{
    // Static registration fee
    public static double RegistrationFee = 1000;

    // Readonly registration number
    public readonly string RegistrationNumber;
    public string OwnerName;
    public string VehicleType;

    // Constructor using this keyword
    public Vehicle(string RegistrationNumber, string OwnerName, string VehicleType)
    {
        this.RegistrationNumber = RegistrationNumber;
        this.OwnerName = OwnerName;
        this.VehicleType = VehicleType;
    }

    // Static method to update registration fee
    public static void UpdateRegistrationFee(double fee)
    {
        RegistrationFee = fee;
    }

    static void Main()
    {
        Vehicle v = new Vehicle("UP14AB1234", "Ana", "Car");

        if (v is Vehicle)
        {
            Console.WriteLine(v.OwnerName + " owns a " + v.VehicleType);
        }

        UpdateRegistrationFee(1500);
    }
}