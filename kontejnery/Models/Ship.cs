using System.Collections.Generic;
using System.ComponentModel;

namespace kontejnery
{
	public class Ship
	{
		public List<Container> Containers { get; private set; } = new List<Container>();

		public bool AddContainer(Container container)
		{
			if (Containers.Count >= 10) return false;
			if (Containers.Contains(container)) return false;
			Containers.Add(container);
			return true;
		}
	}
}
