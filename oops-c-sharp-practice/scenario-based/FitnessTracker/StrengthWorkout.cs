using System;

namespace FitnessTracker
{
	public class StrengthWorkout : Workout
	{
		public StrengthWorkout(int duration) : base(duration)
		{
		}

		public override void Track()
		{
			Console.WriteLine($"Strength workout for {Duration} minutes");
		}

		public override int CalculateCalories()
		{
			return Duration * 5;
		}
	}
}
