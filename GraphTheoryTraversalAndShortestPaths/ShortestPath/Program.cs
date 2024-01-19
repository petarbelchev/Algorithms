using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    internal class Program
    {
        private static HashSet<int>[] graph;
        private static int[] parent;

        static void Main(string[] args)
        {
            graph = ReadGraph();

            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());

            PrintShortestPath(startNode, endNode);
        }

        private static void PrintShortestPath(int startNode, int endNode)
        {
            parent = new int[graph.Length];
            Array.Fill(parent, -1);

            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            var visited = new bool[graph.Length];
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == endNode)
                {
                    PrintPath(node);
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parent[child] = node;
                    }
                }
            }
        }

        private static void PrintPath(int node)
        {
            var path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(string.Join(' ', path));
        }

        private static HashSet<int>[] ReadGraph()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());
            var graph = new HashSet<int>[nodesCount + 1];

            for (int i = 0; i < edgesCount; i++)
            {
                int[] edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (graph[edgeData[0]] == null)
                    graph[edgeData[0]] = new HashSet<int>();

                graph[edgeData[0]].Add(edgeData[1]);

                if (graph[edgeData[1]] == null)
                    graph[edgeData[1]] = new HashSet<int>();

                graph[edgeData[1]].Add(edgeData[0]);
            }

            return graph;
        }
    }
}
