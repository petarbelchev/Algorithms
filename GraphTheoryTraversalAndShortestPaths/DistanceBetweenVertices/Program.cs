using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceBetweenVertices
{
	internal class Program
	{
		private class Pair
		{
			public int Predecessor { get; set; }
			public int Sucessor { get; set; }
		}

		private static Dictionary<int, List<int>> graph;

		static void Main(string[] args)
		{
			int edgesCount = int.Parse(Console.ReadLine());
			int pairsCount = int.Parse(Console.ReadLine());

			graph = ReadGraph(edgesCount);
			List<Pair> pairs = ReadPairs(pairsCount);

			foreach (var pair in pairs)
			{
				int distance = FindDistance(pair);
				Console.WriteLine($"{{{pair.Predecessor}, {pair.Sucessor}}} -> {distance}");
			}
		}

		private static int FindDistance(Pair pair)
		{
			Dictionary<int, int> childParentPairs = FindParents(pair);
			int vertex = pair.Sucessor;
			int distance = 0;

			while (childParentPairs.ContainsKey(vertex))
			{
				distance++;
				vertex = childParentPairs[vertex];
			}

			return distance != 0 ? distance : -1;
		}

		private static Dictionary<int, int> FindParents(Pair pair)
		{
			var childParentPairs = new Dictionary<int, int>();
			var visited = new HashSet<int>();
			var queue = new Queue<int>();
			bool isFounded = false;

			queue.Enqueue(pair.Predecessor);
			visited.Add(pair.Predecessor);

			while (queue.Count > 0)
			{
				var vertex = queue.Dequeue();

				foreach (var child in graph[vertex])
				{
					if (visited.Contains(child))
						continue;
					
					childParentPairs[child] = vertex;

					if (child == pair.Sucessor)
					{
						isFounded = true;
						break;
					}

					visited.Add(child);
					queue.Enqueue(child);
				}

				if (isFounded)
					break;
			}

			return childParentPairs;
		}

		private static List<Pair> ReadPairs(int pairsCount)
		{
			var pairs = new List<Pair>();

			for (int i = 0; i < pairsCount; i++)
			{
				int[] pair = Console.ReadLine()
					.Split('-')
					.Select(int.Parse)
					.ToArray();

				pairs.Add(new Pair { Predecessor = pair[0], Sucessor = pair[1] });
			}

			return pairs;
		}

		private static Dictionary<int, List<int>> ReadGraph(int edgesCount)
		{
			var graph = new Dictionary<int, List<int>>();

			for (int i = 0; i < edgesCount; i++)
			{
				string[] edgesData = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
				int vertex = int.Parse(edgesData[0]);

				if (!graph.ContainsKey(vertex))
					graph[vertex] = new List<int>();

				if (edgesData.Length > 1)
					graph[vertex].AddRange(edgesData[1].Split().Select(int.Parse).ToArray());
			}

			return graph;
		}
	}
}
