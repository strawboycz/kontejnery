using kontejnery;

namespace kontejnery
{
		public class Port
		{
				public  static int CountOfShips { get; private set; };
				public int[] Distances { get; private set; } = new int[CountOfShips - 1];
				public Ship[] Ships { get; private set; } = new Ship[CountOfShips];

				public Port(int countOfShips)
				{
					CountOfShips = countOfShips;
				}
		}

}