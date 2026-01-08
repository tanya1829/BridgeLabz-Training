using System;

class MovieNode
{
    public string Title;
    public string Director;
    public int Year;
    public double Rating;
    public MovieNode Prev;
    public MovieNode Next;

    public MovieNode(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
        Prev = null;
        Next = null;
    }
}

class MovieDoublyLinkedList
{
    private MovieNode head;
    private MovieNode tail;

    // Add at Beginning
    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        newNode.Next = head;
        head.Prev = newNode;
        head = newNode;
    }

    // Add at End
    public void AddAtEnd(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

        if (tail == null)
        {
            head = tail = newNode;
            return;
        }

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
    }

    // Add at Specific Position (1-based)
    public void AddAtPosition(int position, string title, string director, int year, double rating)
    {
        if (position <= 1)
        {
            AddAtBeginning(title, director, year, rating);
            return;
        }

        MovieNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null || temp.Next == null)
        {
            AddAtEnd(title, director, year, rating);
            return;
        }

        MovieNode newNode = new MovieNode(title, director, year, rating);
        newNode.Next = temp.Next;
        newNode.Prev = temp;
        temp.Next.Prev = newNode;
        temp.Next = newNode;
    }

    // Remove by Movie Title
    public void RemoveByTitle(string title)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (temp == head)
                    head = temp.Next;

                if (temp == tail)
                    tail = temp.Prev;

                if (temp.Prev != null)
                    temp.Prev.Next = temp.Next;

                if (temp.Next != null)
                    temp.Next.Prev = temp.Prev;

                return;
            }
            temp = temp.Next;
        }
    }

    // Search by Director
    public void SearchByDirector(string director)
    {
        MovieNode temp = head;
        while (temp != null)
        {
            if (temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{temp.Title} | {temp.Director} | {temp.Year} | {temp.Rating}");
            temp = temp.Next;
        }
    }

    // Search by Rating
    public void SearchByRating(double rating)
    {
        MovieNode temp = head;
        while (temp != null)
        {
            if (temp.Rating == rating)
                Console.WriteLine($"{temp.Title} | {temp.Director} | {temp.Year} | {temp.Rating}");
            temp = temp.Next;
        }
    }

    // Update Rating by Movie Title
    public void UpdateRating(string title, double newRating)
    {
        MovieNode temp = head;
        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                temp.Rating = newRating;
                return;
            }
            temp = temp.Next;
        }
    }

    // Display Forward
    public void DisplayForward()
    {
        MovieNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Title} | {temp.Director} | {temp.Year} | {temp.Rating}");
            temp = temp.Next;
        }
    }

    // Display Reverse
    public void DisplayReverse()
    {
        MovieNode temp = tail;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Title} | {temp.Director} | {temp.Year} | {temp.Rating}");
            temp = temp.Prev;
        }
    }
}

class Program
{
    static void Main()
    {
        MovieDoublyLinkedList list = new MovieDoublyLinkedList();

        list.AddAtBeginning("Inception", "Christopher Nolan", 2010, 8.8);
        list.AddAtEnd("Interstellar", "Christopher Nolan", 2014, 8.6);
        list.AddAtPosition(2, "Avatar", "James Cameron", 2009, 7.9);

        Console.WriteLine("All Movies (Forward):");
        list.DisplayForward();

        Console.WriteLine("\nSearch by Director:");
        list.SearchByDirector("Christopher Nolan");

        Console.WriteLine("\nUpdating Rating:");
        list.UpdateRating("Avatar", 8.1);

        Console.WriteLine("\nAfter Update (Reverse):");
        list.DisplayReverse();

        Console.WriteLine("\nRemoving Movie:");
        list.RemoveByTitle("Inception");

        Console.WriteLine("\nFinal List:");
        list.DisplayForward();
    }
}
