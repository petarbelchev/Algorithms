using System;

namespace PermutationsWithoutRepetitions
{
	internal class Program
	{
		private static string[] elements;
		private static string[] permutation;
		private static bool[] used;

		static void Main(string[] args)
		{
			elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			permutation = new string[elements.Length];

			for (int i = 0; i < elements.Length; i++)
			{
				permutation[0] = elements[i];
				used = new bool[elements.Length];
				used[i] = true;
				Permute(1);
			}
		}

		private static void Permute(int index)
		{
			if (index >= permutation.Length)
			{
				Console.WriteLine(string.Join(' ', permutation));
				return;
			}

			for (int i = 0; i < elements.Length; i++)
			{
				if (!used[i])
				{
					permutation[index] = elements[i];
					used[i] = true;
					Permute(index + 1);
					used[i] = false;
				}
			}
		}
	}
}
