using System;
using System.Collections.Generic;

class BinaryNumbers
{
    static void Main()
    {
        int N = 5;
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("1");

        for (int i = 0; i < N; i++)
        {
            string current = queue.Dequeue();
            Console.Write(current + " ");

            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }
    }
}
