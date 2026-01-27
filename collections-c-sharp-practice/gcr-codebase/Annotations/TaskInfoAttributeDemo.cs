using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public string Priority { get; set; }
    public string AssignedTo { get; set; }

    public TaskInfoAttribute(string priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

class TaskManager
{
    [TaskInfo("High", "Tanya")]
    public void CompleteTask()
    {
        Console.WriteLine("Task completed");
    }
}

class Program
{
    static void Main()
    {
        MethodInfo method = typeof(TaskManager).GetMethod("CompleteTask");
        TaskInfoAttribute attr =
            (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

        Console.WriteLine("Priority: " + attr.Priority);
        Console.WriteLine("Assigned To: " + attr.AssignedTo);
    }
}
