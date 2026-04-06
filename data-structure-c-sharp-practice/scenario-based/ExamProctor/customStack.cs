using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProctor
{
    internal class customStack
		{
			private int[] stack;
			private int top;

			public customStack(int size)
			{
				stack = new int[size];
				top = -1;
			}

			public void Push(int value)
			{
				if (top < stack.Length - 1)
					stack[++top] = value;
			}

			public int Pop()
			{
				if (top >= 0)
					return stack[top--];

				return -1;
			}
		}
	}

