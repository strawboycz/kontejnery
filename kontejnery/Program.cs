using System;
using System.Collections.Generic;

namespace kontejnery
{
	internal class Program
	{
		public const int RandomBoxLower = 50;
		public const int RandomBoxUpper = 100;
		public const int RandomContainerLower = 500;
		public const int RandomContainerUpper = 1000;

		
		static void Main(string[] args)
		{
			List<Box> UnusedBoxes = new List<Box>();
			Container container = GetRandomContainer();

			Box box = new Box(0,0,0,0);
			while (IsContainerNotFull(container))
			{
				box = GetRandomBox();
				var result = AddBoxOrDumpBox(container, box, UnusedBoxes);
				Console.WriteLine(result);
			}

			Console.WriteLine($"\n\n\nNo more boxes can fit into \n{container}");
			
		}

		private static string AddBoxOrDumpBox(Container container, Box box, List<Box> trash)
		{
			if (DoesBoxFitIntoContainer(container, box))
			{
				container.AddBox(box);
				return $"{box}\nhas been inserted into\n{container}\n";
			}
			trash.Add(box);
			return $"{box}\n does not fit into \n{container}";
			
		}

		private static bool DoesBoxFitIntoContainer(Container container, Box box)
		{
			return container.CurrentVolume >= box.Volume;
		}

		private static bool IsContainerNotFull(Container container)
		{
			return container.CurrentVolume>= Math.Pow(RandomBoxLower,3);
		}

		public static Container GetRandomContainer()
		{
			Random rnd = new Random();
			return new Container(rnd.Next(RandomContainerLower, RandomContainerUpper), rnd.Next(RandomContainerLower, RandomContainerUpper), rnd.Next(RandomContainerLower, RandomContainerUpper), rnd.Next(RandomContainerLower, RandomContainerUpper));
		}
		public static Box GetRandomBox()
		{
			Random rnd = new Random();
			return new Box(rnd.Next(RandomBoxLower, RandomBoxUpper), rnd.Next(RandomBoxLower, RandomBoxUpper), rnd.Next(RandomBoxLower, RandomBoxUpper), rnd.Next(RandomBoxLower, RandomBoxUpper));
		}
	}
}
