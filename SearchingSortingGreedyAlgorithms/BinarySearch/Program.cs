using System;
using System.Linq;

namespace BinarySearch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int number = int.Parse(Console.ReadLine());

			Console.WriteLine(BinarySearch(number, numbers));
		}

		private static int BinarySearch(int number, int[] numbers)
		{
			int left = 0;
			int right = numbers.Length - 1;

			while (left <= right)
			{
				int mid = (left + right) / 2;

				if (numbers[mid] == number)
					return mid;

				if (number > numbers[mid])
					left = mid + 1;
				else
					right = mid - 1;
			}

			return -1;
		}
	}
}
