using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProctor
{
    internal class customHashMap
    {

		private int[] keys;
		private string[] values;
		private int size;

		public customHashMap(int capacity)
		{
			keys = new int[capacity];
			values = new string[capacity];
			size = 0;
		}

		public void Put(int key, string value)
		{
			keys[size] = key;
			values[size] = value;
			size++;
		}

		public string Get(int key)
		{
			for (int i = 0; i < size; i++)
			{
				if (keys[i] == key)
					return values[i];
			}
			return null;
		}
	}
}