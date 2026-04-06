using System;

[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Length { get; }

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

class User
{
    [MaxLength(5)]
    public string Username;

    public User(string username)
    {
        if (username.Length > 5)
            throw new ArgumentException("Username too long!");

        Username = username;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string name = Console.ReadLine();

        try
        {
            User u = new User(name);
            Console.WriteLine("User created: " + u.Username);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
