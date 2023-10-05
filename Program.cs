namespace ZooSimulator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ZooSimulation simulation = new ZooSimulation();
			int i = 0;
			int realWorldTimeInSeconds = 3600; // We want real world 1 hour
			int simulatedWorldTimeInSeconds = 20; // We want real world hour in 20 seconds
			int simulatedTimeStepInSeconds = realWorldTimeInSeconds / simulatedWorldTimeInSeconds;
			DateTime currentZooTime = DateTime.Now;


			while (true)
			{
				i++;

				Console.WriteLine("Current time at the zoo: " + currentZooTime);
				currentZooTime = currentZooTime.AddSeconds(simulatedTimeStepInSeconds);
				Console.WriteLine();
				Console.WriteLine("Monkeys: " + string.Join(", ", simulation.Monkeys.Select(m => m.Health + (m.IsDead ? " (dead)" : " (alive)"))));
				Console.WriteLine("Giraffes: " + string.Join(", ", simulation.Giraffes.Select(g => g.Health + (g.IsDead ? " (dead)" : " (alive)"))));
				Console.WriteLine("Elephants: " + string.Join(", ", simulation.Elephants.Select(e => e.Health + (e.ConsecutiveFailures == 1 ? " (CantWalk)" : e.IsDead ? " (dead)" : " (alive)"))));
				Console.WriteLine();
				Console.WriteLine("Press [F] to feed animals or press [C] to exit the simulation.");

				if (i % simulatedWorldTimeInSeconds == 0)
					simulation.ReduceAnimalHealth();

				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey();
					if (key.Key == ConsoleKey.F)
					{
						Console.WriteLine();
						Console.WriteLine("Feeding animals....");
						simulation.FeedAnimals();
					}
					else if (key.Key == ConsoleKey.C)
						break;
				}

				Thread.Sleep(1000); // Sleep for 1 Sec
				Console.Clear(); //Clear the console window.
			}

		}
	}
}