using System;
using System.Collections.Generic;

class SortStack
{
    // Inserts an element in sorted order into stack
    static void InsertSorted(Stack<int> stack, int value)
    {
        // Base condition: stack empty OR correct position found
        if (stack.Count == 0 || stack.Peek() <= value)
        {
            stack.Push(value);
            return;
        }

        // Remove top and recur
        int temp = stack.Pop();
        InsertSorted(stack, value);

        // Put back removed element
        stack.Push(temp);
    }

    // Sorts the stack using recursion
    static void Sort(Stack<int> stack)
    {
        // Base condition
        if (stack.Count == 0) return;

        // Remove top element
        int top = stack.Pop();

        // Sort remaining stack
        Sort(stack);

        // Insert removed element at correct position
        InsertSorted(stack, top);
    }

    static void Main()
    {
        Stack<int> s = new Stack<int>(new[] { 3, 1, 4, 2 });
        Sort(s);

        foreach (int x in s)
            Console.Write(x + " ");
    }
}