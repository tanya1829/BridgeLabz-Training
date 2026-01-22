// reverse a stack using array using recursion
    // circular queue stack using stack
using System;

class Linkedlist
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public Node head;
    public Node tail;

    public Node Reverse(Node head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        Node newHead = Reverse(head.next);
        head.next.next = head;
        head.next = null;

        return newHead;
    }

    public void Print(Node head)
    {
        while (head != null)
        {
            Console.Write(head.data + "---> ");
            head = head.next;
        }
        Console.WriteLine("null");
    }

    static void Main()
    {
        Linkedlist list = new Linkedlist();

        list.head = new Linkedlist.Node(1);
        list.head.next = new Linkedlist.Node(2);
        list.head.next.next = new Linkedlist.Node(3);
        list.head.next.next.next = new Linkedlist.Node(4);
        list.head.next.next.next.next = new Linkedlist.Node(5);

        list.Print(list.head);

        list.head = list.Reverse(list.head);

        list.Print(list.head);
    }
}
