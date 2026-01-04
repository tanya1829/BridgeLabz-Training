// Question:
// Design a Book class with ISBN as public, title as protected,
// and author as private.
// Implement methods to set and get author name.
// Create a subclass EBook to access ISBN and title.

using System;

class BookLibrary
{
    // Public member
    public string ISBN;

    // Protected member
    protected string title;

    // Private member
    private string author;

    // Public method to set author
    public void SetAuthor(string name)
    {
        author = name;
    }

    // Public method to get author
    public string GetAuthor()
    {
        return author;
    }
}

// Subclass to demonstrate access modifiers
class EBook : Book
{
    public void DisplayBookInfo()
    {
        ISBN = "ISBN123";   // public access
        title = "C# Guide"; // protected access

        Console.WriteLine("ISBN: " + ISBN);
        Console.WriteLine("Title: " + title);
    }

    static void Main()
    {
        EBook eb = new EBook();
        eb.SetAuthor("Ana");

        eb.DisplayBookInfo();
        Console.WriteLine("Author: " + eb.GetAuthor());
    }
}