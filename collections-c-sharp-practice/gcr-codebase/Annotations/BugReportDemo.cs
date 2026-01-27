using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description { get; set; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

class Software
{
    [BugReport("Login issue")]
    [BugReport("UI alignment problem")]
    public void Run()
    {
        Console.WriteLine("Software running");
    }
}

class Program
{
    static void Main()
    {
        MethodInfo method = typeof(Software).GetMethod("Run");
        var bugs = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        foreach (BugReportAttribute bug in bugs)
        {
            Console.WriteLine("Bug: " + bug.Description);
        }
    }
}
