using System;

namespace VariationsWithoutRepetition
{
	internal class Program
	{
		private static string[] elements;
		private static string[] variation;
		private static bool[] used;

		static void Main(string[] args)
		{
			elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			variation = new string[int.Parse(Console.ReadLine())];

			for (int i = 0; i < elements.Length; i++)
			{
				variation[0] = elements[i];
				used = new bool[elements.Length];
				used[i] = true;
				Add(1);
			}
		}

		private static void Add(int index)
		{
			if (index >= variation.Length)
			{
				Console.WriteLine(string.Join(' ', variation));
				return;
			}
			
			for (int i = 0; i < elements.Length; i++)
			{
				if (!used[i])
				{
					variation[index] = elements[i];
					used[i] = true;
					Add(index + 1);
					used[i] = false;
				}
			}
		}
	}
}
