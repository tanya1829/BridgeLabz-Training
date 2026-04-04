using System;

namespace FitnessTracker
{
	class FitnessTrackerMain
	{
		static void Main(string[] args)
		{
			FitnessMenu menu = new FitnessMenu();
			Workout[] workouts = menu.GetWorkouts();

			Console.WriteLine("\n--- Workout Summary ---");
			foreach (Workout w in workouts)
			{
				w.Track();
				Console.WriteLine("Calories Burned: " + w.CalculateCalories());
				Console.WriteLine();
			}
		}
	}
}
