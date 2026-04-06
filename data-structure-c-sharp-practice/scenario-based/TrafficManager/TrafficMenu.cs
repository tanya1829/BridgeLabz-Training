using System;

namespace TrafficManager
{
	internal class TrafficMenu
	{
		private Roundabout roundabout = new Roundabout();
		private VehicleQueue queue = new VehicleQueue(3);

		public void Start()
		{
			while (true)
			{
				Console.WriteLine("\n1. Add vehicle to waiting queue");
				Console.WriteLine("2. Allow vehicle to enter roundabout");
				Console.WriteLine("3. Remove vehicle from roundabout");
				Console.WriteLine("4. Display roundabout");
				Console.WriteLine("5. Exit");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter vehicle number: ");
						queue.Enqueue(Console.ReadLine());
						break;

					case 2:
						if (!queue.IsEmpty())
							roundabout.AddVehicle(queue.Dequeue());
						break;

					case 3:
						Console.Write("Enter vehicle number to remove: ");
						roundabout.RemoveVehicle(Console.ReadLine());
						break;

					case 4:
						roundabout.Display();
						break;

					case 5:
						return;
				}
			}
		}
	}
}
