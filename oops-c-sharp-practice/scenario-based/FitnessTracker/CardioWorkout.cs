using System;

namespace FitnessTracker
{
	public class CardioWorkout : Workout
	{
		public CardioWorkout(int duration) : base(duration)
		{
		}

		public override void Track()
		{
			Console.WriteLine($"Cardio workout for {Duration} minutes");
		}

		public override int CalculateCalories()
		{
			return Duration * 8;
		}
	}
}
