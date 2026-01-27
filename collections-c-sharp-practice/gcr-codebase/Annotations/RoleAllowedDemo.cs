using System;

[AttributeUsage(AttributeTargets.Method)]
class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

class AdminPanel
{
    [RoleAllowed("ADMIN")]
    public void DeleteUser()
    {
        Console.WriteLine("User deleted");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter role: ");
        string role = Console.ReadLine();

        AdminPanel panel = new AdminPanel();
        var method = typeof(AdminPanel).GetMethod("DeleteUser");
        var attr = (RoleAllowedAttribute)Attribute.GetCustomAttribute(method, typeof(RoleAllowedAttribute));

        if (attr.Role == role)
            panel.DeleteUser();
        else
            Console.WriteLine("Access Denied!");
    }
}
