using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadReconstruction
{
	internal class Program
	{
		private static List<int>[] city;
		private static List<(int, int)> streets;

		static void Main(string[] args)
		{
			ReadCityWithStreets();

			PrintStreets(FindImportantStreets());
		}

		private static void ReadCityWithStreets()
		{
			int buildingsCount = int.Parse(Console.ReadLine());
			int streetsCount = int.Parse(Console.ReadLine());

			city = new List<int>[buildingsCount];
			streets = new List<(int, int)>();

			for (int i = 0; i < streetsCount; i++)
			{
				int[] streetData = Console.ReadLine()
					.Split(" - ").Select(int.Parse).ToArray();
				int a = streetData[0];
				int b = streetData[1];

				if (city[a] == null)
					city[a] = new List<int>();

				if (city[b] == null)
					city[b] = new List<int>();

				city[a].Add(b);
				city[b].Add(a);
				streets.Add((a, b));
			}
		}

		private static List<(int, int)> FindImportantStreets()
		{
			var importantStreets = new List<(int, int)>();

			foreach (var (a, b) in streets)
			{
				city[a].Remove(b);
				city[b].Remove(a);

				if (!IsConnected(a, b))
				{
					(int, int) street = a < b ? (a, b) : (b, a);
					importantStreets.Add(street);
				}

				city[a].Add(b);
				city[b].Add(a);
			}

			return importantStreets;
		}

		private static bool IsConnected(int a, int b)
		{
			var visited = new HashSet<int>();
			var queue = new Queue<int>();
			queue.Enqueue(a);
			visited.Add(a);

			while (queue.Count > 0)
			{
				int current = queue.Dequeue();

				foreach (var connection in city[current])
				{
					if (visited.Contains(connection))
						continue;

					if (connection == b)
						return true;

					queue.Enqueue(connection);
					visited.Add(connection);
				}
			}

			return false;
		}

		private static void PrintStreets(List<(int, int)> importantStreets)
		{
            Console.WriteLine("Important streets:");

            foreach (var street in importantStreets)
                Console.WriteLine($"{street.Item1} {street.Item2}");
		}
	}
}
