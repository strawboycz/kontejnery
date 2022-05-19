using System;
using System.Runtime.CompilerServices;

namespace kontejnery
{
		public class Box : StorageBase
		{
			
				public Box(int height, int width, int depth, int weight) : base(height, width, depth, weight)
				{

				}

			public override string ToString()
			{
				return $"Box {ID} - Volume:{Volume}";
			}
		}
}