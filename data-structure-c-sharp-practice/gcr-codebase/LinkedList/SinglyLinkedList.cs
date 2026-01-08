using System;

class StudentNode
{
    public int RollNo;
    public string Name;
    public int Age;
    public char Grade;
    public StudentNode Next;

    public StudentNode(int roll, string name, int age, char grade)
    {
        RollNo = roll;
        Name = name;
        Age = age;
        Grade = grade;
        Next = null;
    }
}

class StudentLinkedList
{
    private StudentNode head;

    public void AddAtBeginning(int roll, string name, int age, char grade)
    {
        StudentNode newNode = new StudentNode(roll, name, age, grade);
        newNode.Next = head;
        head = newNode;
    }

    public void AddAtEnd(int roll, string name, int age, char grade)
    {
        StudentNode newNode = new StudentNode(roll, name, age, grade);

        if (head == null)
        {
            head = newNode;
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    public void AddAtPosition(int position, int roll, string name, int age, char grade)
    {
        if (position <= 1)
        {
            AddAtBeginning(roll, name, age, grade);
            return;
        }

        StudentNode newNode = new StudentNode(roll, name, age, grade);
        StudentNode temp = head;

        for (int i = 1; i < position - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Position out of range");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    public void DeleteByRollNo(int roll)
    {
        if (head == null)
            return;

        if (head.RollNo == roll)
        {
            head = head.Next;
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null && temp.Next.RollNo != roll)
            temp = temp.Next;

        if (temp.Next != null)
            temp.Next = temp.Next.Next;
    }

    public void Search(int roll)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.RollNo == roll)
            {
                Console.WriteLine($"{temp.RollNo} {temp.Name} {temp.Age} {temp.Grade}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Student not found");
    }

    public void UpdateGrade(int roll, char newGrade)
    {
        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.RollNo == roll)
            {
                temp.Grade = newGrade;
                return;
            }
            temp = temp.Next;
        }
    }

    public void Display()
    {
        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.RollNo} | {temp.Name} | {temp.Age} | {temp.Grade}");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentLinkedList list = new StudentLinkedList();

        list.AddAtBeginning(1, "Tanya", 22, 'A');
        list.AddAtEnd(2, "Rahul", 21, 'B');
        list.AddAtPosition(2, 3, "Aman", 22, 'C');

        list.Display();

        list.Search(2);
        list.UpdateGrade(2, 'A');
        list.DeleteByRollNo(1);

        Console.WriteLine("After Updates:");
        list.Display();
    }
}
