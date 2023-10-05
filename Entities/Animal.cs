namespace ZooSimulator.Entities
{
	public class Monkey : IAnimal
	{
		public float Health { get; set; } = 100;
		public bool IsDead { get; private set; } = false;
		public int ConsecutiveFailures {get; private set;} = 0;
		public void UpdateHealth(float percentage)
		{
			if (IsDead) return;
			Health = MathF.Max(0, MathF.Min(100, Health + Health * (percentage / 100)));
			if (Health < 30)
			{
				IsDead = true;
			}
		}

	}

	public class Giraffe : IAnimal
	{
		public float Health { get; set; } = 100;
		public bool IsDead { get; private set; } = false;
		public int ConsecutiveFailures {get; private set;} = 0;
		public void UpdateHealth(float percentage)
		{
			if (IsDead) return;
			Health = MathF.Max(0, MathF.Min(100, Health + Health * (percentage / 100)));
			if (Health < 50)
			{
				IsDead = true;
			}
		}
	}

	public class Elephant : IAnimal
	{
		public float Health { get; private set; } = 100;
		public bool IsDead { get; private set; } = false;
		public int ConsecutiveFailures {get; private set;} = 0;
		public bool CanWalk => Health >= 70;
		public void UpdateHealth(float percentage)
		{
			if (IsDead) return;

			float previousHealth = Health;
			Health = MathF.Max(0, MathF.Min(100, Health + Health * (percentage / 100)));

			if (Health < 70 && !CanWalk)
			{
				if (ConsecutiveFailures == 0)
				{
					// First time it goes below 70 and cannot walk
					ConsecutiveFailures++;
				}
				else if (ConsecutiveFailures == 1)
				{
					// Second time it goes below 70 and cannot walk
					IsDead = true;
					ConsecutiveFailures++;
				}
			}
			else
			{
				ConsecutiveFailures = 0; // Reset the counter if health is >= 70 or can walk
			}
		}
	}

}
