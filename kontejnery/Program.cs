using System;
using System.Collections.Generic;

namespace kontejnery
{
		internal class Program
		{
				public const int RandomBoxLower = 50;
				public const int RandomBoxUpper = 100;
				public const int RandomContainerLower = 500;
				public const int RandomContainerUpper = 1000;


				static void Main(string[] args)
				{
						List<Box> UnusedBoxes = new List<Box>();
						List<Container> containers = new List<Container>();


						Box box = new Box(0, 0, 0, 0);
						for (int i = 0; i < 3; i++)
						{
								containers.Add(GetRandomContainer());
								while (IsContainerNotFull(containers[i]))
								{
										box = GetRandomBox();
										var result = AddBoxOrDumpBox(containers[i], box, UnusedBoxes);
										/*if (result == true)
												Console.WriteLine($"{box}\nhas been inserted into\n{containers[i]}\n");
										else
												Console.WriteLine($"{box}\n does not fit into \n{containers[i]}\n");*/

								}
								//Console.WriteLine($"\nNo more boxes can fit into \n{containers[i]}");
						}

						// Table of Containers
						Console.WriteLine("\t\tContainer Id\t\t\tContainer Weight\tNumber of boxes");
						Console.WriteLine("\t\t------------\t\t\t----------------\t---------------");
						foreach (Container container in containers)
						{
							Console.WriteLine($"\t{container.ID}\t      {container.Weight}\t\t      {container.Boxes.Count}");
						}
				}

				private static bool AddBoxOrDumpBox(Container container, Box box, List<Box> trash)
				{
						if (DoesBoxFitIntoContainer(container, box))
						{
								container.AddBox(box);
								return true;
						}
						trash.Add(box);
						return false;

				}

				private static bool DoesBoxFitIntoContainer(Container container, Box box)
				{
						return container.VolumeLeft >= box.Volume;
				}

				private static bool IsContainerNotFull(Container container)
				{
						return container.VolumeLeft >= Math.Pow(RandomBoxLower, 3);
				}

				public static Container GetRandomContainer()
				{
						Random rnd = new Random();
						return new Container(rnd.Next(RandomContainerLower, RandomContainerUpper), rnd.Next(RandomContainerLower, RandomContainerUpper), rnd.Next(RandomContainerLower, RandomContainerUpper), rnd.Next(RandomContainerLower, RandomContainerUpper));
				}
				public static Box GetRandomBox()
				{
						Random rnd = new Random();
						return new Box(rnd.Next(RandomBoxLower, RandomBoxUpper), rnd.Next(RandomBoxLower, RandomBoxUpper), rnd.Next(RandomBoxLower, RandomBoxUpper), rnd.Next(RandomBoxLower, RandomBoxUpper));
				}
		}
}
