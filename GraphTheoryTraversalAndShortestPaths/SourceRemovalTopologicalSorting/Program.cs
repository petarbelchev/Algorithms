using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceRemovalTopologicalSorting
{
	internal class Program
	{
		private static Dictionary<string, List<string>> graph;
		private static Dictionary<string, int> predecessors;

		static void Main(string[] args)
		{
			ReadGraph();
			CalcPredecessors();
			string path = FindPath();
            Console.WriteLine(path);
        }

		private static void ReadGraph()
		{
			int nodesCount = int.Parse(Console.ReadLine());
			graph = new Dictionary<string, List<string>>();

			for (int i = 0; i < nodesCount; i++)
			{
				string[] nodeData = Console.ReadLine()
					.Split("->", StringSplitOptions.RemoveEmptyEntries);
				string node = nodeData[0].Trim();

				graph[node] = new List<string>();

				if (nodeData.Length > 1)
				{
					graph[node].AddRange(nodeData[1]
						.Trim()
						.Split(", ", StringSplitOptions.RemoveEmptyEntries));
				}
			}
		}

		private static void CalcPredecessors()
		{
			predecessors = new Dictionary<string, int>();

			foreach (var (node, children) in graph)
			{
				if (!predecessors.ContainsKey(node))
					predecessors[node] = 0;

				foreach (var child in children)
				{
					if (!predecessors.ContainsKey(child))
						predecessors[child] = 0;

					predecessors[child]++;
				}
			}
		}

		private static string FindPath()
		{
			var path = new List<string>();

			while (predecessors.Count > 0)
			{
				string node = predecessors.FirstOrDefault(g => g.Value == 0).Key;

				if (node == null)
					break;

				path.Add(node);
				predecessors.Remove(node);

				foreach (var child in graph[node])
					predecessors[child]--;
			}

			if (predecessors.Count == 0)
                return $"Topological sorting: {string.Join(", ", path)}";
			else
                return "Invalid topological sorting";
		}
	}
}
