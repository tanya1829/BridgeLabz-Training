using System;

class FindNthFromEnd
{
    class Node
    {
        public char data;
        public Node next;

        public Node(char data)
        {
            this.data = data;
            this.next = null;
        }
    }

    Node head;

    // Add node at end
    public void Add(char data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        temp.next = newNode;
    }

    // RENAMED METHOD ✅
    public void PrintNthFromEnd(int n)
    {
        Node slow = head;
        Node fast = head;

        // Move fast n steps ahead
        for (int i = 0; i < n; i++)
        {
            if (fast == null)
            {
                Console.WriteLine("N is greater than list length");
                return;
            }
            fast = fast.next;
        }

        // Move both pointers
        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        Console.WriteLine("Nth element from end is: " + slow.data);
    }

    static void Main()
    {
        FindNthFromEnd list = new FindNthFromEnd();
        list.Add('A');
        list.Add('B');
        list.Add('C');
        list.Add('D');
        list.Add('E');

        int n = 2;
        list.PrintNthFromEnd(n);
    }
}
