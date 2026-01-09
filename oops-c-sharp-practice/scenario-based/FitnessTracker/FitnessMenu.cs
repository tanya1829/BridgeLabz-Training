using System;

namespace FitnessTracker
{
	public class FitnessMenu
	{
		public Workout[] GetWorkouts()
		{
			Console.Write("Enter number of workouts: ");
			int n = int.Parse(Console.ReadLine());

			Workout[] workouts = new Workout[n];

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("\n--- Workout Menu ---");
				Console.WriteLine("1. Cardio Workout");
				Console.WriteLine("2. Strength Workout");
				Console.Write("Choose option: ");
				int choice = int.Parse(Console.ReadLine());

				Console.Write("Enter duration (minutes): ");
				int duration = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						workouts[i] = new CardioWorkout(duration);
						break;
					case 2:
						workouts[i] = new StrengthWorkout(duration);
						break;
					default:
						Console.WriteLine("Invalid choice, defaulting to Cardio");
						workouts[i] = new CardioWorkout(duration);
						break;
				}
			}

			return workouts;
		}
	}
}
