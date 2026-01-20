/*using System;
class FindNthFromEnd{
    public void findingElement(int key)
    static void Main(){
    List<int> num = new List<int>();
    num.Add(1);
    num.Add(2);
    num.Add(3);
    num.Add(4);
    foreach (int n in num ){
        Console.Write(n + " ");
    }
    }
}*/
using System;

class LinkedList
{
    public class Node
    {
        public char data;
        public Node next;

        public Node(char data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public Node head;

    public char FindNthFromEnd(int n)
    {
        Node fast = head;
        Node slow = head;

        // Move fast pointer n steps ahead
        for (int i = 0; i < n; i++)
        {
            if (fast == null)
                throw new Exception("N is larger than list length");

            fast = fast.next;
        }

        // Move both pointers
        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        return slow.data;
    }

    static void Main()
    {
        LinkedList list = new LinkedList();
        list.head = new Node('A');
        list.head.next = new Node('B');
        list.head.next.next = new Node('C');
        list.head.next.next.next = new Node('D');
        list.head.next.next.next.next = new Node('E');

        int N = 2;
        Console.WriteLine(list.FindNthFromEnd(N));
    }
}
