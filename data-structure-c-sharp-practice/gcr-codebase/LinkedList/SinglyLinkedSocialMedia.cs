using System;

class User {
    public int id, age;
    public string name;
    public User next;
    public int f1, f2, f3; // friend IDs (fixed 3 slots like a student would)
    public User(int i, string n, int a) {
        id = i; name = n; age = a; next = null;
        f1 = f2 = f3 = -1;
    }
}

class Program {
    static void Main() {
        User head = null;

        void AddUser(int i, string n, int a) {
            User u = new User(i, n, a);
            u.next = head;
            head = u;
        }

        void AddFriend(int u1, int u2) {
            User t = head;
            while (t != null) {
                if (t.id == u1) t.f1 = u2;
                if (t.id == u2) t.f1 = u1;
                t = t.next;
            }
        }

        AddUser(1, "Amit", 20);
        AddUser(2, "Neha", 21);
        AddUser(3, "Sameer", 19);

        AddFriend(1, 2);

        Console.WriteLine("Friend connection added (basic simulation)");
    }
}
