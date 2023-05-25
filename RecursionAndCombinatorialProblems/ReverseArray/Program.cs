using System;

namespace ReverseArray
{
	internal class Program
	{
		private static string[] elements;

		static void Main(string[] args)
		{
			elements = Console.ReadLine().Split();

			Reverse(0);

            Console.WriteLine(string.Join(' ', elements));
        }

		private static void Reverse(int i)
		{
			if (i == elements.Length / 2)
				return;

			(elements[i], elements[elements.Length - i - 1]) = 
				(elements[elements.Length - i - 1], elements[i]);

			Reverse(i + 1);
		}
	}
}
