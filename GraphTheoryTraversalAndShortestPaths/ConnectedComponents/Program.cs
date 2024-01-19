using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            DrawGraph();

            visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                    continue;

                var component = new List<int>();
                DFS(node, component);
                Console.WriteLine($"Connected component: {string.Join(' ', component)}");
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
                return;

            visited[node] = true;

            foreach (var child in graph[node])
                DFS(child, component);

            component.Add(node);
        }

        private static void DrawGraph()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                graph[i] = new List<int>();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    int[] nodeChilds = input
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

                    graph[i].AddRange(nodeChilds);
                }
            }
        }
    }
}
