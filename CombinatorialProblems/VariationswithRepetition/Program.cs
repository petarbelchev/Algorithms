using System;

namespace VariationsWithRepetition
{
	internal class Program
	{
		private static string[] elements;
		private static string[] variation;

		static void Main(string[] args)
		{
			elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			variation = new string[int.Parse(Console.ReadLine())];
		
			for (int i = 0; i < elements.Length; i++)
			{
				variation[0] = elements[i];
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
				variation[index] = elements[i];
				Add(index + 1);
			}
		}
	}
}
