using System;

class ItemNode
{
    public int ItemId;
    public string Name;
    public int Quantity;
    public double Price;
    public ItemNode Next;

    public ItemNode(int id, string name, int qty, double price)
    {
        ItemId = id;
        Name = name;
        Quantity = qty;
        Price = price;
        Next = null;
    }
}

class InventoryList
{
    private ItemNode head;

    public void AddAtEnd(int id, string name, int qty, double price)
    {
        ItemNode node = new ItemNode(id, name, qty, price);
        if (head == null) { head = node; return; }
        ItemNode temp = head;
        while (temp.Next != null) temp = temp.Next;
        temp.Next = node;
    }

    public void RemoveById(int id)
    {
        if (head == null) return;
        if (head.ItemId == id) { head = head.Next; return; }
        ItemNode t = head;
        while (t.Next != null && t.Next.ItemId != id) t = t.Next;
        if (t.Next != null) t.Next = t.Next.Next;
    }

    public void UpdateQuantity(int id, int qty)
    {
        ItemNode t = head;
        while (t != null)
        {
            if (t.ItemId == id) { t.Quantity = qty; return; }
            t = t.Next;
        }
    }

    public void SearchByName(string name)
    {
        ItemNode t = head;
        while (t != null)
        {
            if (t.Name == name)
                Console.WriteLine($"{t.ItemId} {t.Name} {t.Quantity} {t.Price}");
            t = t.Next;
        }
    }

    public void TotalValue()
    {
        double sum = 0;
        ItemNode t = head;
        while (t != null)
        {
            sum += t.Quantity * t.Price;
            t = t.Next;
        }
        Console.WriteLine("Total Inventory Value = " + sum);
    }

    public void Display()
    {
        ItemNode t = head;
        while (t != null)
        {
            Console.WriteLine($"{t.ItemId} | {t.Name} | {t.Quantity} | {t.Price}");
            t = t.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        InventoryList inv = new InventoryList();
        inv.AddAtEnd(1, "Pen", 10, 5);
        inv.AddAtEnd(2, "Book", 5, 50);
        inv.Display();
        inv.TotalValue();
    }
}
