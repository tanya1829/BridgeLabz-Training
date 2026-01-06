using System;

//  Interface for Reservable Resources 
interface IReservable
{
    void Reserve(string userName);
    bool IsAvailable();
}

//Abstract Library Resource
abstract class LibraryItem
{
    private int id;
    private string itemTitle;
    private string creator;

    public void SetId(int itemId) { id = itemId; }
    public int GetId() { return id; }

    public void SetItemTitle(string title) { itemTitle = title; }
    public string GetItemTitle() { return itemTitle; }

    public void SetCreator(string name) { creator = name; }
    public string GetCreator() { return creator; }

    public void ShowItemInfo()
    {
        Console.WriteLine("Item ID: " + id);
        Console.WriteLine("Title: " + itemTitle);
        Console.WriteLine("Author/Creator: " + creator);
    }

    // abstract loan duration
    public abstract int LoanDays();
}

//  Book
class Book : LibraryItem, IReservable
{
    private bool available = true;

    public override int LoanDays()
    {
        return 14;
    }

    public void Reserve(string userName)
    {
        if (available)
        {
            Console.WriteLine(userName + " reserved the book.");
            available = false;
        }
        else
        {
            Console.WriteLine("Book is currently unavailable.");
        }
    }

    public bool IsAvailable()
    {
        return available;
    }
}

// Magazine 
class Magazine : LibraryItem
{
    public override int LoanDays()
    {
        return 7;
    }
}

// DVD 
class DVD : LibraryItem, IReservable
{
    private bool available = true;

    public override int LoanDays()
    {
        return 3;
    }

    public void Reserve(string userName)
    {
        if (available)
        {
            Console.WriteLine(userName + " reserved the DVD.");
            available = false;
        }
        else
        {
            Console.WriteLine("DVD is currently unavailable.");
        }
    }

    public bool IsAvailable()
    {
        return available;
    }
}

// Main Program
class ProgramLibrary
{
    static void Main()
    {
        Book book = new Book();
        book.SetId(1);
        book.SetItemTitle("C# Basics");
        book.SetCreator("Rahul");

        Magazine magazine = new Magazine();
        magazine.SetId(2);
        magazine.SetItemTitle("Science Monthly");
        magazine.SetCreator("Anita");

        DVD dvd = new DVD();
        dvd.SetId(3);
        dvd.SetItemTitle("Learning C# Video");
        dvd.SetCreator("Zainab");

        Console.WriteLine("---- Book Details ----");
        book.ShowItemInfo();
        Console.WriteLine("Loan Period: " + book.LoanDays() + " days");
        book.Reserve("Rahul");
        Console.WriteLine("Available? " + book.IsAvailable());
        Console.WriteLine();

        Console.WriteLine("---- Magazine Details ----");
        magazine.ShowItemInfo();
        Console.WriteLine("Loan Period: " + magazine.LoanDays() + " days");
        Console.WriteLine();

        Console.WriteLine("---- DVD Details ----");
        dvd.ShowItemInfo();
        Console.WriteLine("Loan Period: " + dvd.LoanDays() + " days");
        dvd.Reserve("Anita");
        Console.WriteLine("Available? " + dvd.IsAvailable());
    }
}
