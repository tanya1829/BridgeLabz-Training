// Question:
// Create a Book class with attributes title, author, and price.
// Provide both default and parameterized constructors.

using System;

class BookConstructor
{
    public string title;
    public string author;
    public double price;

    // Default constructor
    public Book()
    {
        title = "Unknown";
        author = "Unknown";
        price = 0;
    }

    // Parameterized constructor
    public Book(string t, string a, double p)
    {
        title = t;
        author = a;
        price = p;
    }

    // Method to display book details
    public void Display()
    {
        Console.WriteLine(title + " " + author + " " + price);
    }

    static void Main()
    {
        // Creating objects using different constructors
        Book b1 = new Book();
        Book b2 = new Book("AI", "Ana", 500);

        b1.Display();
        b2.Display();
    }
}