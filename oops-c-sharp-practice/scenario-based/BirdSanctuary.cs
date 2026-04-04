sing System;

// Interfaces
interface CanFly
{
    void DoFly();
}

interface CanSwim
{
    void DoSwim();
}

// Parent class
class AnimalBird
{
    public string BirdName;
}

// Child classes
class EagleBird : AnimalBird, CanFly
{
    public void DoFly()
    {
        Console.WriteLine(BirdName + " is flying");
    }
}

class SmallSparrow : AnimalBird, CanFly
{
    public void DoFly()
    {
        Console.WriteLine(BirdName + " is flying");
    }
}

class WaterDuck : AnimalBird, CanSwim
{
    public void DoSwim()
    {
        Console.WriteLine(BirdName + " is swimming");
    }
}

class IcePenguin : AnimalBird, CanSwim
{
    public void DoSwim()
    {
        Console.WriteLine(BirdName + " is swimming");
    }
}

class SeaGull : AnimalBird, CanFly, CanSwim
{
    public void DoFly()
    {
        Console.WriteLine(BirdName + " is flying");
    }

    public void DoSwim()
    {
        Console.WriteLine(BirdName + " is swimming");
    }
}

// Main class
class Program
{
    static void Main()
    {
        AnimalBird[] list = new AnimalBird[5];

        list[0] = new EagleBird();
        list[0].BirdName = "Eagle";

        list[1] = new SmallSparrow();
        list[1].BirdName = "Sparrow";

        list[2] = new WaterDuck();
        list[2].BirdName = "Duck";

        list[3] = new IcePenguin();
        list[3].BirdName = "Penguin";

        list[4] = new SeaGull();
        list[4].BirdName = "Seagull";

        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine("Bird Name: " + list[i].BirdName);

            CanFly flyRef = list[i] as CanFly;
            if (flyRef != null)
            {
                flyRef.DoFly();
            }

            CanSwim swimRef = list[i] as CanSwim;
            if (swimRef != null)
            {
                swimRef.DoSwim();
            }

            Console.WriteLine();
        }
    }
}