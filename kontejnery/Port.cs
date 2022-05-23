using System;
using System.Collections.Generic;
using System.Threading;
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
						if (Ships.Count == 0) Ships.Add(ship);
						else
						{
								Ships.Add(ship);
								Distances.Add(distanceFromPerviousShip);
						}
						return true;
				}

				public int GetTimeToMove(Ship firtShip, Ship secondShip)
				{
						if (!(Ships.Contains(firtShip) && Ships.Contains(secondShip)))
								throw new Exception();
						int firstShipLocation = Ships.IndexOf(firtShip);
						int secondShipLocation = Ships.IndexOf(secondShip);
						int time = new int();
						for (int i = firstShipLocation; i < secondShipLocation; i++)
						{
								time += Distances[i];
						}
						return time;
				}

				public void MoveContainer(Ship firstShip, Container container, Ship secondShip)
				{
						if (!firstShip.Containers.Contains(container))
								throw new Exception();
						int timeToMove = GetTimeToMove(firstShip, secondShip);
						Thread.Sleep(timeToMove);
						Console.WriteLine($"Moving the container took {timeToMove} ms");
						int locationOfContainer = firstShip.Containers.IndexOf(container);
						firstShip.Containers.RemoveAt(locationOfContainer);
						secondShip.AddContainer(container);
				}
		}

}