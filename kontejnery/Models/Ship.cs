using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace kontejnery
{
		public class Ship
		{
				public List<Container> Containers { get; private set; } = new List<Container>();

				public bool AddContainer(Container container)
				{
						if (Containers.Contains(container)) return false;
						Containers.Add(container);
						return true;
				}

				public override string ToString()
				{
						// Table of Containers
						Console.WriteLine("Container Id\tContainer Weight\tNumber of boxes");
						Console.WriteLine("------------\t----------------\t---------------");
						foreach (Container container in Containers)
						{
								Console.WriteLine($"   {container.CustomId}\t\t      {container.Weight}\t\t      {container.Boxes.Count}");
						}
						return "";
				}
		}
}
