using System;
using System.Collections.Generic;

namespace Salaries
{
	internal class Program
	{
		private static List<int>[] graph;
		private static Dictionary<int, int> salaries;

		static void Main(string[] args)
		{
			graph = ReadGraph();
			salaries = new Dictionary<int, int>();
			int salariesSum = 0;

			for (int node = 0; node < graph.Length; node++)
				salariesSum += GetSalary(node);

            Console.WriteLine(salariesSum);
        }

		private static int GetSalary(int node)
		{
			if (salaries.ContainsKey(node))
				return salaries[node];

			int salary = 0;

			foreach (var employee in graph[node])
				salary += GetSalary(employee);

			salaries[node] = salary > 0 ? salary : 1;

			return salaries[node];
		}

		private static List<int>[] ReadGraph()
		{
			int n = int.Parse(Console.ReadLine());
			var graph = new List<int>[n];

			for (int r = 0; r < n; r++)
			{
				char[] rowData = Console.ReadLine().ToCharArray();
				graph[r] = new List<int>();

				for (int c = 0; c < n; c++)
				{
					if (rowData[c] == 'Y')
						graph[r].Add(c);
				}
			}

			return graph;
		}
	}
}
