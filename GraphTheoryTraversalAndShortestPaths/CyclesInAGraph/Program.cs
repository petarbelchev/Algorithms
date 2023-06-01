using System;
using System.Collections.Generic;

namespace CyclesInAGraph
{
	internal class Program
	{
		private static Dictionary<string, List<string>> graph;
		private static HashSet<string> visited;

		static void Main(string[] args)
		{
			graph = ReadGraph();
			bool isGraphAcyclic = IsAcyclic();

			Console.WriteLine("Acyclic: " + (isGraphAcyclic ? "Yes" : "No"));
		}

		private static bool IsAcyclic()
		{
			visited = new HashSet<string>();

			foreach (var (vertex, successors) in graph)
			{
				try
				{
					Dfs(vertex);
				}
				catch (ArgumentException)
				{
					return false;
				}
			}

			return true;
		}

		private static void Dfs(string vertex)
		{
			if (visited.Contains(vertex))
				throw new ArgumentException();

			visited.Add(vertex);

			foreach (var successor in graph[vertex])
				Dfs(successor);

			visited.Remove(vertex);
		}

		private static Dictionary<string, List<string>> ReadGraph()
		{
			string input = Console.ReadLine();
			var graph = new Dictionary<string, List<string>>();

			while (input != "End")
			{
				string[] vertices = input.Split('-');

				if (!graph.ContainsKey(vertices[0]))
					graph[vertices[0]] = new List<string>();

				if (!graph.ContainsKey(vertices[1]))
					graph[vertices[1]] = new List<string>();

				graph[vertices[0]].Add(vertices[1]);

				input = Console.ReadLine();
			}

			return graph;
		}
	}
}
