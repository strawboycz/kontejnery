using System.Collections.Generic;
using kontejnery;

namespace kontejnery
{
		public class Port
		{
				public List<int> Distances { get; private set; } = new List<int>();
				public List<Ship> Ships { get; private set; } = new List<Ship>();

				public bool AddShip(Ship ship, int distanceFromPerviousShip)
				{
						if (Ships.Contains(ship)) return false;
						if(Ships.Count == 0) Ships.Add(ship);
						else
						{
							Ships.Add(ship);
							Distances.Add(distanceFromPerviousShip);
						}
						return true;
				}
		}

}