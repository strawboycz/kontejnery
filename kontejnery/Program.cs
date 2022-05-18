using System;

namespace kontejnery
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Container container = GetRandomContainer();
			Box box = GetRandomBox();
			while (container.CurrentVolume>= 125000)
			{
				
				if (container.CurrentVolume >= box.Volume)
				{
					container.AddBox(box);
					Console.WriteLine($"{box}\nhas been inserted into\n{container}\n");
				}
				else
				{
					Console.WriteLine($"{box}\n does not fit into \n{container}");
				}
				box = GetRandomBox();
			}

			Console.WriteLine($"\n\n\nNo more boxes can fit into \n{container}");
			
		}

		public static Container GetRandomContainer()
		{
			Random rnd = new Random();
			return new Container(rnd.Next(500, 1000), rnd.Next(500, 1000), rnd.Next(500, 1000), rnd.Next(500, 1000));
		}
		public static Box GetRandomBox()
		{
			Random rnd = new Random();
			return new Box(rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100));
		}
	}
}
