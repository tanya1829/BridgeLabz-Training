// Question:
// Create a Vehicle class with instance variables ownerName and vehicleType.
// Create a class variable registrationFee common for all vehicles.
// Implement an instance method to display vehicle details
// and a class method to update registration fee.

using System;

class VehicleRegistration
{
    // Instance variables
    public string ownerName;
    public string vehicleType;

    // Class variable shared by all vehicles
    public static double registrationFee = 1000;

    // Instance method to display vehicle details
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Vehicle Type: " + vehicleType);
        Console.WriteLine("Registration Fee: " + registrationFee);
    }

    // Class method to update registration fee
    public static void UpdateRegistrationFee(double fee)
    {
        registrationFee = fee;
    }

    static void Main()
    {
        Vehicle v1 = new Vehicle();
        v1.ownerName = "Ana";
        v1.vehicleType = "Car";

        // Displaying vehicle details
        v1.DisplayVehicleDetails();

        // Updating registration fee
        Vehicle.UpdateRegistrationFee(1500);

        // Displaying updated details
        v1.DisplayVehicleDetails();
    }
}