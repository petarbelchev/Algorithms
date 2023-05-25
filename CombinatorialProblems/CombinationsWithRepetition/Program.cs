using System;

namespace CombinationsWithRepetition
{
	internal class Program
	{
		private static string[] elements;
		private static string[] combination;

		static void Main(string[] args)
		{
			elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			combination = new string[int.Parse(Console.ReadLine())];

			Add(0, 0);
		}

		private static void Add(int index, int startIndex)
		{
			if (index >= combination.Length)
			{
				Console.WriteLine(string.Join(' ', combination));
				return;
			}

			for (int i = startIndex; i < elements.Length; i++)
			{
				combination[index] = elements[i];
				Add(index + 1, i);
			}
		}
	}
}
