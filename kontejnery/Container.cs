using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace kontejnery
{
		public class Container : StorageBase
		{
				public List<Box> Boxes { get; private set; } = new List<Box>();

				public int CurrentVolume { get; private set; }



				public Container(int height, int width, int depth, int weight) : base(height, width, depth, weight)
				{
						CurrentVolume = Volume;
				}


				public void AddBox(Box box)
				{
						if (CurrentVolume >= box.Volume)
						{
								Boxes.Add(box);
								CurrentVolume -= box.Volume;
						}
				}

				public override string ToString()
				{
						return $"Container {ID} Volume left: {CurrentVolume}/{Volume} Contains: {Boxes.Count} boxes.";
				}
		}
}