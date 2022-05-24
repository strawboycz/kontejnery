using System;
using System.Collections.Generic;
using kontejnery.Helpers;

namespace kontejnery
{

		internal class Program
		{

				public static List<string> ListOfContainerIds = new List<string>();
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

						Ship ship1 = new Ship();
						ship1.AddContainer(containers[0]);
						Ship ship2 = new Ship();
						ship2.AddContainer(containers[1]);
						Ship ship3 = new Ship();
						ship3.AddContainer(containers[2]);
						Port port = new Port();
						port.AddShip(ship1, new Random(DateTime.Now.Millisecond).Next(100,450));
						port.AddShip(ship2, new Random(DateTime.Now.Millisecond).Next(100,450));
						port.AddShip(ship3, new Random(DateTime.Now.Millisecond).Next(100,450));
						//port.MoveContainer(ship1, ship1.Containers[0],ship2);

						var action = "";
						while (action != "1" && action != "2" && action != "3")
						{
							Console.Write($"Choose an action:");
							action = Console.ReadLine();
							if (action.ToUpper() == Texts.helpString1.ToUpper() || action.ToUpper() == Texts.helpString2.ToUpper())
							{
								Console.WriteLine(Texts.helpToPrint);
							}
						}

						foreach (Ship ship in port.Ships)
						{
							
							if (ship.Containers.Count>0)
							{
								Console.WriteLine($"Ship {port.Ships.IndexOf(ship) + 1}:");
								Console.WriteLine();
							}
							Console.WriteLine(ship);
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
