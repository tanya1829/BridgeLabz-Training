using System;

namespace BookShelf
{
	internal class BookLinkedList
	{
		// Node class
		private class BookNode
		{
			public Book Data;
			public BookNode? Next;

			public BookNode(Book book)
			{
				Data = book;
				Next = null;
			}
		}

		private BookNode? head;

		// Add book
		public bool Add(Book book)
		{
			if (Contains(book))
				return false;

			BookNode newNode = new BookNode(book);

			if (head == null)
			{
				head = newNode;
				return true;
			}

			BookNode temp = head;
			while (temp.Next != null)
				temp = temp.Next;

			temp.Next = newNode;
			return true;
		}

		// Remove book
		public bool Remove(Book book)
		{
			if (head == null)
				return false;

			if (IsSame(head.Data, book))
			{
				head = head.Next;
				return true;
			}

			BookNode curr = head;
			while (curr.Next != null)
			{
				if (IsSame(curr.Next.Data, book))
				{
					curr.Next = curr.Next.Next;
					return true;
				}
				curr = curr.Next;
			}
			return false;
		}

		// Display books
		public void Display()
		{
			if (head == null)
			{
				Console.WriteLine("No books available");
				return;
			}

			BookNode temp = head;
			while (temp != null)
			{
				Console.WriteLine($"- {temp.Data.Title} by {temp.Data.Author}");
				temp = temp.Next;
			}
		}

		// Check duplicate
		private bool Contains(Book book)
		{
			BookNode? temp = head;
			while (temp != null)
			{
				if (IsSame(temp.Data, book))
					return true;
				temp = temp.Next;
			}
			return false;
		}

		private bool IsSame(Book b1, Book b2)
		{
			return b1.Title == b2.Title && b1.Author == b2.Author;
		}
	}
}
