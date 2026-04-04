// Question:
// Write a program to create a Book class with title, author, and price.
// Add a method to display book details.

using System;

class BookDetails
{
    // Book attributes
    public string title;
    public string author;
    public double price;

    // Method to display book information
    public void Display()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }

    static void Main()
    {
        // Creating book object
        Book b = new Book();

        // Assigning values
        b.title = "C# Basics";
        b.author = "John";
        b.price = 350;

        // Displaying book details
        b.Display();
    }
}