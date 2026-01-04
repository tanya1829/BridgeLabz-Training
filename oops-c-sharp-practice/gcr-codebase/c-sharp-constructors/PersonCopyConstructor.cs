// Question:
// Create a Person class with a copy constructor
// that copies the data from another object.

using System;

class PersonCopyConstructor
{
    public string name;
    public int age;

    // Parameterized constructor
    public Person(string n, int a)
    {
        name = n;
        age = a;
    }

    // Copy constructor
    public Person(Person p)
    {
        name = p.name;
        age = p.age;
    }

    static void Main()
    {
        // Original object
        Person p1 = new Person("Ana", 21);

        // Copying object data
        Person p2 = new Person(p1);

        Console.WriteLine(p2.name + " " + p2.age);
    }
}