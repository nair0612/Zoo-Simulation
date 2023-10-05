using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulator.Entities;

namespace ZooSimulator
{
	public class ZooSimulation
	{
		public List<IAnimal> Monkeys { get; } = new List<IAnimal>();
		public List<IAnimal> Giraffes { get; } = new List<IAnimal>();
		public List<IAnimal> Elephants { get; } = new List<IAnimal>();

		public ZooSimulation()
		{
			// Initialize animals
			for (int i = 0; i < 3; i++)
			{
				Monkeys.Add(new Monkey());
				Giraffes.Add(new Giraffe());
				Elephants.Add(new Elephant());
			}
		}

		public void ReduceAnimalHealth()
		{
			var random = new Random();

			// Assuming each animal type has the same logic for reducing health
			foreach (var animalType in new[] { Monkeys, Giraffes, Elephants })
			{
				foreach (var animal in animalType)
				{
					var reductionPercent = random.Next(0, 21); // Random between 0 and 20
					animal.UpdateHealth(-reductionPercent);
				}
			}
		}

		public void FeedAnimals()
		{
			var random = new Random();

			// Assuming each animal type has the same logic for feeding different types of animals
			foreach (var animalType in new[] { Monkeys, Giraffes, Elephants })
			{
				foreach (var animal in animalType)
				{
					var increasePercent = random.Next(10, 26); // Random between 10 and 25
					animal.UpdateHealth(increasePercent);
				}
			}
		}
	}
}
