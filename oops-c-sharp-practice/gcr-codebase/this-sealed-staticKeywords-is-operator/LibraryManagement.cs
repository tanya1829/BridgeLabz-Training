// Question:
// Create a Book class using static, this, readonly and is operator
// for a Library Management System.

using System;

class LibraryManagement
{
    // Static variable shared by all books
    public static string LibraryName = "Central Library";

    // Readonly ISBN
    public readonly string ISBN;
    public string Title;
    public string Author;

    // Constructor using this keyword
    public Book(string ISBN, string Title, string Author)
    {
        this.ISBN = ISBN;
        this.Title = Title;
        this.Author = Author;
    }

    // Static method to display library name
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library: " + LibraryName);
    }

    static void Main()
    {
        Book b = new Book("ISBN001", "C# Basics", "Ana");

        if (b is Book)
        {
            Console.WriteLine(b.Title + " by " + b.Author);
        }

        DisplayLibraryName();
    }
}