using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakCycles
{
    internal class Program
    {
        private static SortedDictionary<string, List<string>> graph;
        private static List<(string, string)> removedEdges;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            removedEdges = new List<(string, string)>();

            foreach (var node in graph.Keys)
                MakeItAcyclic(node);

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var (first, second) in removedEdges)
                Console.WriteLine($"{first} - {second}");
        }

        private static void MakeItAcyclic(string node)
        {
            string connection = graph[node].First();
            graph[node].RemoveAt(0);
            graph[connection].Remove(node);

            if (!IsConnected(node, connection))
            {
                graph[node].Add(connection);
                graph[connection].Add(node);
                return;
            }

            removedEdges.Add((node, connection));
            MakeItAcyclic(node);
        }

        private static bool IsConnected(string first, string second)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();
                visited.Add(node);

                foreach (var connection in graph[node])
                {
                    if (visited.Contains(connection))
                        continue;

                    if (connection == second)
                        return true;

                    queue.Enqueue(connection);
                }
            }

            return false;
        }

        private static SortedDictionary<string, List<string>> ReadGraph()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            var graph = new SortedDictionary<string, List<string>>();

            for (int i = 1; i <= nodesCount; i++)
            {
                string[] nodeData = Console.ReadLine().Split(" -> ");
                string[] nodeConnections = nodeData[1].Split();

                if (!graph.ContainsKey(nodeData[0]))
                    graph[nodeData[0]] = new List<string>();

                foreach (var node in nodeConnections.OrderBy(n => n))
                {
                    if (!graph.ContainsKey(node))
                        graph[node] = new List<string>();

                    graph[nodeData[0]].Add(node);
                }
            }

            return graph;
        }
    }
}
