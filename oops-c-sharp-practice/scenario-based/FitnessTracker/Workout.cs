namespace FitnessTracker
{
	public abstract class Workout : ITrackable
	{
		public int Duration { get; set; }

		public Workout(int duration)
		{
			Duration = duration;
		}

		public abstract void Track();
		public abstract int CalculateCalories();
	}
}
