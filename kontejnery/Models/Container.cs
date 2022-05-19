using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace kontejnery
{
		public class Container : StorageBase
		{
				public List<Box> Boxes { get; private set; } = new List<Box>();

				public int VolumeLeft { get; private set; }



				public Container(int height, int width, int depth, int weight) : base(height, width, depth, weight)
				{
						VolumeLeft = Volume;
				}


				public void AddBox(Box box)
				{
						if (VolumeLeft >= box.Volume)
						{
								Boxes.Add(box);
								VolumeLeft -= box.Volume;
								Weight += box.Weight;
						}
				}

				public bool RemoveBox(Box box)
				{
					if (Boxes.Contains(box))
						return false;
					Boxes.Remove(box);
					return true;
				}

				public override string ToString()
				{
						return $"Container {ID} Volume left: {VolumeLeft}/{Volume} Weight: {Weight} Contains: {Boxes.Count} boxes.";
				}
		}
}