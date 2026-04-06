using System;

class TextNode
{
    public string Text;
    public TextNode Prev, Next;
    public TextNode(string t) { Text = t; }
}

class Editor
{
    TextNode current;

    public void AddState(string text)
    {
        TextNode n = new TextNode(text);
        if (current != null) { current.Next = n; n.Prev = current; }
        current = n;
    }

    public void Undo() { if (current?.Prev != null) current = current.Prev; }
    public void Redo() { if (current?.Next != null) current = current.Next; }

    public void Show() => Console.WriteLine(current?.Text);
}

class Program
{
    static void Main()
    {
        Editor e = new Editor();
        e.AddState("Hello");
        e.AddState("Hello World");
        e.Undo();
        e.Show();
    }
}
