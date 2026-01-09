using System;

class State {
    public string text;
    public State prev, next;
    public State(string t) {
        text = t; prev = next = null;
    }
}

class Program {
    static void Main() {
        State head = null, cur = null, temp = null;

        void AddState(string t) {
            State s = new State(t);
            if (head == null) {
                head = cur = s;
            } else {
                cur.next = s;
                s.prev = cur;
                cur = s;
            }
        }

        void Undo() {
            if (cur.prev != null) cur = cur.prev;
        }

        void Redo() {
            if (cur.next != null) cur = cur.next;
        }

        AddState("Hello");
        AddState("Hello World");
        AddState("Hello World!");

        Console.WriteLine("Current: " + cur.text);
        Undo();
        Console.WriteLine("Undo: " + cur.text);
        Redo();
        Console.WriteLine("Redo: " + cur.text);
    }
}
