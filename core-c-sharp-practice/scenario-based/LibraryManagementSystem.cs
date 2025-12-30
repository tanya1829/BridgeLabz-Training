using System;

class LibraryManagementSystem
{
    // Struct to store book details

    struct Book
    {
        public string Title;
        public string Author;
        public bool IsAvailable;
    }

    static void Main()
    {
        // Step 1: Initialize books array

        Book[] books = new Book[3];
        InitializeBooks(books);

        // Step 2: Search for a book

        Console.WriteLine("Enter book title to search:");
        string searchTitle = Console.ReadLine();
        int index = SearchBook(books, searchTitle);

        // Step 3: Display result

        if (index >= 0)
        {
            DisplayBook(books[index]);

            // Step 4: Checkout if available

            UpdateStatus(ref books[index]);
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // Method to initialize books with user input
    
    static void InitializeBooks(Book[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            Console.WriteLine($"Enter Title for Book {i + 1}:");
            books[i].Title = Console.ReadLine();

            Console.WriteLine($"Enter Author for Book {i + 1}:");
            books[i].Author = Console.ReadLine();

            books[i].IsAvailable = true;
        }
    }

    // Method to search a book by partial title
    static int SearchBook(Book[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return i; // Return the index of the first match
            }
        }
        return -1; // Not found
    }

    // Method to display book details
    static void DisplayBook(Book book)
    {
        Console.WriteLine($"Book Found: {book.Title} by {book.Author}");
        Console.WriteLine("Status: " + (book.IsAvailable ? "Available" : "Checked out"));
    }

    // Method to update book status (checkout)
    static void UpdateStatus(ref Book book)
    {
        if (book.IsAvailable)
        {
            Console.WriteLine("Do you want to checkout this book? (yes/no)");
            string choice = Console.ReadLine();
            if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                book.IsAvailable = false;
                Console.WriteLine("Book checked out successfully!");
            }
            else
            {
                Console.WriteLine("Book not checked out.");
            }
        }
        else
        {
            Console.WriteLine("Sorry, this book is already checked out.");
        }
    }
}
