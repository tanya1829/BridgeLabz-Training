using System;
using System.Collections.Generic;

class QueueUsingStacks
{
    // Stack for enqueue operation
    Stack<int> s1 = new Stack<int>();

    // Stack for dequeue operation
    Stack<int> s2 = new Stack<int>();

    // Add element to queue
    public void Enqueue(int x)
    {
        // Always push into s1
        s1.Push(x);
    }

    // Remove element from queue
    public int Dequeue()
    {
        // If dequeue stack is empty, move elements from s1 to s2
        if (s2.Count == 0)
        {
            while (s1.Count > 0)
                s2.Push(s1.Pop());
        }

        // Top of s2 is the front of the queue
        return s2.Pop();
    }

    static void Main()
    {
        QueueUsingStacks q = new QueueUsingStacks();
        q.Enqueue(10);
        q.Enqueue(20);

        Console.WriteLine(q.Dequeue()); // Output: 10
    }
}