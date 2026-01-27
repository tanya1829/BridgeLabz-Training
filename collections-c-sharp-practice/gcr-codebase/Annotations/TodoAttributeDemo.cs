using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task { get; set; }
    public string AssignedTo { get; set; }
    public string Priority { get; set; } = "MEDIUM";

    public TodoAttribute(string task, string assignedTo)
    {
        Task = task;
        AssignedTo = assignedTo;
    }
}

class Project
{
    [Todo("Add login", "Tanya", Priority = "HIGH")]
    [Todo("Improve UI", "Rahul")]
    public void Features() { }
}

class Program
{
    static void Main()
    {
        MethodInfo method = typeof(Project).GetMethod("Features");
        var todos = method.GetCustomAttributes(typeof(TodoAttribute), false);

        foreach (TodoAttribute t in todos)
        {
            Console.WriteLine($"{t.Task} | {t.AssignedTo} | {t.Priority}");
        }
    }
}
