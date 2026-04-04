using System;

class LivingBeing
{
    protected int age;
    protected string name;

    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic sound");
    }
}

class DogAnimal : LivingBeing
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class CatAnimal : LivingBeing
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

class BirdAnimal : LivingBeing
{
    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps");
    }
}

class Program
{
    static void Main(string[] args)
    {
        LivingBeing dog = new DogAnimal();
        LivingBeing cat = new CatAnimal();
        LivingBeing bird = new BirdAnimal();

        dog.MakeSound();
        cat.MakeSound();
        bird.MakeSound();
    }
}