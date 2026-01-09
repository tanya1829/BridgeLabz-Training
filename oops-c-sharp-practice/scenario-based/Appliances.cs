using System;

// Interface
interface ISwitchable
{
    void SwitchOn();
    void SwitchOff();
}

// Abstract base class
abstract class SmartDevice
{
    protected string deviceName;

    public SmartDevice(string deviceName)
    {
        this.deviceName = deviceName;
    }
}

// Light class
class SmartLight : SmartDevice, ISwitchable
{
    public SmartLight(string deviceName) : base(deviceName)
    {
    }

    public void SwitchOn()
    {
        Console.WriteLine(deviceName + " light is glowing");
    }

    public void SwitchOff()
    {
        Console.WriteLine(deviceName + " light is turned off");
    }
}

// Fan class
class SmartFan : SmartDevice, ISwitchable
{
    public SmartFan(string deviceName) : base(deviceName)
    {
    }

    public void SwitchOn()
    {
        Console.WriteLine(deviceName + " fan started rotating");
    }

    public void SwitchOff()
    {
        Console.WriteLine(deviceName + " fan stopped");
    }
}

// AC class
class SmartAC : SmartDevice, ISwitchable
{
    public SmartAC(string deviceName) : base(deviceName)
    {
    }

    public void SwitchOn()
    {
        Console.WriteLine(deviceName + " AC cooling started");
    }

    public void SwitchOff()
    {
        Console.WriteLine(deviceName + " AC turned off");
    }
}

// Main class
class SmartHomeApp
{
    static void Main()
    {
        ISwitchable device1 = new SmartLight("Bedroom");
        ISwitchable device2 = new SmartFan("Hall");
        ISwitchable device3 = new SmartAC("Living Room");

        device1.SwitchOn();
        device2.SwitchOn();
        device3.SwitchOn();

        device1.SwitchOff();
        device2.SwitchOff();
        device3.SwitchOff();
    }
}
