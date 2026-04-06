using System;

class TaskNode
{
    public int TaskId;
    public string TaskName;
    public int Priority;
    public DateTime DueDate;
    public TaskNode Next;

    public TaskNode(int id, string name, int priority, DateTime dueDate)
    {
        TaskId = id;
        TaskName = name;
        Priority = priority;
        DueDate = dueDate;
        Next = null;
    }
}

class TaskCircularLinkedList
{
    private TaskNode head;
    private TaskNode current;

    // Add at Beginning
    public void AddAtBeginning(int id, string name, int priority, DateTime dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            current = head;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        newNode.Next = head;
        temp.Next = newNode;
        head = newNode;
    }

    // Add at End
    public void AddAtEnd(int id, string name, int priority, DateTime dueDate)
    {
        TaskNode newNode = new TaskNode(id, name, priority, dueDate);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            current = head;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        temp.Next = newNode;
        newNode.Next = head;
    }

    // Add at Specific Position (1-based)
    public void AddAtPosition(int position, int id, string name, int priority, DateTime dueDate)
    {
        if (position <= 1)
        {
            AddAtBeginning(id, name, priority, dueDate);
            return;
        }

        TaskNode temp = head;
        for (int i = 1; i < position - 1 && temp.Next != head; i++)
            temp = temp.Next;

        TaskNode newNode = new TaskNode(id, name, priority, dueDate);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Remove by Task ID
    public void RemoveByTaskId(int id)
    {
        if (head == null)
            return;

        TaskNode temp = head;
        TaskNode prev = null;

        do
        {
            if (temp.TaskId == id)
            {
                if (temp == head)
                {
                    TaskNode last = head;
                    while (last.Next != head)
                        last = last.Next;

                    head = head.Next;
                    last.Next = head;
                }
                else
                {
                    prev.Next = temp.Next;
                }
                return;
            }

            prev = temp;
            temp = temp.Next;

        } while (temp != head);
    }

    // View Current Task & Move to Next
    public void ViewCurrentAndMoveNext()
    {
        if (current == null)
            return;

        Console.WriteLine($"Current Task: {current.TaskId} | {current.TaskName} | {current.Priority} | {current.DueDate.ToShortDateString()}");
        current = current.Next;
    }

    // Display All Tasks
    public void DisplayAll()
    {
        if (head == null)
            return;

        TaskNode temp = head;
        do
        {
            Console.WriteLine($"{temp.TaskId} | {temp.TaskName} | {temp.Priority} | {temp.DueDate.ToShortDateString()}");
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by Priority
    public void SearchByPriority(int priority)
    {
        if (head == null)
            return;

        TaskNode temp = head;
        do
        {
            if (temp.Priority == priority)
                Console.WriteLine($"{temp.TaskId} | {temp.TaskName} | {temp.Priority} | {temp.DueDate.ToShortDateString()}");

            temp = temp.Next;
        } while (temp != head);
    }
}

class Program
{
    static void Main()
    {
        TaskCircularLinkedList scheduler = new TaskCircularLinkedList();

        scheduler.AddAtBeginning(1, "Design Module", 1, DateTime.Now.AddDays(5));
        scheduler.AddAtEnd(2, "Code Implementation", 2, DateTime.Now.AddDays(10));
        scheduler.AddAtPosition(2, 3, "Testing", 1, DateTime.Now.AddDays(7));

        Console.WriteLine("All Tasks:");
        scheduler.DisplayAll();

        Console.WriteLine("\nSearch by Priority = 1:");
        scheduler.SearchByPriority(1);

        Console.WriteLine("\nCurrent Task Cycle:");
        scheduler.ViewCurrentAndMoveNext();
        scheduler.ViewCurrentAndMoveNext();
        scheduler.ViewCurrentAndMoveNext();

        Console.WriteLine("\nRemoving Task ID 2");
        scheduler.RemoveByTaskId(2);

        Console.WriteLine("\nFinal Task List:");
        scheduler.DisplayAll();
    }
}
