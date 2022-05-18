using System;

namespace kontejnery
{
		public abstract class StorageBase
		{
				public Guid ID { get; protected set; } = Guid.NewGuid();
				public int Height { get; protected set; }
				public int Width { get; protected set; }
				public int Depth { get; protected set; }
				public int Volume { get; protected set; }
				public int Weight { get; protected set; }

				public StorageBase(int height, int width, int depth, int weight)
				{
						Height = height;
						Width = width;
						Depth = depth;
						Volume = height * width * depth;
						Weight = weight;
				}




		}

}