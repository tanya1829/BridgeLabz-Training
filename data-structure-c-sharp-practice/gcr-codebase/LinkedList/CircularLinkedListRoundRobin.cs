using System;

class ProcessNode
{
    public int Pid, Burst;
    public ProcessNode Next;
    public ProcessNode(int p, int b) { Pid = p; Burst = b; }
}

class RoundRobin
{
    ProcessNode head;

    public void Add(int pid, int burst)
    {
        ProcessNode n = new ProcessNode(pid, burst);
        if (head == null) { head = n; n.Next = head; return; }
        ProcessNode t = head;
        while (t.Next != head) t = t.Next;
        t.Next = n; n.Next = head;
    }

    public void Execute(int quantum)
    {
        ProcessNode t = head;
        do
        {
            if (t.Burst > 0)
            {
                Console.WriteLine("Executing " + t.Pid);
                t.Burst -= quantum;
            }
            t = t.Next;
        } while (t != head);
    }
}

class Program
{
    static void Main()
    {
        RoundRobin rr = new RoundRobin();
        rr.Add(1, 10);
        rr.Add(2, 5);
        rr.Execute(3);
    }
}
