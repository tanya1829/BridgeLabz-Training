using System;
class ReverseAList{
    public class Node{
        public int data;
        public Node next;
        public Node(int data){
            this.data=data;
            this.next=null;

        }
    }
    public Node head;
    public Node tail;
    public int size=0;
    // add first 
    public void addFirst(int data){
        // creation of a new node
        Node newNode = new Node (data);
        // if empty linked list
        if(head==null){
            head=tail=newNode;
            return;
        }
        // newNode.next --> head
        newNode.next=head;
        // newnode will be new head
        head=newNode;

    }
    /*public void addLast(int data){
        // create a newNode
        Node newNode = new Node(data);
            if(head==null){
                head=tail=newNode;
                return;
            }
        // tail.next--> newNode
        tail.next=newNode;
        // making newNode as Tail
        tail=NewNode;
        } */
    
    public void print(){
        if(head==null){
            Console.WriteLine("list is empty");
            return;
        }
        Node temp = head;
        while(temp !=null){
            Console.Write(temp.data + " --> ");
            temp=temp.next;
        }
    
        Console.WriteLine("null");
    }
    public void Reverse(){
        Node prev =null ; // as head is the starting point
        Node curr= tail=head; // as after reversing 
        Node next;
        while(curr != null){
            next=curr.next;
            curr.next=prev;
            prev=curr;
            curr=next;
        }
        head=prev;
    }
    
    
    static void Main(){
         ReverseAList ll = new ReverseAList();
        
         ll.addFirst(4);
         ll.print();
         ll.addFirst(3);
         ll.print();
         ll.addFirst(2);
         ll.print();
         ll.addFirst(1);
         ll.print();
         ll.Reverse();
         ll.print();
    }
}