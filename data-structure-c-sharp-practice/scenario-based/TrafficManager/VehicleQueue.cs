using System;

namespace TrafficManager
{
	internal class VehicleQueue
	{
		private string[] queue;
		private int front, rear, size, capacity;

		public VehicleQueue(int capacity)
		{
			this.capacity = capacity;
			queue = new string[capacity];
			front = 0;
			rear = -1;
			size = 0;
		}

		public void Enqueue(string number)
		{
			if (size == capacity)
			{
				Console.WriteLine("Queue Overflow!");
				return;
			}

			rear = (rear + 1) % capacity;
			queue[rear] = number;
			size++;
		}

		public string Dequeue()
		{
			if (size == 0)
			{
				Console.WriteLine("Queue Underflow!");
				return null;
			}

			string val = queue[front];
			front = (front + 1) % capacity;
			size--;
			return val;
		}

		public bool IsEmpty() => size == 0;
	}
}
