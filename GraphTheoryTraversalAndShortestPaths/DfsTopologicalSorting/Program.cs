using System;
using System.Collections.Generic;

namespace DfsTopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> currentPath;
        private static HashSet<string> visited;
        private static Stack<string> sorted;

        static void Main(string[] args)
        {
            ReadGraph();

            visited = new HashSet<string>();
            currentPath = new HashSet<string>();

            try
            {
                foreach (var node in graph.Keys)
                {
                    if (visited.Contains(node))
                        continue;

                    sorted = new Stack<string>();
                    Dfs(node);
                    Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Dfs(string node)
        {
            if (currentPath.Contains(node))
                throw new ArgumentException("Invalid topological sorting");

            if (visited.Contains(node))
                return;

            currentPath.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
                Dfs(child);

            currentPath.Remove(node);
            sorted.Push(node);
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
    }
}
