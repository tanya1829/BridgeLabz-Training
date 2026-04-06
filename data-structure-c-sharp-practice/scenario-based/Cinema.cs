using System;

class CinemaTime
{
    private string[] movieTitles;
    private string[] showTimes;
    private int count; 

    // Constructor: initialize arrays with fixed capacity
    public CinemaTime(int capacity)
    {
        movieTitles = new string[capacity];
        showTimes = new string[capacity];
        count = 0;
    }

    // Add a movie
    public void addMovie(string title, string time)
    {
        if (count >= movieTitles.Length)
        {
            Console.WriteLine("Cannot add more movies. Array is full.");
            return;
        }

        movieTitles[count] = title;
        showTimes[count] = time;
        count++;
        Console.WriteLine($"Movie '{title}' at {time} added successfully!");
    }

    // Search movie by keyword
    public void searchMovie(string keyword)
    {
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (movieTitles[i].Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{i + 1}. {movieTitles[i]} - {showTimes[i]}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No movie found with keyword: " + keyword);
        }
    }

    // Display all movies
    public void displayAllMovies()
    {
        if (count == 0)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        Console.WriteLine("All Movies:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {movieTitles[i]} - {showTimes[i]}");
        }
    }

    // Generate printable report
    public void generateReport()
    {
        Console.WriteLine("\n--- Printable Movie Report ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {movieTitles[i]} - {showTimes[i]}");
        }
    }
}
